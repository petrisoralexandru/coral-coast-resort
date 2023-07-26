<img src="https://github.com/petrisoralexandru/coral-coast-resort/assets/34144926/b3151f9b-98cd-47d7-8b89-7acd73b88460" width="700" height="700">

# Coral Coast - Discover the Perfect Blend of Luxury and Convenience
- Coral Coast Resort is a minimum viable and open-source project, which aims to provide a system specifically designed for a fictitious hotel. The main objective was to offer a solution that enables visitors to reserve a room that's available in a specified date interval and check-in at the hotel reception.

## Features
- User-friendly interface for guests to browse and reserve available hotel rooms.
- Seamless guest registration process to streamline check-in operations.
- Efficient room reservation system with date-based availability.
- Desktop application for staff members to perform quick check-ins.

## How the application works
### Booking a hotel room
- Start by visiting the page for booking a hotel room
- Specify the desired date range with the help of datepicker calendar
- Select the type of room you want using the "Book Now" button, according to your personal preferences
- Fill in your first name and last name
- Book the room using the "Book" button

![Booking a hotel room](https://github.com/petrisoralexandru/coral-coast-resort/assets/34144926/1d939847-57b5-4d1e-a163-a94fa84fedd2)

### Check-in a guest
- Open the Check-In application
- Search for the guest by first name
- Select the corresponding reservation assigned to the guest
- Confirm the room rental via the "Check-in" button 

![Check-in a guest](https://github.com/petrisoralexandru/coral-coast-resort/assets/34144926/ecec2bf3-3b5f-44f3-ac86-4a1cc846e89c)


## Application layers
| Name                                     | Platform |
|------------------------------------------|---------- |
| **DataAccessLibrary**<br />Is responsible for handling the interaction between the application and the underlying database. It serves as a bridge between the business logic and the database, providing a seamless way to retrieve and manipulate data. | ![NET7](https://img.shields.io/badge/.NET-7.0-purple) |
| **CoralCoastResort.Web**<br />Is the website user interface, built using ASP.NET Razor Pages. Guests can browse and interact with the hotel's available rooms and make reservations. | ![NET7](https://img.shields.io/badge/.NET-7.0-purple) |
| **CoralCoastResort.WPF**<br />It provides a desktop application for the resort's staff to efficiently perform guest check-ins. The application allows receptionists to search for visitors by name, view their reservations for the current day, and confirm the booking. | ![NET7](https://img.shields.io/badge/.NET-7.0-purple) |

## Packages
### DataAccessLibrary
| Name                                     | Released Package |
|------------------------------------------|------------------|
| **Dapper**                                 | [![Dapper Badge](https://img.shields.io/nuget/v/Dapper?color=purple)](https://www.nuget.org/packages/Dapper) |
| **Microsoft.Extensions.Configuration.Abstractions**                                 | [![SqlClient Badge](https://img.shields.io/nuget/v/Microsoft.Extensions.Configuration.Abstractions?color=purple)](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Abstractions) |
| **System.Data.SqlClient**                                 | [![System.Data.SqlClient Badge](https://img.shields.io/nuget/v/System.Data.SqlClient?color=purple)](https://www.nuget.org/packages/System.Data.SqlClient) |

### CoralCoastResort.WPF

| Name                                     | Released Package |
|------------------------------------------|------------------|
| **Microsoft.Extensions.Configuration.Binder**                                 | [![Microsoft.Extensions.Configuration.Binder Badge](https://img.shields.io/nuget/v/Microsoft.Extensions.Configuration.Binder?color=purple)](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder) |
| **Microsoft.Extensions.Configuration.Json**                                 | [![Microsoft.Extensions.Configuration.Json Badge](https://img.shields.io/nuget/v/Microsoft.Extensions.Configuration.Json?color=purple)](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json) |
| **Microsoft.Extensions.DependencyInjection**                                 | [![Microsoft.Extensions.DependencyInjection Badge](https://img.shields.io/nuget/v/Microsoft.Extensions.DependencyInjection?color=purple)](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) |
| **Microsoft.Extensions.Hosting**                                 | [![Microsoft.Extensions.Hosting Badge](https://img.shields.io/nuget/v/Microsoft.Extensions.Hosting?color=purple)](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) |


## Questions or Suggestions
If you have any questions or suggestions about LockGen, please open an [issue](https://github.com/petrisoralexandru/coral-coast-resort/issues) in this repository. I'll be happy to help you or get your constructive feedback.

## License
This project is licensed under the [MIT license](https://github.com/petrisoralexandru/coral-coast-resort/blob/main/LICENSE). Please cite this source and abide by the license terms when using this project.
