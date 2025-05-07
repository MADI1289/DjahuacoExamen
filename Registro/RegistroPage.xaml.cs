using DjahuacoExamen.Views;
using Microsoft.Maui.Controls;
using System;

 namespace DjahuacoExamen.Views
{
    public partial class RegistroPage : ContentPage
    {
        private string usuarioConectado;
        private const double costoUPS = 300;

        public RegistroPage(string usuario)
        {
            InitializeComponent();

            usuarioConectado = usuario;
            UsuarioConectadoLabel.Text = $"Usuario conectado: {usuarioConectado}";

            // Llenar Picker VA
            VaPicker.ItemsSource = new string[] { "VA1", "VA2", "VA3" };

            // Llenar Picker Ciudad
            CiudadPicker.ItemsSource = new string[] { "Ciudad A", "Ciudad B", "Ciudad C" };

            // Por defecto monto inicial 15% de 300
            MontoInicialEntry.Text = (costoUPS * 0.15).ToString("F2");
            CuotaMensualEntry.Text = "";
        }

        private void OnCalcularClicked(object sender, EventArgs e)
        {
            if (!double.TryParse(MontoInicialEntry.Text, out double montoInicial))
            {
                DisplayAlert("Error", "Monto inicial inválido", "OK");
                return;
            }

            // Validar monto inicial mínimo 15% de 300 = 45
            double minimoInicial = costoUPS * 0.15;
            if (montoInicial < minimoInicial)
            {
                DisplayAlert("Error", $"Monto inicial mínimo es {minimoInicial:F2}", "OK");
                return;
            }

            // Calcular resto y cuota mensual
            double resto = costoUPS - montoInicial;
            double cuotaBase = resto / 3;
            double cuotaMensual = cuotaBase + (costoUPS * 0.05);

            CuotaMensualEntry.Text = cuotaMensual.ToString("F2");
        }

        private async void OnVerResumenClicked(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(NombreEntry.Text) ||
                string.IsNullOrWhiteSpace(ApellidoEntry.Text) ||
                VaPicker.SelectedIndex == -1 ||
                CiudadPicker.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(MontoInicialEntry.Text) ||
                string.IsNullOrWhiteSpace(CuotaMensualEntry.Text))
            {
                await DisplayAlert("Error", "Por favor complete todos los campos y calcule la cuota mensual", "OK");
                return;
            }

            // Crear objeto con datos para enviar a ResumenPage
            var datos = new ResumenDatos
            {
                UsuarioConectado = usuarioConectado,
                Nombre = NombreEntry.Text,
                Apellido = ApellidoEntry.Text,
                VA = VaPicker.SelectedItem.ToString(),
                Fecha = FechaPicker.Date,
                Ciudad = CiudadPicker.SelectedItem.ToString(),
                MontoInicial = double.Parse(MontoInicialEntry.Text),
                CuotaMensual = double.Parse(CuotaMensualEntry.Text),
                PagoTotal = double.Parse(MontoInicialEntry.Text) + 3 * double.Parse(CuotaMensualEntry.Text)
            };

            // Navegar a ResumenPage
            await Navigation.PushAsync(new ResumenPage(datos));
        }
    }

    // Clase para pasar datos a ResumenPage
    public class ResumenDatos
    {
        public string? UsuarioConectado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public required string VA { get; set; }
        public DateTime Fecha { get; set; }
        public required string Ciudad { get; set; }
        public double MontoInicial { get; set; }
        public double CuotaMensual { get; set; }
        public double PagoTotal { get; set; }
    }
}
