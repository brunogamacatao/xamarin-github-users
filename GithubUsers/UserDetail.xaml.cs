using System;
using System.Collections.Generic;

using Xamarin.Forms;
using GithubUsers.Data;

namespace GithubUsers
{
    public partial class UserDetail : ContentPage
    {
        private GithubUser user;

        public UserDetail()
        {
            InitializeComponent();
        }

        public GithubUser User {
            get { return user;  }
            set {
                user = value;

				avatar.Source = user.avatar_url;
				login.Text = user.login;
            }
        }

        void OnBackClicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }

    }
}
