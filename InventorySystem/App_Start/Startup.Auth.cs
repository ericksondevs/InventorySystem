﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
namespace InventorySystem
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864   
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user   
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider   
            // Configure the sign in cookie   
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login/Login"),
                LogoutPath = new PathString("/Login/LogOff"),
                ExpireTimeSpan = TimeSpan.FromMinutes(5.0)
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            // Uncomment the following lines to enable logging in with third party login providers   
            //app.UseMicrosoftAccountAuthentication(   
            // clientId: "",   
            // clientSecret: "");   
            //app.UseTwitterAuthentication(   
            // consumerKey: "",   
            // consumerSecret: "");   
            //app.UseFacebookAuthentication(   
            // appId: "",   
            // appSecret: "");   
            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()   
            //{   
            // ClientId = "",   
            // ClientSecret = ""   
            //});   
        }
    }
}