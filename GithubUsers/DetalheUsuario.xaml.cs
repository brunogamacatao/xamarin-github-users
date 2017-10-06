using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GithubUsers
{
    public partial class DetalheUsuario : ContentPage
    {
        private Usuario usuario;

        public DetalheUsuario()
        {
            InitializeComponent();
        }

        public Usuario Usuario 
        {
            get { return usuario; }
            set {
                usuario = value;
                foto.Source = usuario.avatar_url;
                nome.Text = usuario.login;
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
