using System;
using System.ServiceModel;
using CommonServiceFactory.Resources;

namespace CommonServiceFactory
{
    /// <summary>
    /// Creates <see cref="T:System.ServiceModel.ServiceHost"/> instances of the type specified by the type parameter <typeparamref name="THost"/>.
    /// </summary>
    /// <typeparam name="THost">The type of the <see cref="T:System.ServiceModel.ServiceHost"/> objects that the factory creates.</typeparam>
    public abstract class HostFactory<THost> : HostFactory where THost : System.ServiceModel.ServiceHost
    {
        /// <summary>
        /// Initializing a new instance of the <see cref="T:CommonServiceFactory.HostFactory{T}"/> class.
        /// </summary>
        protected HostFactory()
        {
        }

        /// <summary>
        /// Creates a <see cref="T:System.ServiceModel.ServiceHost"/> with specific base addresses and initializes it with specified data.
        /// </summary>
        /// <param name="constructorString">The initialization data passed to the <see cref="T:System.ServiceModel.ServiceHostBase"/> instance being constructed by the factory.</param>
        /// <param name="baseAddresses">The <see cref="T:System.Array"/> of type <see cref="T:System.Uri"/> that contains the base addresses for the service hosted.</param>
        /// <returns>
        /// A <see cref="T:System.ServiceModel.ServiceHost"/> with specific base addresses.
        /// </returns>
        /// <exception cref="T:System.ServiceModel.ServiceActivationException">The was a problem creating the <see cref="T:System.ServiceModel.ServiceHost"/> instance.</exception>
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            var serviceType =
                Type.GetType(constructorString, false);

            if (serviceType != null)
            {
                THost hostInstance;

                if (this.TryCreateHostInstance(serviceType, baseAddresses, out hostInstance))
                {
                    return hostInstance;
                }
            }

            throw new ServiceActivationException(ErrorMessages.ServiceActivation);
        }

        /// <summary>
        /// Tries the create host instance.
        /// </summary>
        /// <param name="serviceType">The <see cref="T:System.Type"/> of the service.</param>
        /// <param name="baseAddresses">The base addresses of the service.</param>
        /// <param name="instance">The instance.</param>
        /// <returns><see langword="true"/> if the host instance could be created; otherwise <see langword="false"/>.</returns>
        protected virtual bool TryCreateHostInstance(Type serviceType, Uri[] baseAddresses, out THost instance)
        {
            try 
	        {	        
                instance =
                    (THost)Activator.CreateInstance(typeof(THost), new object[] { serviceType, baseAddresses });

                return true;
	        }
	        catch
	        {
                instance = default(THost);
                return false;
	        }
        }
    }
}