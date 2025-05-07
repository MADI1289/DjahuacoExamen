using Microsoft.Maui.Controls;
using System;

namespace DjahuacoExamen.Views
{
    public partial class ResumenPage : ContentPage
    {
        private string usuarioConectado;

        public ResumenPage(ResumenDatos datos)
        {
            InitializeComponent();

            usuarioConectado = datos.UsuarioConectado;
            UsuarioConectadoLabel.Text = $"Usuario conectado: {usuarioConectado}";

            NombreLabel.Text = datos.Nombre;
            ApellidoLabel.Text = datos.Apellido;
            VALabel.Text = datos.VA;
            FechaLabel.Text = datos.Fecha.ToString("dd/MM/yyyy");
            CiudadLabel.Text = datos.Ciudad;
            MontoInicialLabel.Text = datos.MontoInicial.ToString("F2");
            CuotaMensualLabel.Text = datos.CuotaMensual.ToString("F2");
            PagoTotalLabel.Text = datos.PagoTotal.ToString("F2");
        }

        private async void OnCerrarSesionClicked(object sender, EventArgs e)
        {
            // Regresar a LoginPage (cerrar sesión)
            await Navigation.PopToRootAsync();
        }
    }
}
