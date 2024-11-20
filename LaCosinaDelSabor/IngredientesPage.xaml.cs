using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LaCosinaDelSabor.Models;
using LaCosinaDelSabor.Services;

namespace LaCosinaDelSabor
{
    public partial class IngredientesPage : ContentPage
    {
        public IngredientesPage()
        {
            InitializeComponent();
            LoadIngredientes();
        }

        private async void LoadIngredientes()
        {
            List<Ingrediente> ingredientes = await App.Database.GetIngredientesAsync();
            IngredientesListView.ItemsSource = ingredientes;
        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ingrediente = new Ingrediente
                {
                    Nombre = txtNombre.Text,
                    Cantidad = int.Parse(txtCantidad.Text),
                    Unidad = txtUnidad.Text,
                    Origen = txtOrigen.Text,
                    Sostenibilidad = switchSostenible.IsToggled,
                    IdProveedor = 1244 // Usa un id_proveedor existente
                };

                await App.Database.SaveIngredienteAsync(ingrediente);
                await DisplayAlert("Éxito", "Ingrediente registrado correctamente.", "OK");
                LoadIngredientes();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
    }
}

