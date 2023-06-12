using System.Collections.Generic;
using System.Windows;
using DataAccessLibrary.Data;
using DataAccessLibrary.Models;

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

    private void SearchForGuest_OnClick(object sender, RoutedEventArgs e)
    {
        List<BookingsDto> bookings = _db.SearchBookings(FirstNameText.Text);
        ResultsList.ItemsSource = bookings;
    }
}
