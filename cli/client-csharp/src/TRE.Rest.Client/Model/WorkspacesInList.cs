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
    /// WorkspacesInList
    /// </summary>
    [DataContract(Name = "WorkspacesInList")]
    public partial class WorkspacesInList : IEquatable<WorkspacesInList>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspacesInList" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WorkspacesInList() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspacesInList" /> class.
        /// </summary>
        /// <param name="workspaces">workspaces (required).</param>
        public WorkspacesInList(Collection<Workspace> workspaces = default(Collection<Workspace>))
        {
            // to ensure "workspaces" is required (not null)
            if (workspaces == null) {
                throw new ArgumentNullException("workspaces is a required property for WorkspacesInList and cannot be null");
            }
            this.Workspaces = workspaces;
        }

        /// <summary>
        /// Gets or Sets Workspaces
        /// </summary>
        [DataMember(Name = "workspaces", IsRequired = true, EmitDefaultValue = false)]
        public Collection<Workspace> Workspaces { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkspacesInList {\n");
            sb.Append("  Workspaces: ").Append(Workspaces).Append("\n");
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
            return this.Equals(input as WorkspacesInList);
        }

        /// <summary>
        /// Returns true if WorkspacesInList instances are equal
        /// </summary>
        /// <param name="input">Instance of WorkspacesInList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WorkspacesInList input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Workspaces == input.Workspaces ||
                    this.Workspaces != null &&
                    input.Workspaces != null &&
                    this.Workspaces.SequenceEqual(input.Workspaces)
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
                if (this.Workspaces != null)
                {
                    hashCode = (hashCode * 59) + this.Workspaces.GetHashCode();
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
