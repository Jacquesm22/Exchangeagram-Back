using System;

namespace ExchangeAGram.Application.Common.Attributes
{
    /// <summary>
    /// Specifies the class this attribute is applied to requires authorization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorizeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAuthorizeAttribute"/> class. 
        /// </summary>
        public CustomAuthorizeAttribute() { }

        /// <summary>
        /// Gets or sets a comma delimited list of roles that are allowed to access the resource.
        /// </summary>
        public string Roles { get; set; }

        /// <summary>
        /// Gets or sets the policy name that determines access to the resource.
        /// </summary>
        public string Policy { get; set; }
    }
}