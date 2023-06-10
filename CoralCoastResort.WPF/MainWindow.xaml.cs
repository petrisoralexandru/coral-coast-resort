using System.Windows;
using DataAccessLibrary.Data;

namespace CoralCoastResort.WPF;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IDatabaseData _db;
    
    public MainWindow(IDatabaseData db)
    {
        InitializeComponent();
        _db = db;
    }
}
