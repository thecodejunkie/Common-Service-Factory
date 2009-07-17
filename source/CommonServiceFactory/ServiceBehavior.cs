using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using CommonServiceFactory.Resources;

namespace CommonServiceFactory
{
    /// <summary>
    /// A service behavior which adds the <see cref="T:CommonServiceFactory.ServiceInstanceProvider"/> to all of the
    /// endpoints that match contract of the service.
    /// </summary>
    public class ServiceBehavior : IServiceBehavior
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommonServiceFactory.ServiceBehavior"/> class.
        /// </summary>
        /// <param name="serviceType">The <see cref="T:System.Type"/> of the service.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="serviceType"/> is <see langword="null"/>.</exception>
        public ServiceBehavior(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType", ErrorMessages.ServiceTypeNull);

            this.ServiceType = serviceType;
        }

        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>The type of the service.</value>
        public Type ServiceType { get; private set; }

        /// <summary>
        /// Provides the ability to pass custom data to binding elements to support the contract implementation.
        /// </summary>
        /// <param name="serviceDescription">The service description of the service.</param>
        /// <param name="serviceHostBase">The host of the service.</param>
        /// <param name="endpoints">The service endpoints.</param>
        /// <param name="bindingParameters">Custom objects to which binding elements have access.</param>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// Provides the ability to change run-time property values or insert custom extension objects such as error handlers, message or parameter interceptors, security extensions, and other custom extension objects.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The host that is currently being built.</param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            var instanceProvider =
                new ServiceInstanceProvider(this.ServiceType);

            var implementors =
                from end in serviceDescription.Endpoints
                where end.Contract.ContractType.IsAssignableFrom(this.ServiceType)
                select end.Contract.Name;

            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher = 
                    channelDispatcherBase as ChannelDispatcher;

                if (channelDispatcher != null)
                {
                    foreach (EndpointDispatcher endPoint in channelDispatcher.Endpoints)
                    {
                        if (implementors.Contains(endPoint.ContractName))
                            endPoint.DispatchRuntime.InstanceProvider = instanceProvider;
                    }
                }
            }
        }

        /// <summary>
        /// Provides the ability to inspect the service host and the service description to confirm that the service can run successfully.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host that is currently being constructed.</param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}