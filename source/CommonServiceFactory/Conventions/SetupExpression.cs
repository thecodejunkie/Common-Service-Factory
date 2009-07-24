using System;
using System.Collections.Generic;
using CommonServiceFactory.Resources;

namespace CommonServiceFactory.Conventions
{
    /// <summary>
    /// Registers conventions for service types using a fluent interface style.
    /// </summary>
    public class SetupExpression : ISetupExpression, ISetupBehavior
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommonServiceFactory.Conventions.SetupExpression"/> class.
        /// </summary>
        public SetupExpression()
        {
            this.Conventions = new Dictionary<Type, IConventions>();
            this.Default = new DefaultConventions();
        }

        /// <summary>
        /// Gets or sets the registered convetions.
        /// </summary>
        /// <value>An <see cref="T:System.Collections.Generic.IDictionary{TKey,TValue}"/> instance.</value>
        private IDictionary<Type, IConventions> Conventions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:CommonServiceFactory.Conventions.IConventions"/> that is currently being configured.
        /// </summary>
        /// <value>An <see cref="T:CommonServiceFactory.Conventions.IConventions"/> instance.</value>
        private IConventions Current { get; set; }
        
        /// <summary>
        /// Gets or set the default <see cref="T:CommonServiceFactory.Conventions.IConventions"/> implementation
        /// to use when no other match can be found in the container.
        /// </summary>
        /// <value>A <see cref="T:CommonServiceFactory.Conventions.IConventions"/> instance.</value>
        private IConventions Default { get; set; }

        /// <summary>
        /// Sets the current conventions as the default conventions.
        /// </summary>
        public void AsDefault()
        {
            this.Default = this.Current;
        }

        /// <summary>
        /// Sets the current conventions as the conventions that should be used but the <typeparamref name="TService"/> service type.
        /// </summary>
        /// <typeparam name="TService">The <see cref="T:System.Type"/> of the service to use the current conventions with.</typeparam>
        public void For<TService>() where TService : class
        {
            this.Conventions.Add(typeof(TService), this.Current);
        }

        /// <summary>
        /// Gets the conventions for a specified service.
        /// </summary>
        /// <param name="serviceType">The <see cref="T:System.Type"/> of the service to get the conventions for.</param>
        /// <returns>An <see cref="T:CommonServiceFactory.Conventions.IConventions"/> instance</returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="serviceType"/> parameter was <see langword="null"/>.</exception>
        public IConventions Get(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType", ErrorMessages.ServiceTypeNull);
            }

            var conventions =
                (this.Conventions.ContainsKey(serviceType)) ? this.Conventions[serviceType] : this.Default;

            return conventions;
        }

        /// <summary>
        /// Registers a <see cref="T:CommonServiceFactory.Conventions.IConventions"/> instance.
        /// </summary>
        /// <typeparam name="TConventions"></typeparam>
        /// <returns>A <see cref="T:CommonServiceFactory.Conventions.ISetupBehavior"/> instance.</returns>
        public ISetupBehavior Use<TConventions>() where TConventions : IConventions, new()
        {
            this.Current = new TConventions();
            return this;
        }
    }
}