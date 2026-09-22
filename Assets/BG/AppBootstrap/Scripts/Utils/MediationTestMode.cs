using System.Collections.Generic;
using System.Linq;
using GoogleMobileAds.Api;
using UnityEngine;

namespace AppBootstrap.Splash
{
    internal static class MediationTestMode
    {
        public static void EnableTestMode(params string[] testDevices)
        {
            EnableMetaTestMode(testDevices);
            EnableAdmobTestMode(testDevices);
        }

        private static void EnableAdmobTestMode(params string[] testDevices)
        {
            RequestConfiguration requestConfiguration = new RequestConfiguration
            {
                TestDeviceIds = testDevices.ToList()
            };
            MobileAds.SetRequestConfiguration(requestConfiguration);
            MobileAds.OpenAdInspector(Debug.LogError);
        }

        private static void EnableMetaTestMode(params string[] testDevices)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            using (var adSettings = new AndroidJavaClass("com.facebook.ads.AdSettings"))
            {
                adSettings.CallStatic("setTestMode", true);

                if (testDevices != null)
                {
                    foreach (var deviceHash in testDevices)
                    {
                        if (!string.IsNullOrWhiteSpace(deviceHash))
                        {
                            adSettings.CallStatic("addTestDevice", deviceHash);
                        }
                    }
                }
            }

            Debug.Log("Meta native test mode enabled.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Enable Meta native test mode failed: " + e);
        }
#endif
        }
    }
}