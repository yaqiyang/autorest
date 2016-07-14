// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using System.IO;
using AutoRest.Core;
using AutoRest.Core.ClientModel;
using AutoRest.Extensions;
using AutoRest.Php.TemplateModels;
using AutoRest.Php.Templates;

namespace AutoRest.Php
{
    /// <summary>
    /// A class with main code generation logic for Php.
    /// </summary>
    public class PhpCodeGenerator : CodeGenerator
    {
        /// <summary>
        /// The name of the SDK. Determined in the following way:
        /// if the parameter 'Name' is provided that it becomes the
        /// name of the SDK, otherwise the name of input swagger is converted
        /// into Php style and taken as name.
        /// </summary>
        protected readonly string sdkName;

        /// <summary>
        /// The name of the package version to be used in creating a version.rb file
        /// </summary>
        protected readonly string packageVersion;
        
        /// <summary>
        /// The name of the package name to be used in creating a version.rb file
        /// </summary>
        protected readonly string packageName;

        /// <summary>
        /// Relative path to produced SDK files.
        /// </summary>
        protected readonly string sdkPath;

        /// <summary>
        /// Relative path to produced SDK model files.
        /// </summary>
        protected readonly string modelsPath;

        /// <summary>
        /// A code namer instance (object which is responsible for correct files/variables naming).
        /// </summary>
        protected PhpCodeNamer CodeNamer { get; private set; }

        /// <summary>
        /// Initializes a new instance of the class PhpCodeGenerator.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public PhpCodeGenerator(Settings settings) : base(settings)
        {
            CodeNamer = new PhpCodeNamer();
            this.packageVersion = Settings.PackageVersion;
            this.packageName = Settings.PackageName;

            if (Settings.CustomSettings.ContainsKey("Name"))
            {
                this.sdkName = Settings.CustomSettings["Name"].ToString();
            }

            if (sdkName == null)
            {
                this.sdkName = Path.GetFileNameWithoutExtension(Settings.Input);
            }

            if (sdkName == null)
            {
                sdkName = "client";
            }

            this.sdkName = PhpCodeNamer.PhpCamelCase(CodeNamer.PhpRemoveInvalidCharacters(this.sdkName));
            this.sdkPath = this.packageName ?? this.sdkName;
            this.modelsPath = Path.Combine(this.sdkPath, "Models");
        }

        /// <summary>
        /// Gets the name of code generator.
        /// </summary>
        public override string Name
        {
            get { return "Php"; }
        }

        /// <summary>
        /// Gets the brief description of the code generator.
        /// </summary>
        public override string Description
        {
            get { return "Generic Php code generator."; }
        }

        /// <summary>
        /// Gets the brief instructions required to complete before using the code generator.
        /// </summary>
        public override string UsageInstructions
        {
            get { return "Guzzle is required for working with generated Php code."; }
        }

        /// <summary>
        /// Gets the file extension of the generated code files.
        /// </summary>
        public override string ImplementationFileExtension
        {
            get { return ".php"; }
        }

        /// <summary>
        /// Normalizes client model by updating names and types to be language specific.
        /// </summary>
        /// <param name="serviceClient"></param>
        public override void NormalizeClientModel(ServiceClient serviceClient)
        {
            SwaggerExtensions.ProcessParameterizedHost(serviceClient, Settings);
            PopulateAdditionalProperties(serviceClient);
            CodeNamer.NormalizeClientModel(serviceClient);
            CodeNamer.ResolveNameCollisions(serviceClient, Settings.Namespace,
                Settings.Namespace + "\\Models");
        }

        /// <summary>
        /// Adds special properties to the service client (e.g. credentials).
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        private void PopulateAdditionalProperties(ServiceClient serviceClient)
        {
            if (Settings.AddCredentials)
            {
                var prop = serviceClient.Properties.Find(p => p.Name == "Credentials");
                if (prop != null)
                {
                    prop.Type = new PrimaryType(KnownPrimaryType.Credentials);
                }
                else
                {
                    serviceClient.Properties.Add(new Property
                    {
                        Name = "Credentials",
                        Type = new PrimaryType(KnownPrimaryType.Credentials),
                        IsRequired = true,
                        Documentation = "Subscription credentials which uniquely identify client subscription."
                    });
                }
            }
        }

        /// <summary>
        /// Generates Php code for service client.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>Async task for generating SDK files.</returns>
        public override async Task Generate(ServiceClient serviceClient)
        {
            // Service client
            var serviceClientTemplate = new ServiceClientTemplate
            {
                Model = new ServiceClientTemplateModel(serviceClient),
            };
            await Write(serviceClientTemplate,
                Path.Combine(sdkPath, PhpCodeNamer.PhpCamelCase(serviceClient.Name) + ImplementationFileExtension));

            // Method groups
            foreach (var group in serviceClient.MethodGroups)
            {
                var groupTemplate = new MethodGroupTemplate
                {
                    Model = new MethodGroupTemplateModel(serviceClient, group),
                };
                await Write(groupTemplate,
                    Path.Combine(sdkPath, PhpCodeNamer.PhpCamelCase(group) + ImplementationFileExtension));
            }

            // Models
            foreach (var model in serviceClient.ModelTypes)
            {
                var modelTemplate = new ModelTemplate
                {
                    Model = new ModelTemplateModel(model, serviceClient.ModelTypes)
                };
                await Write(modelTemplate,
                    Path.Combine(modelsPath, PhpCodeNamer.PhpCamelCase(model.Name) + ImplementationFileExtension));
            }            
        }
    }
}
