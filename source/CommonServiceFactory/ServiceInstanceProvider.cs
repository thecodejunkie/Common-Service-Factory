using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using CommonServiceFactory.Resources;
using Microsoft.Practices.ServiceLocation;

namespace CommonServiceFactory
{
    /// <summary>
    /// A service instance provider that uses the Common Service Locator to get an instance of the
    /// requested service type.
    /// </summary>
    public class ServiceInstanceProvider : IInstanceProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommonServiceFactory.ServiceInstanceProvider"/> class.
        /// </summary>
        /// <param name="serviceType">The <see cref="T:System.Type"/> of the service.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="serviceType"/> is <see langword="null"/>.</exception>
        public ServiceInstanceProvider(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType", ErrorMessages.ServiceTypeNull);

            this.ServiceType = serviceType;
        }

        /// <summary>
        /// Gets the <see cref="System.Type"/> of the service.
        /// </summary>
        /// <value>A <see cref="System.Type"/> instance.</value>
        public Type ServiceType { get; private set; }

        /// <summary>
        /// Returns a service object given the specified <see cref="T:System.ServiceModel.InstanceContext" /> object.
        /// </summary>
        /// <returns>A user-defined service object.</returns>
        /// <param name="instanceContext">The current <see cref="T:System.ServiceModel.InstanceContext" /> object.</param>
        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }

        /// <summary>
        /// Returns a service object given the specified <see cref="T:System.ServiceModel.InstanceContext" /> object.
        /// </summary>
        /// <returns>The service object.</returns>
        /// <param name="instanceContext">The current <see cref="T:System.ServiceModel.InstanceContext" /> object.</param>
        /// <param name="message">The message that triggered the creation of a service object.</param>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return ServiceLocator.Current.GetInstance(this.ServiceType);
        }

        /// <summary>
        /// Called when an <see cref="T:System.ServiceModel.InstanceContext" /> object recycles a service object.
        /// </summary>
        /// <param name="instanceContext">The service's instance context.</param>
        /// <param name="instance">The service object to be recycled.</param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}