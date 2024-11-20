using Microsoft.Maui.Controls;
using LaCosinaDelSabor.Models;
using System;
using System.Linq;

namespace LaCosinaDelSabor
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private async void BtnAgregarPlato_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdPlato.Text) || string.IsNullOrWhiteSpace(txtNombrePlato.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioPlato.Text) || string.IsNullOrWhiteSpace(txtValorNutricional.Text) ||
                string.IsNullOrWhiteSpace(txtIdCategoria.Text))
            {
                await DisplayAlert("Error", "Todos los campos deben estar llenos.", "OK");
                return;
            }

            var nuevoPlato = new Plato
            {
                IdPlato = int.Parse(txtIdPlato.Text),
                Nombre = txtNombrePlato.Text,
                Precio = decimal.Parse(txtPrecioPlato.Text),
                ValorNutricional = txtValorNutricional.Text,
                IdCategoria = int.Parse(txtIdCategoria.Text)
            };

            await App.Database.SavePlatoAsync(nuevoPlato);
            await DisplayAlert("Éxito", "Plato agregado exitosamente.", "OK");
        }

        private async void BtnVerPlatillos_Clicked(object sender, EventArgs e)
        {
            var platillos = await App.Database.GetPlatillosAsync();
            string listaPlatillos = string.Join("\n", platillos.Select(p => $"ID: {p.IdPlato}, Nombre: {p.Nombre}, Precio: {p.Precio:C}, Valor Nutricional: {p.ValorNutricional}, Categoría: {p.IdCategoria}"));
            await DisplayAlert("Platillos", listaPlatillos, "OK");
        }
    }
}
