using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using dloyaS5.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly:Xamarin.Forms.Dependency(typeof(MensajeAlert))]
namespace dloyaS5.Droid
{
    public class MensajeAlert : Mensaje
    {
        public void longAlert(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Long).Show();
        }

        public void showAlet(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show();
        }
    }
}