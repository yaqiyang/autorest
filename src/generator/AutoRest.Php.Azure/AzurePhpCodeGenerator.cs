// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.Core;
using AutoRest.Core.ClientModel;
using AutoRest.Extensions.Azure;
using AutoRest.Extensions.Azure.Model;
using AutoRest.Php.Azure.TemplateModels;
using AutoRest.Php.Azure.Templates;
using AutoRest.Php.TemplateModels;
using AutoRest.Php.Templates;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRest.Php.Azure
{
    /// <summary>
    /// A class with main code generation logic for Azure.Php.
    /// </summary>
    public class AzurePhpCodeGenerator : PhpCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the class AzurePhpCodeGenerator.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public AzurePhpCodeGenerator(Settings settings) : base(settings)
        {
        }

        /// <summary>
        /// Gets the name of code generator.
        /// </summary>
        public override string Name
        {
            get { return "Azure.Php"; }
        }

        /// <summary>
        /// Gets the description of code generator.
        /// </summary>
        public override string Description
        {
            get { return "Azure specific Php code generator."; }
        }

        /// <summary>
        /// Gets the usage instructions for the code generator.
        /// </summary>
        public override string UsageInstructions
        {
            get { return "Guzzle is required for working with generated Php code."; }
        }

        /// <summary>
        /// Normalizes client model by updating names and types to be language specific.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        public override void NormalizeClientModel(ServiceClient serviceClient)
        {
            Settings.AddCredentials = true;
            AzureExtensions.ProcessClientRequestIdExtension(serviceClient);
            AzureExtensions.UpdateHeadMethods(serviceClient);
            AzureExtensions.ParseODataExtension(serviceClient);
            AzureExtensions.AddPageableMethod(serviceClient, CodeNamer);
            AzureExtensions.AddLongRunningOperations(serviceClient);
            AzureExtensions.AddAzureProperties(serviceClient);
            AzureExtensions.SetDefaultResponses(serviceClient);
            base.NormalizeClientModel(serviceClient);
        }

        /// <summary>
        /// Generates C# code for service client.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>Async tasks which generates SDK files.</returns>
        public override async Task Generate(ServiceClient serviceClient)
        {
            // Service client
            var serviceClientTemplate = new ServiceClientTemplate
            {
                Model = new AzureServiceClientTemplateModel(serviceClient),
            };
            await Write(serviceClientTemplate, Path.Combine(sdkPath, serviceClient.Name + ImplementationFileExtension));

            // Operations
            foreach (var group in serviceClient.MethodGroups)
            {
                var operationsTemplate = new AzureMethodGroupTemplate
                {
                    Model = new AzureMethodGroupTemplateModel(serviceClient, group),
                };
                await Write(operationsTemplate, Path.Combine(sdkPath, operationsTemplate.Model.MethodGroupName + ImplementationFileExtension));
            }
        }
    }
}
