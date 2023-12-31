﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dloyaS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertar : ContentPage
    {
        private string URL = "http://10.2.14.154/clinica/post.php";

        public Insertar()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                var datos = new System.Collections.Specialized.NameValueCollection();
                datos.Add("codigo", txtCodigo.Text);
                datos.Add("nombre", txtNombre.Text);
                datos.Add("apellido", txtApellido.Text);
                datos.Add("edad", txtEdad.Text);
                client.UploadValues(URL, "POST", datos);
                //DisplayAlert("OK", "Estudiante Ingresado", "Cerrar");
                var mensaje = "Estudiante Ingresado";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Cerrar");
            }


        }
    }
}