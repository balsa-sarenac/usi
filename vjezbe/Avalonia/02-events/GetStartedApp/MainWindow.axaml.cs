using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GetStartedApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // Pronadjemo dugme, pa mu dodamo handler za događaj klika
        var button = this.FindControl<Button>("CodeBehindButton");
        if (button is not null)
        {
            button.Click += CodeBehindButton_Click;
        }

    }
    
    private void XamlButton_Click(object? sender, RoutedEventArgs e)
    {
        Title = "Kliknuto preko XAML-a!";
    }

    private void CodeBehindButton_Click(object? sender, RoutedEventArgs e)
    {
        Title = "Kliknuto preko code-behind-a!";
    }
}

