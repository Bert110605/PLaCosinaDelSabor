using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LaCosinaDelSabor.Models;
using LaCosinaDelSabor.Services;

namespace LaCosinaDelSabor
{
    public partial class DesperdiciosPage : ContentPage
    {
        public DesperdiciosPage()
        {
            InitializeComponent();
            LoadDesperdicios();
        }

        private async void LoadDesperdicios()
        {
            List<Desperdicio> desperdicios = await App.Database.GetDesperdiciosAsync();
            DesperdiciosListView.ItemsSource = desperdicios;
        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var desperdicio = new Desperdicio
                {
                    IdPlato = int.Parse(txtIdPlato.Text), // Usar un id_plato existente
                    CantidadPlato = decimal.Parse(txtCantidadPlato.Text),
                    IdIngrediente = int.Parse(txtIdIngrediente.Text),
                    CantidadIngrediente = decimal.Parse(txtCantidadIngrediente.Text),
                    Unidad = txtUnidad.Text,
                    Motivo = txtMotivo.Text,
                    Fecha = datePicker.Date
                };

                // Asegúrate de que el IdPlato existe en la tabla `plato`
                var existingIdPlatos = new List<int> { 1234, 1282, 1283, 1284, 1285, 1286, 1287, 1288, 1289, 1290, 1291 };
                if (!existingIdPlatos.Contains(desperdicio.IdPlato))
                {
                    await DisplayAlert("Error", "El ID del Plato no existe.", "OK");
                    return;
                }

                await App.Database.SaveDesperdicioAsync(desperdicio);
                await DisplayAlert("Éxito", "Desperdicio registrado correctamente.", "OK");
                LoadDesperdicios();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
    }
}
