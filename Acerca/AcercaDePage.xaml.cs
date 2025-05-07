using Microsoft.Maui.Controls;

namespace DjahuacoExamen.Views
{
    public partial class AcercaDePage : ContentPage
    {
        public AcercaDePage(string usuarioConectado)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(usuarioConectado))
                UsuarioConectadoLabel.Text = $"Usuario conectado: {usuarioConectado}";
            else
                UsuarioConectadoLabel.Text = "Usuario no conectado";
        }
    }
}
