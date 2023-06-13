using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CoralCoastResort.WPF;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IDatabaseData _db;
    private readonly CheckInWindow _checkInWindow;

    public MainWindow(IDatabaseData db, CheckInWindow checkInWindow)
    {
        InitializeComponent();
        _db = db;
        _checkInWindow = checkInWindow;
    }

    private void SearchForGuest_OnClick(object sender, RoutedEventArgs e)
    {
        List<BookingsDto> bookings = _db.SearchBookings(FirstNameText.Text);
        ResultsList.ItemsSource = bookings;
    }

    private void CheckIn_OnClick(object sender, RoutedEventArgs e)
    {
        var checkInWindow = App.AppHost!.Services.GetService<CheckInWindow>();
        var dto = (BookingsDto)((Button)e.Source).DataContext;
        
        checkInWindow.PopulateCheckInInfo(dto);
        
        checkInWindow!.Show();
    }
}
