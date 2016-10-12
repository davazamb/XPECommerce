using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XPECommerce.Classes;

namespace XPECommerce.Pages
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            Padding = Device.OnPlatform(
            new Thickness(10, 20, 10, 10),
            new Thickness(10),
            new Thickness(10));

            loginButton.Clicked += LoginButton_Clicked;
            
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(userEntry.Text))
            {
                await DisplayAlert("Error", "You must enter an email", "Acept");
                return;
            }
            if (string.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("Error", "You must enter an password", "Acept");
                return;
            }
            Login(userEntry.Text, passwordEntry.Text);
        }

        private async void Login(string email, string password)
        {
            waitActivityIndicator.IsRunning = true;

            var loginRequest = new LoginRequest
            {
                Email = userEntry.Text,
                Password = passwordEntry.Text,
            };

            var result = string.Empty;

            try
            {
                var jsonRequest = JsonConvert.SerializeObject(loginRequest);
                var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://tzecommerce.diskcode.info");
                var url = "/api/Users/Login";
                var response = await client.PostAsync(url, httpContent);

                if (!response.IsSuccessStatusCode)
                {
                    waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Error", "Wrong user or password ", "Acept");
                    passwordEntry.Text = string.Empty;
                    passwordEntry.Focus();
                    return;
                }

                result = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Error", ex.Message, "Acept");
                return;
            }

            var userResponse = JsonConvert.DeserializeObject<UserResponse>(result);
            userResponse.Password = password;
            waitActivityIndicator.IsRunning = false;
            await Navigation.PushAsync(new MainPage(userResponse));

        }

    }
}
