using System;
using System.Net;
using System.Net.Http;

namespace ModernHttpClient
{
    public abstract class NativeMessageHandler : HttpClientHandler
    {
        public static NativeMessageHandler Create()
        {
#if ANDROID
            return new AndroidNativeMessageHandler
            {
                DisableCaching = true
            };
#elif IOS
            return new NSNativeMessageHandler
            {
                DisableCaching = true
            };
#else
            throw new NotSupportedException();
#endif
        }

        public static NativeMessageHandler Create(
            bool throwOnCaptiveNetwork,
            TLSConfig tLSConfig,
            INativeCookieHandler cookieHandler = null,
            IWebProxy proxy = null,
            TimeSpan? timeout = null,
            bool disableCaching = true)
        {
#if ANDROID
            return new AndroidNativeMessageHandler(throwOnCaptiveNetwork, tLSConfig, cookieHandler, proxy)
            {
                DisableCaching = disableCaching,
                Timeout = timeout
            };
#elif IOS
            return new NSNativeMessageHandler(throwOnCaptiveNetwork, tLSConfig, cookieHandler, proxy)
            {
                DisableCaching = disableCaching,
                Timeout = timeout
            };
#else
            throw new NotSupportedException();
#endif
        }
    }
}