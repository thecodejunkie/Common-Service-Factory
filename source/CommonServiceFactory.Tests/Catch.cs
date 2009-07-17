using System;

namespace CommonServiceFactory.Tests
{
    public class Catch
    {
        public static Exception Exception(Action context)
        {
            try
            {
                context();
            }
            catch (Exception thrownException)
            {
                return thrownException;
            }

            return null;
        }
    }
}