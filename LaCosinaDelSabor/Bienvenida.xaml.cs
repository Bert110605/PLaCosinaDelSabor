using Microsoft.Maui.Controls;
using System;

namespace LaCosinaDelSabor
{
    public partial class BienvenidaPage : ContentPage
    {
        public BienvenidaPage()
        {
            InitializeComponent();
        }

        private async void BtnContinuar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
