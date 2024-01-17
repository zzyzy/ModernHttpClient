using System.Collections.Generic;
using System.Net;

namespace ModernHttpClient
{
    public interface INativeCookieHandler
    {
        void SetCookies(IEnumerable<Cookie> cookies);

        void DeleteCookies();

        void SetCookie(Cookie cookie);

        void DeleteCookie(Cookie cookie);

        List<Cookie> Cookies { get; }
    }
}