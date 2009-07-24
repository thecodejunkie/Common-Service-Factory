using System;

namespace CommonServiceFactory.Conventions
{
    /// <summary>
    /// Defines a set of conventions used by the Common Service Factory.
    /// </summary>
    public interface IConventions
    {
        /// <summary>
        /// Gets the service contract name for a specified service <see cref="T:System.Type"/>.
        /// </summary>
        /// <param name="serviceType">The <see cref="T:System.Type"/> to resolve the contract name of.</param>
        /// <returns>A <see cref="T:System.String"/> containg the name of the contract type.</returns>
        string GetServiceContractName(Type serviceType);
    }
}