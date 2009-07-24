using System.Diagnostics;
using CommonServiceFactory.Conventions;

namespace CommonServiceFactory
{
    /// <summary>
    /// A <see cref="T:System.ServiceModel.Activation.ServiceHostFactory"/> with support for conventions.
    /// </summary>
    public abstract class HostFactory : System.ServiceModel.Activation.ServiceHostFactory
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ConventionsContainer container = new ConventionsContainer();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommonServiceFactory.HostFactory"/> class.
        /// </summary>
        protected HostFactory()
        {
        }

        /// <summary>
        /// Gets the conventions used by the <see cref="T:CommonServiceFactory.HostFactory"/> instances.
        /// </summary>
        /// <value>A <see cref="T:CommonServiceFactory.Conventions.IConventionsContainer"/> instance.</value>
        public static IConventionsContainer Conventions
        {
            get { return container; }
        }
    }
}