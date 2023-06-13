using System;
using System.Windows;
using DataAccessLibrary.Data;
using DataAccessLibrary.Models;

namespace CoralCoastResort.WPF;

public partial class CheckInWindow : Window
{
    private BookingsDto? _dto;
    private readonly IDatabaseData _db;
    
    public CheckInWindow(IDatabaseData db)
    {
        InitializeComponent();
        _db = db;
    }

    public void PopulateCheckInInfo(BookingsDto? dto)
    {
        _dto = dto;
        FirstNameText.Text = _dto!.FirstName;
        LastNameText.Text = _dto.LastName;
        TitleText.Text = _dto.Title;
        RoomNumberText.Text = _dto.RoomNumber;
        TotalCostText.Text = string.Format("{O:C}", _dto.TotalCost);
    }

    private void checkInUser_Click(object sender, RoutedEventArgs e)
    {
        _db.CheckInGuest(_dto!.Id);
        Close();
    }
}