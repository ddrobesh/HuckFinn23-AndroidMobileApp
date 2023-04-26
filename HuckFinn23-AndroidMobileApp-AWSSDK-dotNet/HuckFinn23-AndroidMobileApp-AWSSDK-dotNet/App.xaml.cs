using System;
using HuckFinn23AndroidMobileAppAWSSDKdotNet;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/**
 * These code and artifact files are intended for demo, learning,
 * discussion, training, and non-commercial purposes ONLY. They
 * may not be intended for Production use while in partial
 * form, but production use for non-commercial demo/learning
 * purposes are encouraged and not disallowed.
 * Without the explicit, written concept of both author and owner,
 * any modifications and/or re-distributions of the framework,
 * code, or file systems is explicitly forbidden. Modifications
 * are allowed for local, learning purposes.
 * Re-distributions or reuse for commercial for-profit
 * purposes are explicitly forbidden.
 *
 * Copyright 2019-2023 All Rights Reserved, David D Drobesh,
 * and 8814 Bothell Properties LLC, and Level8 Partnerships,
 * respectively.
 */

namespace HuckFinn23_AndroidMobileApp_AWSSDK_dotNet
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            // Huck Finn: main start here my cross-pltform App with Xamarin, .NET Standard(Android, iPhone), AWS

            //default: MainPage = new MainPage();
            // ... AWS: Huck Finn using dynamic binding pub/sub to refresh upon fetch
            //      remote DynamoDB Data. Therefore, bind the View and Model context.
            MainPage = new MainPage() { BindingContext = new MainPageViewModel() };
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

