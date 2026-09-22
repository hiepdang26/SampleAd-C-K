using System;
using BG_Library.Common;

namespace BG_Library.NET
{
    public static partial class NetEventSystem
    {
        public static Action<AdInfo> OnRectRequest;
        public static Action<AdInfo> OnRectLoaded;
        public static Action<AdInfo, int, string> OnRectLoadFailed;
        public static Action<AdInfo, bool> OnRectViewActivated;
        public static Action<AdInfo> OnRectDisplayed;
        public static Action<AdInfo> OnRectHidden;
        public static Action<AdInfo> OnRectClicked;
        public static Action<AdInfo, AdValueInfo> OnRectPaid;
    }
}
