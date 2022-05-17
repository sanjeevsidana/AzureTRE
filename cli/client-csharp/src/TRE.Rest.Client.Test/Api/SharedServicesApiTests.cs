/*
 * Azure TRE API
 *
 * Welcome to the Azure TRE API - for more information about templates and workspaces see the [Azure TRE documentation](https://microsoft.github.io/AzureTRE)
 *
 * The version of the OpenAPI document: 0.2.14
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using TRE.Rest.Client.Client;
using TRE.Rest.Client.Api;
// uncomment below to import models
//using TRE.Rest.Client.Model;

namespace TRE.Rest.Client.Test.Api
{
    /// <summary>
    ///  Class for testing SharedServicesApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class SharedServicesApiTests : IDisposable
    {
        private SharedServicesApi instance;

        public SharedServicesApiTests()
        {
            instance = new SharedServicesApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of SharedServicesApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' SharedServicesApi
            //Assert.IsType<SharedServicesApi>(instance);
        }

        /// <summary>
        /// Test CreateASharedServiceApiSharedServicesPost
        /// </summary>
        [Fact]
        public void CreateASharedServiceApiSharedServicesPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //SharedServiceInCreate sharedServiceInCreate = null;
            //var response = instance.CreateASharedServiceApiSharedServicesPost(sharedServiceInCreate);
            //Assert.IsType<OperationInResponse>(response);
        }

        /// <summary>
        /// Test DeleteSharedServiceApiSharedServicesSharedServiceIdDelete
        /// </summary>
        [Fact]
        public void DeleteSharedServiceApiSharedServicesSharedServiceIdDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string sharedServiceId = null;
            //var response = instance.DeleteSharedServiceApiSharedServicesSharedServiceIdDelete(sharedServiceId);
            //Assert.IsType<OperationInResponse>(response);
        }

        /// <summary>
        /// Test GetASingleResourceOperationByIdApiSharedServicesSharedServiceIdOperationsOperationIdGet
        /// </summary>
        [Fact]
        public void GetASingleResourceOperationByIdApiSharedServicesSharedServiceIdOperationsOperationIdGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string sharedServiceId = null;
            //string operationId = null;
            //var response = instance.GetASingleResourceOperationByIdApiSharedServicesSharedServiceIdOperationsOperationIdGet(sharedServiceId, operationId);
            //Assert.IsType<OperationInResponse>(response);
        }

        /// <summary>
        /// Test GetAllOperationsForAResourceApiSharedServicesSharedServiceIdOperationsGet
        /// </summary>
        [Fact]
        public void GetAllOperationsForAResourceApiSharedServicesSharedServiceIdOperationsGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string sharedServiceId = null;
            //var response = instance.GetAllOperationsForAResourceApiSharedServicesSharedServiceIdOperationsGet(sharedServiceId);
            //Assert.IsType<OperationInList>(response);
        }

        /// <summary>
        /// Test GetAllSharedServicesApiSharedServicesGet
        /// </summary>
        [Fact]
        public void GetAllSharedServicesApiSharedServicesGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetAllSharedServicesApiSharedServicesGet();
            //Assert.IsType<SharedServicesInList>(response);
        }

        /// <summary>
        /// Test GetSharedServiceByIdApiSharedServicesSharedServiceIdGet
        /// </summary>
        [Fact]
        public void GetSharedServiceByIdApiSharedServicesSharedServiceIdGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string sharedServiceId = null;
            //var response = instance.GetSharedServiceByIdApiSharedServicesSharedServiceIdGet(sharedServiceId);
            //Assert.IsType<SharedServiceInResponse>(response);
        }

        /// <summary>
        /// Test InvokeActionOnASharedServiceApiSharedServicesSharedServiceIdInvokeActionPost
        /// </summary>
        [Fact]
        public void InvokeActionOnASharedServiceApiSharedServicesSharedServiceIdInvokeActionPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string sharedServiceId = null;
            //string action = null;
            //var response = instance.InvokeActionOnASharedServiceApiSharedServicesSharedServiceIdInvokeActionPost(sharedServiceId, action);
            //Assert.IsType<OperationInResponse>(response);
        }

        /// <summary>
        /// Test UpdateAnExistingSharedServiceApiSharedServicesSharedServiceIdPatch
        /// </summary>
        [Fact]
        public void UpdateAnExistingSharedServiceApiSharedServicesSharedServiceIdPatchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string sharedServiceId = null;
            //ResourcePatch resourcePatch = null;
            //string etag = null;
            //var response = instance.UpdateAnExistingSharedServiceApiSharedServicesSharedServiceIdPatch(sharedServiceId, resourcePatch, etag);
            //Assert.IsType<SharedServiceInResponse>(response);
        }
    }
}
