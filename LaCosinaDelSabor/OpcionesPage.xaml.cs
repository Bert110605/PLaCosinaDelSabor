using Microsoft.Maui.Controls;
using System;

namespace LaCosinaDelSabor
{
    public partial class OpcionesPage : ContentPage
    {
        public OpcionesPage()
        {
            InitializeComponent();
        }

        private async void BtnEmpleados_Clicked(object sender, EventArgs e)
        {
            // Navegar a la p�gina de empleados
            await Navigation.PushAsync(new EmpleadoPage());
        }

        private async void BtnMenu_Clicked(object sender, EventArgs e)
        {
            // Navegar a la p�gina del men�
            await Navigation.PushAsync(new MenuPage());
        }

        private async void BtnVerProveedores_Clicked(object sender, EventArgs e)
        {
            // Navegar a la p�gina de proveedores
            await Navigation.PushAsync(new ProveedoresPage());
        }

        private async void BtnVerIngredientes_Clicked(object sender, EventArgs e)
        {
            // Navegar a la p�gina de ingredientes
            await Navigation.PushAsync(new IngredientesPage());
        }

        private async void BtnVerDesperdicios_Clicked(object sender, EventArgs e)
        {
            // Navegar a la p�gina de desperdicios
            await Navigation.PushAsync(new DesperdiciosPage());
        }
    }
}
