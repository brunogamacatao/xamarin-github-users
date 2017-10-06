using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GithubUsers
{
    public partial class TesteListaPage : ContentPage
    {
        public TesteListaPage()
        {
            InitializeComponent();
        }

		void OnUsuarioSelected(object sender, SelectedItemChangedEventArgs e)
		{
            Navigation.PushModalAsync(new DetalheUsuario() {
                Usuario = (Usuario)e.SelectedItem
            });
		}

		async void OnCarregarClicked(object sender, System.EventArgs e)
        {
			var client = CriaHttpClient();

			string body = await client.GetStringAsync("http://api.github.com/users");
			var usuarios = JsonConvert.DeserializeObject<IEnumerable<Usuario>>(body);

			listaDeUsuarios.ItemsSource = usuarios;
		}

        private HttpClient CriaHttpClient()
		{
			HttpClient client = new HttpClient()
			{
				DefaultRequestHeaders = {
					UserAgent = { ProductInfoHeaderValue.Parse("Chrome") }
				}
			};

			client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

			return client;
		}

	}
}
