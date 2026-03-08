using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GetStartedApp;

public class BindingDemoViewModel : INotifyPropertyChanged
{
    private string _test1 = "Pocetna vrednost";
    public string Test1
    {
        get => _test1;
        set
        {
            if (_test1 == value) return;
            _test1 = value;
            OnPropertyChanged();
        }
    }
    private string _test2 = "Edituj me";
    public string Test2
    {
        get => _test2;
        set
        {
            if (_test2 == value) return;
            _test2 = value;
            OnPropertyChanged();
        }
    }
    private string _onlySource = "";
    public string OnlySource
    {
        get => _onlySource;
        set
        {
            if (_onlySource == value) return;
            _onlySource = value;
            OnPropertyChanged();
        }
    }
    
    private string _immediateText = "";
    public string ImmediateText
    {
        get => _immediateText;
        set
        {
            if (_immediateText == value) return;
            _immediateText = value;
            OnPropertyChanged();
        }
    }
    private string _lostFocusText = "";
    public string LostFocusText
    {
        get => _lostFocusText;
        set
        {
            if (_lostFocusText == value) return;
            _lostFocusText = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<string> Test3 { get; } = new()
    {
        "Audi",
        "BMW",
        "Opel",
    };
    private string? _selectedTest3;
    public string? SelectedTest3
    {
        get => _selectedTest3;
        set
        {
            if (_selectedTest3 == value) return;
            _selectedTest3 = value;
            OnPropertyChanged();
        }
    }
    private int _itemCounter = 1;
    public void AddItem() => Test3.Add($"Item {_itemCounter++}");
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
}