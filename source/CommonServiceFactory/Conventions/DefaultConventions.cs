using System;
using CommonServiceFactory.Conventions;

namespace CommonServiceFactory.Conventions
{
    /// <summary>
    /// Defines the default conventions used by the Common Service Factory.
    /// </summary>
    public class DefaultConventions : IConventions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommonServiceFactory.Conventions.DefaultConventions"/> class.
        /// </summary>
        public DefaultConventions()
        {
        }

        /// <summary>
        /// Gets the service contract name for a specified service <see cref="T:System.Type"/>.
        /// </summary>
        /// <param name="serviceType">The <see cref="T:System.Type"/> to resolve the contract name of.</param>
        /// <returns>A <see cref="T:System.String"/> containg the name of the contract type.</returns>
        public string GetServiceContractName(Type serviceType)
        {
            return string.Concat("I", serviceType.Name);
        }
    }
}