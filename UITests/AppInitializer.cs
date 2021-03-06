﻿using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp(packageName: "RPN.RPN").StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}