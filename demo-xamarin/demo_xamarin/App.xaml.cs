﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace demo_xamarin
{
    public partial class App : Application
    {
        public Page currentDetail;
        public App()
        {
            InitializeComponent();
            MainPage = new demo_xamarin.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
