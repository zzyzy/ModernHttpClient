using System;

namespace ModernHttpClient
{
    public static class NativeCookieHandler
    {
        public static INativeCookieHandler Create()
        {
#if ANDROID
            return new AndroidNativeCookieHandler();
#elif IOS
            return new NSNativeCookieHandler();
#else
            throw new NotSupportedException();
#endif
        }
    }
}