using System;

namespace CommonServiceFactory.Conventions
{
    /// <summary>
    /// Defines the capabilities of a conventions container.
    /// </summary>
    public interface IConventionsContainer : IHideObjectMembers
    {
        /// <summary>
        /// Gets a convention for the type specified by the <paramref name="serviceType"/> parameter.
        /// </summary>
        /// <param name="serviceType">The <see cref="Type"/> to get the conventions for.</param>
        /// <returns>An <see cref="IConventions"/> instance</returns>
        IConventions Get(Type serviceType);

        /// <summary>
        /// Sets up the conventions used by the <see cref="T:CommonServiceFactory.HostFactory"/> instances.
        /// </summary>
        /// <param name="action">The setup action.</param>
        /// <remarks>Should throw a <see cref="T:System.ArgumentNullException"/> if the <paramref name="action"/> parameter was null.</remarks>
        void Setup(Action<ISetupExpression> action);
    }
}