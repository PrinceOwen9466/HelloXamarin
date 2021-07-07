using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hello.Extensions
{
    public static class UIExtensions
    {
        public static Color GetVisibleBackground(Color color)
        {
            Color backgroundColor = Color.Default; 
            
            if (color != Color.Default)
            {
                // Standard luminance calculation.
                double luminance = 0.30 * color.R + 0.59 * color.G + 0.11 * color.B; 
                backgroundColor = luminance > 0.5 ? Color.Black : Color.White;
            }

            return backgroundColor;
        }
    }
}

namespace Xamarin.Forms
{
    public static class DevicePlatform
    {
        private static T OnImpl<T>(T @default = default, T iOS = default, T Android = default, Func<T> computeCustom = null)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS: return iOS;

                case Device.Android: return Android;

                default:
                    if (computeCustom == null) return @default;
                    return computeCustom.Invoke();
            }
        }

        public static T On<T>(T @default = default, T iOS = default, T Android = default) => OnImpl(@default, iOS, Android, null);

        public static T On<T>(T @default = default, T iOS = default, T Android = default, (string Platform, T Value) custom = default)
        {
            string runtimePlatform = Device.RuntimePlatform;

            return OnImpl(@default, iOS, Android, () =>
            {
                if (custom.Platform == runtimePlatform)
                    return custom.Value;

                return @default;
            });
        }

        public static T On<T>(T @default = default, T iOS = default, T Android = default, (string Platform, T Value) custom = default, (string Platform, T Value) custom2 = default)
        {
            string runtimePlatform = Device.RuntimePlatform;

            return OnImpl(@default, iOS, Android, () =>
            {
                if (custom.Platform == runtimePlatform)
                    return custom.Value;
                else if (custom2.Platform == runtimePlatform)
                    return custom2.Value;

                return @default;
            });
        }

        public static T On<T>(T @default = default, T iOS = default, T Android = default, (string Platform, T Value) custom = default, (string Platform, T Value) custom2 = default, (string Platform, T Value) custom3 = default)
        {
            string runtimePlatform = Device.RuntimePlatform;

            return OnImpl(@default, iOS, Android, () =>
            {
                if (custom.Platform == runtimePlatform)
                    return custom.Value;
                else if (custom2.Platform == runtimePlatform)
                    return custom2.Value;
                else if (custom3.Platform == runtimePlatform)
                    return custom3.Value;

                return @default;
            });
        }

        public static T On<T>(T @default = default, T iOS = default, T Android = default, (string Platform, T Value) custom = default, (string Platform, T Value) custom2 = default, (string Platform, T Value) custom3 = default, (string Platform, T Value) custom4 = default)
        {
            string runtimePlatform = Device.RuntimePlatform;

            return OnImpl(@default, iOS, Android, () =>
            {
                if (custom.Platform == runtimePlatform)
                    return custom.Value;
                else if (custom2.Platform == runtimePlatform)
                    return custom2.Value;
                else if (custom3.Platform == runtimePlatform)
                    return custom3.Value;
                else if (custom4.Platform == runtimePlatform)
                    return custom4.Value;

                return @default;
            });
        }

        public static T On<T>(T @default = default, T iOS = default, T Android = default, params (string Platform, T Value)[] customPlatforms)
        {
            string runtimePlatform = Device.RuntimePlatform;

            return OnImpl(@default, iOS, Android, () =>
            {
                for (int i = 0; i < customPlatforms.Length; i++)
                {
                    var platform = customPlatforms[i];
                    if (platform.Platform == runtimePlatform)
                        return platform.Value;
                }

                return @default;
            });
        }
    }
}
