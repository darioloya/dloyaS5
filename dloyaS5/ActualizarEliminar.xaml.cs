using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dloyaS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarEliminar : ContentPage
    {
        private string URL = "http://192.168.100.135/clinica/post.php";

        public ActualizarEliminar(Estudiante datos)
        {
            InitializeComponent();
            txtCodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre.ToString();
            txtApellido.Text = datos.apellido.ToString();
            txtEdad.Text = datos.edad.ToString();
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                client.UploadValues(
                    URL + "?codigo=" + txtCodigo.Text,
                    "DELETE",
                    new NameValueCollection()
                );
                DisplayAlert("OK", "Estudiante Eliminado", "Cerrar");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                client.UploadValues(
                    URL + "?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text,
                    "PUT",
                    new NameValueCollection()
                );
                DisplayAlert("OK", "Estudiante Actualizado", "Cerrar");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }
    }
}