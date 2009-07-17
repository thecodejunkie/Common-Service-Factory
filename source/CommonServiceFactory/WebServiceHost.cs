using System;
using CommonServiceFactory;
using CommonServiceFactory.Resources;

namespace CommonServiceFactory
{
    /// <summary>
    /// A <see cref="T:System.ServiceModel.ServiceHost"/> instance that dynamically injects the
    /// <see cref="T:CommonServiceFactory.ServiceBehavior"/> behavoir at runtime.
    /// </summary>
    public class WebServiceHost : System.ServiceModel.Web.WebServiceHost
    {
        /// <summary>
        /// Creates a new instance of the <see cref="T:CommonServiceFactory.WebServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">The <see cref="T:System.Type"/> of the service.</param>
        /// <param name="baseAddresses">The <see cref="T:System.Array"/> of type <see cref="T:System.Uri"/> that contains the base addresses for the service hosted.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="serviceType"/> or <paramref name="baseAddresses"/> is <see langword="null"/>.</exception>
        public WebServiceHost(Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType", ErrorMessages.ServiceTypeNull);

            if (baseAddresses == null)
                throw new ArgumentNullException("baseAddresses", ErrorMessages.BaseAddressesNull);

            this.ServiceType = serviceType;
        }

        /// <summary>
        /// Gets the <see cref="T:System.Type"/> of the service.
        /// </summary>
        /// <value>A <see cref="T:System.Type"/> instance.</value>
        public Type ServiceType { get; private set; }

        /// <summary>
        /// Called when the <see cref="T:System.ServiceModel.Web.WebServiceHost"/> instance opens.
        /// </summary>
        protected override void OnOpening()
        {
            this.Description.Behaviors.Add(new ServiceBehavior(this.ServiceType));
            base.OnOpening();
        }
    }
}