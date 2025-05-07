using Microsoft.Maui.Controls;

namespace DjahuacoExamen.Views
{
    public partial class LoginPage : ContentPage
    {
        Dictionary<string, string> usuarios = new()
        {
            { "estudiante2025", "moviles" },
            { "uisrael", "2025" },
            { "sistemas", "2025_1" }
        };

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string? user = UsuarioEntry.Text?.Trim();
            string? pass = ContrasenaEntry.Text?.Trim();

            if (usuarios.TryGetValue(user, out string storedPass) && storedPass == pass)
            {
                
                await Navigation.PushAsync(new RegistroPage(user));
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }
        }

        private async void OnAcercaDeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AcercaDePage(UsuarioEntry.Text));
        }
    }
}
