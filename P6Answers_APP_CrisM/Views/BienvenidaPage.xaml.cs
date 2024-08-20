using Newtonsoft.Json;
using P6Answers_APP_CrisM.Models;
using P6Answers_APP_CrisM.ViewModels;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace P6Answers_APP_CrisM.Views;

public partial class BienvenidaPage : ContentPage
{
    public BienvenidaPage()
	{
		InitializeComponent();
    }

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        string username = TxtUserName.Text;
        string password = TxtPassword.Text;

        var isValidUser = await ValidateUserAsync(username, password);

        if (isValidUser)
        {
            await DisplayAlert("Inicio de sesión", "Inicio de sesión exitoso", "OK");
            // Navegar a PreguntaPage
            await Navigation.PushAsync(new PreguntaPage());
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
        }

        //if (username == "Cris" && password == "1234"  )
        //{
        //    await DisplayAlert("Inicio de sesión", "Inicio de sesión exitoso", "OK");
        //    //Navegar a PreguntaPage
        //    await Navigation.PushAsync(new PreguntaPage());
        //}   
    }

    private async Task<bool> ValidateUserAsync(string email, string password)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://192.168.100.9:45455/api/");
            var loginRequest = new
            {
                Email = email,
                Password = password
            };

            var jsonContent = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Users/ValidateUser", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(jsonResponse);
                // Aquí puedes manejar la información del usuario, por ejemplo, almacenarla para uso posterior.
                return true;
            }

            return false;
        }
    }
}