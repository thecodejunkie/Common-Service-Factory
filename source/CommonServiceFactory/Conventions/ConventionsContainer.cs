using System;
using CommonServiceFactory.Resources;

namespace CommonServiceFactory.Conventions
{
    /// <summary>
    /// Provides the capabilities for working with conventions in the Common Service Factory.
    /// </summary>
    public class ConventionsContainer : IConventionsContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommonServiceFactory.Conventions.ConventionsContainer"/> class.
        /// </summary>
        public ConventionsContainer()
        {
            this.Expression = new SetupExpression();
        }

        /// <summary>
        /// Gets or sets the <see cref="T:CommonServiceFactory.Conventions.ISetupExpression"/>, used by the container.
        /// </summary>
        /// <value>An <see cref="T:CommonServiceFactory.Conventions.ISetupExpression"/> instance.</value>
        private ISetupExpression Expression { get; set; }

        /// <summary>
        /// Gets a convention for the type specified by the <paramref name="serviceType"/> parameter.
        /// </summary>
        /// <param name="serviceType">The <see cref="System.Type"/> to get the conventions for.</param>
        /// <returns>An <see cref="T:CommonServiceFactory.Conventions.IConventions"/> instance</returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="serviceType"/> parameter was <see langword="null"/>.</exception>
        public IConventions Get(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType", ErrorMessages.ServiceTypeNull);
            }

            return this.Expression.Get(serviceType);
        }

        /// <summary>
        /// Sets up the conventions used by the <see cref="T:CommonServiceFactory.HostFactory"/> instances.
        /// </summary>
        /// <param name="action">The setup action.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="action"/> cannot be <see langword="null"/>.</exception>
        public void Setup(Action<ISetupExpression> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action", ErrorMessages.ActionNull);
            }

            action(this.Expression);
        }
    }
}