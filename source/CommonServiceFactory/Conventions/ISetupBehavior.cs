namespace CommonServiceFactory.Conventions
{
    /// <summary>
    /// Defines the functionality supported for controlling how conventions are used.
    /// </summary>
    public interface ISetupBehavior
    {
        /// <summary>
        /// Sets the current conventions as the default conventions.
        /// </summary>
        void AsDefault();

        /// <summary>
        /// Sets the current conventions as the conventions that should be used but the <typeparamref name="TService"/> service type.
        /// </summary>
        /// <typeparam name="TService">The <see cref="T:System.Type"/> of the service to use the current conventions with.</typeparam>
        void For<TService>() where TService : class;
    }
}