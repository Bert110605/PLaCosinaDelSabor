using Microsoft.Maui.Controls;
using LaCosinaDelSabor.Models;
using System;
using System.Linq;

namespace LaCosinaDelSabor
{
    public partial class EmpleadoPage : ContentPage
    {
        public EmpleadoPage()
        {
            InitializeComponent();
            InicializarCampos();
        }

        private void InicializarCampos()
        {
            txtCodigoEmpleado.Text = string.Empty;
            txtNombreEmpleado.Text = string.Empty;
            txtApellidoEmpleado.Text = string.Empty;
            txtPuestoEmpleado.Text = string.Empty;
            txtSalarioEmpleado.Text = string.Empty;
            datePickerFechaContratacion.Date = DateTime.Now;
        }

        private async void BtnAgregarEmpleado_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoEmpleado.Text) || string.IsNullOrWhiteSpace(txtNombreEmpleado.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoEmpleado.Text) || string.IsNullOrWhiteSpace(txtPuestoEmpleado.Text) ||
                string.IsNullOrWhiteSpace(txtSalarioEmpleado.Text))
            {
                await DisplayAlert("Error", "Todos los campos deben estar llenos.", "OK");
                return;
            }

            var empleadoExistente = await App.Database.GetEmpleadoByIdAsync(int.Parse(txtCodigoEmpleado.Text));

            if (empleadoExistente != null)
            {
                await DisplayAlert("Error", "El empleado ya existe.", "OK");
            }
            else
            {
                var nuevoEmpleado = new Empleado
                {
                    Id = int.Parse(txtCodigoEmpleado.Text),
                    Nombre = txtNombreEmpleado.Text,
                    Apellido = txtApellidoEmpleado.Text,
                    IdPuesto = int.Parse(txtPuestoEmpleado.Text),
                    SalarioMXN = int.Parse(txtSalarioEmpleado.Text),
                    FechaContratacion = datePickerFechaContratacion.Date
                };

                await App.Database.SaveEmpleadoAsync(nuevoEmpleado);
                await DisplayAlert("Éxito", "Empleado agregado exitosamente.", "OK");
            }
        }

        private async void BtnIngresarEmpleado_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoEmpleado.Text))
            {
                await DisplayAlert("Error", "Todos los campos deben estar llenos.", "OK");
                return;
            }

            var empleado = await App.Database.GetEmpleadoByIdAsync(int.Parse(txtCodigoEmpleado.Text));

            if (empleado != null)
            {
                await DisplayAlert("Éxito", "Empleado encontrado.", "OK");
            }
            else
            {
                await DisplayAlert("Error", "El empleado no existe.", "OK");
            }
        }

        private async void BtnEmpleadosAgregados_Clicked(object sender, EventArgs e)
        {
            var empleados = await App.Database.GetEmpleadosAsync();
            string listaEmpleados = string.Join("\n", empleados.Select(e => $"ID: {e.Id}, Nombre: {e.Nombre} {e.Apellido}, Puesto: {e.IdPuesto}, Salario: {e.SalarioMXN:C}, Fecha de Contratación: {e.FechaContratacion:dd/MM/yyyy}"));
            await DisplayAlert("Empleados Agregados", listaEmpleados, "OK");
        }
    }
}
