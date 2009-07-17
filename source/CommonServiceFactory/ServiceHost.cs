using System;

namespace CommonServiceFactory
{
    /// <summary>
    /// A <see cref="T:System.ServiceModel.ServiceHost"/> instance that dynamically injects the
    /// <see cref="T:CommonServiceFactory.ServiceBehavior"/> behavoir at runtime.
    /// </summary>
    public class ServiceHost : System.ServiceModel.ServiceHost
    {
        /// <summary>
        /// Creates a new instance of the <see cref="T:CommonServiceFactory.ServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">The <see cref="T:System.Type"/> of the service.</param>
        /// <param name="baseAddresses">The <see cref="T:System.Array"/> of type <see cref="T:System.Uri"/> that contains the base addresses for the service hosted.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="serviceType"/> or <paramref name="baseAddresses"/> is <see langword="null"/>.</exception>
        public ServiceHost(Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType", "The service type cannot be null.");

            if (baseAddresses == null)
                throw new ArgumentNullException("baseAddresses", "The base addresses cannot be null.");

            this.ServiceType = serviceType;
        }

        /// <summary>
        /// Gets the <see cref="T:System.Type"/> of the service.
        /// </summary>
        /// <value>A <see cref="T:System.Type"/> instance.</value>
        public Type ServiceType { get; private set; }

        /// <summary>
        /// Invoked during the transition of a communication object into the opening state.
        /// </summary>
        protected override void OnOpening()
        {
            this.Description.Behaviors.Add(new ServiceBehavior(this.ServiceType));
            base.OnOpening();
        }
    }
}