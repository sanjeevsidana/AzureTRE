# Introduction to Authentication and Authorization

[Azure Active Directory (AAD)](https://docs.microsoft.com/en-us/azure/active-directory/fundamentals/active-directory-whatis) is the backbone of Authentication and Authorization in the Trusted Research Environment. AAD holds the identities of all the TRE/workspace users, including administrators, and connects the identities with applications which define the permissions for each user role.

It is common that the Azure Administrator is not necessarily the Azure Active Directory Administrator. Due to this, this step may have to be carried out by a different individual/team. We have automated this into a simple command, but should you wish, you can run these steps manually.

This page describes the automated Auth setup for TRE.

## Pre-requisites
The automation utilises a `make` command, which reads a few environment variables and creates the AAD assets. The following values are needed to be in place before you run the creation process. (`/templates/core/.env`)

| Key | Description |
| ----------- | ----------- |
|TRE_ID|This is used to build up the name of the identities|
|AAD_TENANT_ID|The tenant id of where your AAD identities will be placed. This can be different to the tenant where your Azure resources are created.|
| LOCATION | Where your Azure assets will be provisioned (eg. westeurope). This is used to add a redirect URI from the Swagger UI to the API Application.
|AUTO_WORKSPACE_APP_REGISTRATION| Default of `false`. Setting this to true grants the `Application.ReadWrite.All` permission to the *Application Admin* identity. This identity is used to manage other AAD applications that it owns, e.g. Workspaces. If you do not set this, the identity will have `Application.ReadWrite.OwnedBy`. Further information can be found [here](./identities/application_admin.md).

## Create Authentication assets
You can build all of the Identity assets by running the following at the command line
```bash
make auth
```
This will create five identities, and if successful will write a new file; `/devops/auth.env`. If you are building locally, these values will be used when building your TRE. If you are setting this up for CI/CD, then these values will be needed by your Build Orchestrator.

The contents of your `/devops/auth.env` file should contain : -

  | Variable | Description |
  | -------- | ----------- |
  | `APPLICATION_ADMIN_CLIENT_ID`| This client will administer AAD Applications for TRE |
  | `APPLICATION_ADMIN_CLIENT_SECRET`| This client will administer AAD Applications for TRE |
  | `TEST_ACCOUNT_CLIENT_ID`| This will be created by default, but can be disabled by editing `/devops/scripts/create_aad_assets.sh`. This is the user that will run the tests for you |
  | `TEST_ACCOUNT_CLIENT_SECRET` | This will be created by default, but can be disabled by editing `/devops/scripts/create_aad_assets.sh`. This is the user that will run the tests for you |
  | `API_CLIENT_ID` | API application (client) ID. |
  | `API_CLIENT_SECRET` | API application client secret. |
  | `SWAGGER_UI_CLIENT_ID` | Swagger (OpenAPI) UI application (client) ID. |
  | `WORKSPACE_API_CLIENT_ID` | Each workspace is secured behind it's own AD Application|
  | `WORKSPACE_API_CLIENT_SECRET` | Each workspace is secured behind it's own AD Application. This is the secret for that application.|

### Using a separate Azure Active Directory tenant

!!! caution
    This section is only relevant it you are setting up a separate Azure Active Directory tenant for use.
    This is only recommended for development environments when you don't have the required permissions to register applications in Azure Active Directory.
    Using a separate Azure Active Directory tenant will prevent you from using certain Azure Active Directory integrated services.
    For production deployments, work with your Azure Active Directory administrator to perform the required registration

1. Create an Azure Active Directory tenant
    To create a new Azure Active Directory tenant, [follow the steps here](https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-create-new-tenant)

1. Follow the steps outlined above. `make auth` should logon to the correct tenant. Make sure you logon back to the correct tenant before running `make all`.


## App registrations

App registrations (represented by service principals) define the various access permissions to the TRE system. There are a total of five main Applications of interest.

| AAD Application | Description |
| ----------- | ----------- |
| TRE API application | This is the main application and used to secure access to the [TRE API](../tre-developers/api.md). |
| TRE UX | This is the client application that will authenticate to the TRE/Workspace APIs. |
| Application Admin | There are times when workspace services need to update the AAD Application. For example, Guacamole needs to add a redirect URI to the Workspace AAD Application. This identity is used to manage AAD Applications.
| Automation App | This application is created so that you can run the tests or any CI/CD capability without the need to divulge a user password. This is particularly important if your tenant is MFA enabled. |
| Workspace API | Typically you would have an application securing one or more workspaces that are created by TRE. |

Some of the applications require **admin consent** to allow them to validate users against the AAD. Check the Microsoft Docs on [Configure the admin consent workflow](https://docs.microsoft.com/en-us/azure/active-directory/manage-apps/configure-admin-consent-workflow) on how to request admin consent and handle admin consent requests.

We strongly recommend that you use `make auth` to create the AAD assets as this has been tested extensively. Should you wish to create these manually via the [Azure Portal](https://docs.microsoft.com/azure/active-directory/develop/quickstart-register-app); more information can be found [here](./identities/auth-manual.md).
