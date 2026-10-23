using System;
using System.Threading.Tasks;
using System.Windows;

namespace CommerX.Desktop;

public partial class MainWindow : Window
{
    private readonly DatabaseHealthCheck _healthCheck;

    public MainWindow(DatabaseHealthCheck healthCheck, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _healthCheck = healthCheck;
        BlazorView.Services = serviceProvider;
    }

    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        await CheckAsync();
    }

    private async void OnCheckConnection(object sender, RoutedEventArgs e)
    {
        await CheckAsync();
    }

    private async Task CheckAsync()
    {
        try
        {
            StatusText.Text = "Base de datos: comprobando...";
            var connected = await _healthCheck.CanConnectAsync();
            StatusText.Text = connected
                ? "Base de datos: conectada"
                : "Base de datos: sin conexión";
        }
        catch (Exception ex)
        {
            StatusText.Text = $"Error BD: {ex.Message}";
        }
    }
}