using System;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CommerX.Desktop;

public partial class App : System.Windows.Application
{
    private readonly IHost _host;

    public App()
    {
    
        DispatcherUnhandledException += OnDispatcherUnhandledException;
     
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

        _host = Host.CreateDefaultBuilder()
            .UseContentRoot(AppContext.BaseDirectory)
            .ConfigureServices((context, services) =>
            {
                services.AddCommerX(context.Configuration);
                services.AddWpfBlazorWebView();
                services.AddSingleton<MainWindow>();
            })
            .Build();
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show($"Excepción de UI:\n{e.Exception.Message}\n\nDetalles:\n{e.Exception}", "Error en tiempo de ejecución", MessageBoxButton.OK, MessageBoxImage.Error);
        e.Handled = true; 
    }

    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception ex)
        {
            MessageBox.Show($"Excepción de fondo:\n{ex.Message}\n\nDetalles:\n{ex}", "Error crítico", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        try
        {
            await _host.StartAsync();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al iniciar MainWindow:\n{ex.Message}\n\nDetalle:\n{ex}", "Error de Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
        base.OnExit(e);
    }
}