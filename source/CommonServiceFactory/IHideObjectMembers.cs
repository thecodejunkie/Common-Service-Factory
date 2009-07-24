using System;
using System.ComponentModel;

namespace CommonServiceFactory
{
    /// <summary>
    /// Hides the methods inherited by the <see cref="T:System.Object"/> type.
    /// </summary>
    /// <remarks>Based on Daniel Cazzulino's blog post http://www.clariusconsulting.net/blogs/kzu/archive/2008/03/10/58301.aspx</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHideObjectMembers
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();

        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object obj);
    }
}