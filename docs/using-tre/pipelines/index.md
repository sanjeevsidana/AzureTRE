# Pipelines

The [AzureTRE deployment repository](https://github.com/microsoft/AzureTRE-Deployment) contains the following github workflows:

1. Build Validation - validates the code by running linter and terraform validation.
1. Clean Validation Environments - a periodical workflow to clean unused AzureTRE environments.
1. Deploy Azure TRE (branch) - This workflow is intended to be used to test workflow changes. It deploys AzureTRE using the workflows defined on the branch
1. Deploy Azure TRE - This workflow is the integration build run for pushes to the main branch. It also runs on a schedule, serving as the nightly build to keep the main AzureTRE env in sync.
1. Deploy Azure TRE Reusable - responsible to deploy AzureTRE. It is referenced in other Azure TRE deployment workflows.


## Setup Github Environment

The workflows are using Github environment to source its environment variables. Follow [this guide](https://docs.github.com/en/actions/deployment/targeting-different-environments/using-environments-for-deployment#creating-an-environment) to define it in your github repository and provide it as an input for the workflows.

The following environment variables should be defined in your github environment:

1. [Auth env vars](auth.md##create_authentication_assets)
1. [Core and Devops env vars](docs/tre-admins/environment-variables.md)
1. Setup Azure Container Registry (ACR) to hold the devcontainer images:
    1. Create ACR to hold the devcontainer images following [this guide](https://docs.microsoft.com/en-us/azure/container-registry/container-registry-get-started-portal?tabs=azure-cli).
    1. [Enable Admin Account](https://docs.microsoft.com/en-us/azure/container-registry/container-registry-authentication?tabs=azure-cli#admin-account)
    1. Having setup the previous steps, add the created ACR info to your Github Actions environment:

    | <div style="width: 330px">Environment variable name</div> | Description                                                                       |
    | --------------------------------------------------------- | --------------------------------------------------------------------------------- |
    | `ACTIONS_ACR_NAME`                                        | The Azure Container registry name that the devcontainer is stored in.             |
    | `ACTIONS_ACR_URI`                                         | The full uri of the Azure Container Registry where the devcontainer is stored in. |
    | `ACTIONS_ACR_PASSWORD`                                    | The Azure Container registry password for the devcontainer.                       |
    | `ACTIONS_DEVCONTAINER_TAG`                                | The container label to use when running the command.                              |


Having all the environment variables set in the Github environment the next step will be to use it in your pipelines:

In AzureTRE deployment repository You will find all the pipelines under the folder `.github/workflows` on top of each workflow there is the workflow
inputs part where the used Github environment name is set, make sure to update it with yours, for example:

![Setup env in pipeline](../../assets/using-tre/pipelines_set_env.png)

## Publish Custom Templates in Pipelines

If you have created custom AzureTRE templates you can publish and register them as part of the CI/CD pipelines. To do so follow the next steps:
1. Go to `.github/workflows/deploy_tre_reusable.yml` workflow. Add your template under the following jobs:
    - publish_bundles:
        ![Publish bundle](../../assets/using-tre/push_bundles_step.png)
    - register_bundles:
        ![Register bundle](../../assets/using-tre/register_bundles.png)
    - If it is a user resource add it also under register_user_resource_bundles:
        ![Register user resource step](../../assets/using-tre/register_user_resource.png)

## How to Contribute to our Documentation

If you have any comments or suggestions about our documentation then you can visit our GitHub project and either raise a new issue, or comment on one of the existing ones.

You can find our existing documentation issues on GitHub by clicking on the link below:

[Existing Documentation Issues](https://github.com/microsoft/AzureTRE/issues?q=is%3Aissue+is%3Aopen+label%3Adocumentation)

Or, you can raise a new issue by clicking on this link:

[Report an Issue or Make a Suggestion](https://github.com/microsoft/AzureTRE/issues/new/choose)

**Thank you for your patience and support!**
