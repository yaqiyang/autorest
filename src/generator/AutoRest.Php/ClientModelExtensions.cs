// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AutoRest.Core.ClientModel;
using AutoRest.Core.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AutoRest.Php
{
    /// <summary>
    /// Keeps a few aux method used across all templates/models.
    /// </summary>
    public static class ClientModelExtensions
    {
        /// <summary>
        /// Determines if a type can be assigned the value null.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>True if null can be assigned, otherwise false.</returns>
        public static bool IsNullable(this IType type)
        {
            return true;
        }

        /// <summary>
        /// Simple conversion of the type to string.
        /// </summary>
        /// <param name="type">The type to convert</param>
        /// <param name="reference">a reference to an instance of the type</param>
        /// <returns></returns>
        public static string ToString(this IType type, string reference)
        {
            // need to do this for Php
            return reference;
        }

        /// <summary>
        /// Internal method for generating Yard-compatible representation of given type.
        /// </summary>
        /// <param name="type">The type doc needs to be generated for.</param>
        /// <returns>Doc in form of string.</returns>
        private static string PrepareTypeForDocRecursively(IType type)
        {
            var sequenceType = type as SequenceType;
            var compositeType = type as CompositeType;
            var enumType = type as EnumType;
            var dictionaryType = type as DictionaryType;
            var primaryType = type as PrimaryType;

            if (primaryType != null)
            {
                if (primaryType.Type == KnownPrimaryType.String)
                {
                    return "string";
                }

                if (primaryType.Type == KnownPrimaryType.Int || primaryType.Type == KnownPrimaryType.Long)
                {
                    return "int";
                }

                if (primaryType.Type == KnownPrimaryType.Boolean)
                {
                    return "bool";
                }

                if (primaryType.Type == KnownPrimaryType.Double)
                {
                    return "float";
                }

                if (primaryType.Type == KnownPrimaryType.Date)
                {
                    return @"\DateTime";
                }

                if (primaryType.Type == KnownPrimaryType.DateTime)
                {
                    return @"\DateTime";
                }

                if (primaryType.Type == KnownPrimaryType.DateTimeRfc1123)
                {
                    return @"\DateTime";
                }

                if (primaryType.Type == KnownPrimaryType.ByteArray)
                {
                    return "array";
                }

                if (primaryType.Type == KnownPrimaryType.TimeSpan)
                {
                    return "int"; //TODO: Is Timespan # of seconds or ticks?
                }

                if (primaryType.Type == KnownPrimaryType.Credentials)
                {
                    return "OAuthSettings";
                }

            }

            if (compositeType != null)
            {
                return DocumentCompositeType(compositeType);
            }

            if (enumType != null)
            {
                return enumType.Name;
            }

            if (sequenceType != null)
            {
                string internalString = PrepareTypeForDocRecursively(sequenceType.ElementType);

                if (!string.IsNullOrEmpty(internalString))
                {
                    return string.Format("array ({0})", internalString);
                }

                return string.Empty;
            }

            if (dictionaryType != null)
            {
                string internalString = PrepareTypeForDocRecursively(dictionaryType.ValueType);

                if (!string.IsNullOrEmpty(internalString))
                {
                    return string.Format("array ({0})", internalString);
                }

                return string.Empty;
            }

            return "object";
        }

        /// <summary>
        /// Return the separator associated with a given collectionFormat.
        /// </summary>
        /// <param name="format">The collection format.</param>
        /// <returns>The separator.</returns>
        private static string GetSeparator(this CollectionFormat format)
        {
            switch (format)
            {
                case CollectionFormat.Csv:
                    return ",";
                case CollectionFormat.Pipes:
                    return "|";
                case CollectionFormat.Ssv:
                    return " ";
                case CollectionFormat.Tsv:
                    return "\t";
                default:
                    throw new NotSupportedException(string.Format("Collection format {0} is not supported.", format));
            }
        }

        /// <summary>
        /// Format the value of a sequence given the modeled element format. Note that only sequences of strings are supported.
        /// </summary>
        /// <param name="parameter">The parameter to format.</param>
        /// <returns>A reference to the formatted parameter value.</returns>
        public static string GetFormattedReferenceValue(this Parameter parameter)
        {
            SequenceType sequence = parameter.Type as SequenceType;
            if (sequence == null)
            {
                return parameter.Name;
            }

            PrimaryType primaryType = sequence.ElementType as PrimaryType;
            EnumType enumType = sequence.ElementType as EnumType;
            if (enumType != null && enumType.ModelAsString)
            {
                primaryType = new PrimaryType(KnownPrimaryType.String);
            }

            if (primaryType == null || primaryType.Type != KnownPrimaryType.String)
            {
                throw new InvalidOperationException(
                    string.Format("Cannot generate a formatted sequence from a " +
                                  "non-string array parameter {0}", parameter));
            }

            return string.Format("{0}.join('{1}')", parameter.Name, parameter.CollectionFormat.GetSeparator());
        }

        /// <summary>
        /// Generates Yard-compatible representation of given type.
        /// </summary>
        /// <param name="type">The type doc needs to be generated for.</param>
        /// <returns>Doc in form of string.</returns>
        public static string GetYardDocumentation(this IType type)
        {
            string typeForDoc = PrepareTypeForDocRecursively(type);

            if (string.IsNullOrEmpty(typeForDoc))
            {
                return string.Empty;
            }

            return string.Format("{0}", typeForDoc);
        }

        /// <summary>
        /// Generate code to perform required validation on a type.
        /// </summary>
        /// <param name="type">The type to validate.</param>
        /// <param name="scope">A scope provider for generating variable names as necessary.</param>
        /// <param name="valueReference">A reference to the value being validated.</param>
        /// <returns>The code to validate the reference of the given type.</returns>
        public static string ValidateType(this IType type, IScopeProvider scope, string valueReference)
        {
            CompositeType model = type as CompositeType;
            SequenceType sequence = type as SequenceType;
            DictionaryType dictionary = type as DictionaryType;

            return null;
        }

        /// <summary>
        /// Determine whether a model should be serializable.
        /// </summary>
        /// <param name="type">The type to check.</param>
        public static bool IsSerializable(this IType type)
        {
            return !type.IsPrimaryType(KnownPrimaryType.Object);
        }

        /// <summary>
        /// Verifies whether client includes model types.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns>True if client contain model types, false otherwise.</returns>
        public static bool HasModelTypes(this ServiceClient client)
        {
            return client.ModelTypes.Any(mt => mt.Extensions.Count == 0);
        }

        /// <summary>
        /// Generates Php code in form of string for deserializing object of given type.
        /// </summary>
        /// <param name="type">Type of object needs to be deserialized.</param>
        /// <param name="scope">Current scope.</param>
        /// <param name="valueReference">Reference to object which needs to be deserialized.</param>
        /// <returns>Generated Php code in form of string.</returns>
        public static string DeserializeType(
            this IType type,
            IScopeProvider scope,
            string valueReference)
        {
            var composite = type as CompositeType;
            var sequence = type as SequenceType;
            var dictionary = type as DictionaryType;
            var primary = type as PrimaryType;
            var enumType = type as EnumType;

            var builder = new IndentedStringBuilder("  ");

            return string.Empty;
        }

        /// <summary>
        /// Generates Php code in form of string for serializing object of given type.
        /// </summary>
        /// <param name="type">Type of object needs to be serialized.</param>
        /// <param name="scope">Current scope.</param>
        /// <param name="valueReference">Reference to object which needs to serialized.</param>
        /// <returns>Generated Php code in form of string.</returns>
        public static string SerializeType(
            this IType type,
            IScopeProvider scope,
            string valueReference)
        {
            var composite = type as CompositeType;
            var sequence = type as SequenceType;
            var dictionary = type as DictionaryType;
            var primary = type as PrimaryType;

            var builder = new IndentedStringBuilder("  ");

            return string.Empty;
        }

        /// <summary>
        /// Determines whether one composite type derives directly or indirectly from another.
        /// </summary>
        /// <param name="type">Type to test.</param>
        /// <param name="possibleAncestorType">Type that may be an ancestor of this type.</param>
        /// <returns>true if the type is an ancestor, false otherwise.</returns>
        public static bool DerivesFrom(this CompositeType type, CompositeType possibleAncestorType)
        {
            return
                type.BaseModelType != null &&
                (type.BaseModelType.Equals(possibleAncestorType) ||
                 type.BaseModelType.DerivesFrom(possibleAncestorType));
        }

        public static string TrimGetsSets(this string documentation)
        {
            if (string.IsNullOrEmpty(documentation))
            {
                return documentation;
            }
            documentation = documentation.Trim();

            string token = "Gets or sets ";
            if (documentation.StartsWith(token, StringComparison.OrdinalIgnoreCase))
            {
                return documentation.Substring(token.Length);
            }

            token = "Gets ";
            if (documentation.StartsWith(token, StringComparison.OrdinalIgnoreCase))
            {
                return documentation.Substring(token.Length);
            }

            token = "Sets ";
            if (documentation.StartsWith(token, StringComparison.OrdinalIgnoreCase))
            {
                return documentation.Substring(token.Length);
            }

            return documentation;
        }

        private static string DocumentCompositeType(CompositeType compositeType, int level = 0, bool parentRequired = false)
        {
            // infinite loops possible in some cases
            if (level >= 5)
            {
                return string.Empty;
            }

            List<string> phpArray = new List<string>();

            foreach (Property prop in compositeType.Properties)
            {
                var compositeProp = prop.Type as CompositeType;
                var enumProp = prop.Type as EnumType;
                var primaryType = prop.Type as PrimaryType;
                var dictionaryType = prop.Type as DictionaryType;

                string value = string.Empty;

                if (compositeProp != null)
                {
                    value = DocumentCompositeType(compositeProp, level + 1, prop.IsRequired);
                    phpArray.Add(string.Format("'{0}' => {1}", prop.SerializedName, value));
                }
                else if (enumProp != null)
                {
                    List<string> values = new List<string>();
                    enumProp.Values.ForEach(p => values.Add(p.SerializedName));
                    phpArray.Add(string.Format("'{0}' => '{1}'", prop.SerializedName, string.Join("|", values)));
                }
                else if (primaryType != null && primaryType.Type == KnownPrimaryType.Boolean)
                {
                    phpArray.Add(string.Format("'{0}' => 'false'", prop.SerializedName));
                }
                else if (primaryType != null && primaryType.Type != KnownPrimaryType.String)
                {
                    value = prop.DefaultValue == null ? string.Empty : prop.DefaultValue.ToString();
                    phpArray.Add(string.Format("'{0}' => '{1}'", prop.SerializedName, value));
                }
                else if (dictionaryType != null) //The Json serializer in PHP doesn't handle empty arrays
                {
                    phpArray.Add(string.Format("'{0}' => ''", prop.SerializedName));
                }
                else
                {
                    if (prop.DefaultValue == null)
                    {
                        // if this prop and its parent are both required, tell the user it is required
                        if ((level == 0 || parentRequired) && prop.IsRequired)
                        {
                            value = string.Format("required{0}", prop.Name.ToPascalCase());
                        }
                    }
                    else
                    {
                        value = prop.DefaultValue.ToString();
                    }

                    phpArray.Add(string.Format("'{0}' => '{1}'", prop.SerializedName, value.Trim('\'', '\"')));
                }
            }

            string output = "";

            foreach (string line in phpArray)
            {
                if (line.EndsWith("\n"))
                {
                    output += string.Format("{0}{1}", GetTabs(level + 1), line);
                }
                else
                {
                    output += string.Format("{0}{1},\n", GetTabs(level + 1), line);
                }
            }

            if (level == 0)
            {
                return string.Format("\n<pre>\n[\n{0}\n];\n</pre>\n", output.Trim('\n', ','));
            }
            else
            {
                return string.Format("[\n{1}\n{0}],\n", GetTabs(level), output.Trim('\n', ','));
            }
        }

        private static string GetTabs(int repeats)
        {
            // use default tab as 3 characters
            return (repeats > 0) ? new string(' ', repeats * 3) : string.Empty;
        }
    }
}
