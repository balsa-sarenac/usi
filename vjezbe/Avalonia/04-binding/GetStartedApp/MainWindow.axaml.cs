using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GetStartedApp;

public partial class MainWindow : Window
{
    public BindingDemoViewModel ViewModel { get; } = new();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = ViewModel;
    }
    
    private void SetTest1_Click(object? sender, RoutedEventArgs e)
    {
        ViewModel.Test1 = $"Test1: {DateTime.Now:HH:mm:ss}";
    }
    
    private void AddItem_Click(object? sender, RoutedEventArgs e)
    {
        ViewModel.AddItem();
    }
}