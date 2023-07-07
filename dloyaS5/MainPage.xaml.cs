using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Newtonsoft.Json;

namespace dloyaS5
{
    public partial class MainPage : ContentPage
    {
        private string URL = "http://10.2.14.154/clinica/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Estudiante> post;


        public MainPage()
        {
            InitializeComponent();
            Obtener();
        }

        public async void Obtener()
        {
            var contenido = await client.GetStringAsync(URL);
            List<Estudiante> datosPost = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);
            post = new ObservableCollection<Estudiante>(datosPost);
            ListaEstudiantes.ItemsSource = post;
        }

        private async void btnConsulta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Insertar());
        }

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Estudiante)e.SelectedItem;
            Navigation.PushAsync(new ActualizarEliminar(objetoEstudiante));
        }

        private void btnRefrescar_Clicked(object sender, EventArgs e)
        {
            Obtener();
        }
    }
}
