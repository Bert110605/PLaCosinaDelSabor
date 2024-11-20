using Microsoft.Maui.Controls;
using System;

namespace LaCosinaDelSabor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                await DisplayAlert("Error", "Touuudos los campos deben estar llenos.", "OK");
                return;
            }

            var administrador = await App.Database.GetAdministradorAsync(txtUsuario.Text, txtContrasena.Text);

            if (administrador != null)
            {
                await Navigation.PushAsync(new OpcionesPage());
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
            }
        }
    }
}
