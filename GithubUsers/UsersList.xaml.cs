using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Net.Http;

using GithubUsers.Data;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace GithubUsers
{
    public partial class UsersList : ContentPage
    {
        public IEnumerable<GithubUser> Users {
            get; 
            set;
        }

        public UsersList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            OnLoadUsersClick(null, null);
        }

        async void OnLoadUsersClick(object sender, System.EventArgs e)
        {
			var client = CriaHttpClient();

			string body = await client.GetStringAsync("http://api.github.com/users");
			var users = JsonConvert.DeserializeObject<IEnumerable<GithubUser>>(body);

			listaDeUsuarios.ItemsSource = users;
		}

		private HttpClient CriaHttpClient()
		{
			HttpClient client = new HttpClient()
			{
				DefaultRequestHeaders = {
					UserAgent = { ProductInfoHeaderValue.Parse("Chrome") }
				}
			};

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return client;
		}

        void OnUserSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushModalAsync(new UserDetail() { User = (GithubUser)e.SelectedItem });
        }
    }
}
