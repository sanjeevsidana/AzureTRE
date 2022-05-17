/*
 * Azure TRE API
 *
 * Welcome to the Azure TRE API - for more information about templates and workspaces see the [Azure TRE documentation](https://microsoft.github.io/AzureTRE)
 *
 * The version of the OpenAPI document: 0.2.14
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = TRE.Rest.Client.Client.OpenAPIDateConverter;

namespace TRE.Rest.Client.Model
{
    /// <summary>
    /// ResourcePatch
    /// </summary>
    [DataContract(Name = "ResourcePatch")]
    public partial class ResourcePatch : IEquatable<ResourcePatch>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcePatch" /> class.
        /// </summary>
        /// <param name="isEnabled">isEnabled.</param>
        /// <param name="properties">properties.</param>
        public ResourcePatch(bool isEnabled = default(bool), Object properties = default(Object))
        {
            this.IsEnabled = isEnabled;
            this.Properties = properties;
        }

        /// <summary>
        /// Gets or Sets IsEnabled
        /// </summary>
        [DataMember(Name = "isEnabled", EmitDefaultValue = true)]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or Sets Properties
        /// </summary>
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public Object Properties { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ResourcePatch {\n");
            sb.Append("  IsEnabled: ").Append(IsEnabled).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ResourcePatch);
        }

        /// <summary>
        /// Returns true if ResourcePatch instances are equal
        /// </summary>
        /// <param name="input">Instance of ResourcePatch to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ResourcePatch input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.IsEnabled == input.IsEnabled ||
                    this.IsEnabled.Equals(input.IsEnabled)
                ) && 
                (
                    this.Properties == input.Properties ||
                    (this.Properties != null &&
                    this.Properties.Equals(input.Properties))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                hashCode = (hashCode * 59) + this.IsEnabled.GetHashCode();
                if (this.Properties != null)
                {
                    hashCode = (hashCode * 59) + this.Properties.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
