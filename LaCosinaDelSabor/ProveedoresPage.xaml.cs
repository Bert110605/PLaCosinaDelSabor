using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LaCosinaDelSabor.Models;

namespace LaCosinaDelSabor
{
    public partial class ProveedoresPage : ContentPage
    {
        public ProveedoresPage()
        {
            InitializeComponent();
            LoadProveedores();
        }

        private async void LoadProveedores()
        {
            List<Proveedor> proveedores = await App.Database.GetProveedoresAsync();
            ProveedoresListView.ItemsSource = proveedores;
        }
    }
}
