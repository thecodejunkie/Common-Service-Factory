using System;

namespace CommonServiceFactory.Conventions
{
    /// <summary>
    /// Defines the functionality supported for working with conventions.
    /// </summary>
    public interface ISetupExpression : IHideObjectMembers
    {
        /// <summary>
        /// Gets the conventions for a specified service.
        /// </summary>
        /// <param name="serviceType">The <see cref="T:System.Type"/> of the service to get the conventions for.</param>
        /// <returns>An <see cref="IConventions"/> instance</returns>
        IConventions Get(Type serviceType);

        /// <summary>
        /// Registers a <see cref="T:CommonServiceFactory.Conventions.IConventions"/> instance.
        /// </summary>
        /// <typeparam name="TConventions"></typeparam>
        /// <returns>A <see cref="T:CommonServiceFactory.Conventions.ISetupBehavior"/> instance.</returns>
        ISetupBehavior Use<TConventions>() where TConventions : IConventions, new();

        /// <summary>
        /// Uses the specified action to register a <see cref="T:CommonServiceFactory.Conventions.IConventions"/> factory.
        /// </summary>
        /// <param name="factory">The factory action.</param>
        /// <returns>A <see cref="T:CommonServiceFactory.Conventions.ISetupBehavior"/> instance.</returns>
        ISetupBehavior Use(Func<IConventions> factory);
    }
}