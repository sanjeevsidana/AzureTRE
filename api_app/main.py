import logging
from opencensus.ext.azure.trace_exporter import AzureExporter
import uvicorn

from fastapi import FastAPI
from fastapi.exceptions import RequestValidationError
from fastapi_utils.tasks import repeat_every
from service_bus.airlock_request_status_update import receive_step_result_message_and_update_status

from services.tracing import RequestTracerMiddleware
from opencensus.trace.samplers import ProbabilitySampler

from starlette.exceptions import HTTPException
from starlette.middleware.errors import ServerErrorMiddleware

from api.routes.api import router as api_router
from api.errors.http_error import http_error_handler
from api.errors.validation_error import http422_error_handler
from api.errors.generic_error import generic_error_handler
from core import config
from core.events import create_start_app_handler, create_stop_app_handler
from services.logging import disable_unwanted_loggers, initialize_logging, telemetry_processor_callback_function
from service_bus.deployment_status_update import receive_message_and_update_deployment


def get_application() -> FastAPI:
    application = FastAPI(
        title=config.PROJECT_NAME,
        debug=config.DEBUG,
        description=config.API_DESCRIPTION,
        version=config.VERSION,
        docs_url=None,
        redoc_url=None,
        openapi_url=None
    )

    application.add_event_handler("startup", create_start_app_handler(application))
    application.add_event_handler("shutdown", create_stop_app_handler(application))

    try:
        exporter = AzureExporter(sampler=ProbabilitySampler(1.0))
        exporter.add_telemetry_processor(telemetry_processor_callback_function)
        application.add_middleware(RequestTracerMiddleware, exporter=exporter)
    except Exception as e:
        logging.error(f"Failed to add RequestTracerMiddleware: {e}")

    application.add_middleware(ServerErrorMiddleware, handler=generic_error_handler)
    application.add_exception_handler(HTTPException, http_error_handler)
    application.add_exception_handler(RequestValidationError, http422_error_handler)

    application.include_router(api_router)
    return application


app = get_application()


@app.on_event("startup")
async def initialize_logging_on_startup():
    if config.DEBUG:
        initialize_logging(logging.DEBUG)
    else:
        initialize_logging(logging.INFO)

    disable_unwanted_loggers()


@app.on_event("startup")
@repeat_every(seconds=20, wait_first=True, logger=logging.getLogger())
async def update_deployment_status() -> None:
    await receive_message_and_update_deployment(app)


@app.on_event("startup")
@repeat_every(seconds=20, wait_first=True, logger=logging.getLogger())
async def update_airlock_request_status() -> None:
    await receive_step_result_message_and_update_status(app)

if __name__ == "__main__":
    uvicorn.run(app, host="0.0.0.0", port=8000)
