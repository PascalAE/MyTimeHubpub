using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyTimeHub.Models;

namespace MyTimeHub.Context
{
    public class MyTimeHubInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MyTimeHubDBContext>
    {
        protected override void Seed(MyTimeHubDBContext context)
        {
            var employees = new List<Employee>
            {
                new Employee{Name="Peter", Surname="Meier", Pensum=100, Saldo=0, IsActive=true},
                new Employee{Name="Sandra", Surname="Ulrich", Pensum=80, Saldo=0, IsActive=true},
                new Employee{Name="Max", Surname="Lindelöf", Pensum=60, Saldo=0, IsActive=true},
                new Employee{Name="Heinz", Surname="Müller", Pensum=100, Saldo=0, IsActive=true}
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer{Name="Interne Tätigkeiten", IsActive=true},
                new Customer{Name="Kunst AG", IsActive=true},
                new Customer{Name="Informatik AG", IsActive=true},
                new Customer{Name="Jakob Lüthi", IsActive=true}
            };

            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();

            var serviceTypes = new List<ServiceType>
            {
                new ServiceType{Name="Ferien", IsActive=true},
                new ServiceType{Name="Administratives", IsActive=true},
                new ServiceType{Name="Projektleitung", IsActive=true},
                new ServiceType{Name="Zeichnen", IsActive=true},
                new ServiceType{Name="Planen", IsActive=true},
                new ServiceType{Name="Kosntruktion", IsActive=true}
            };

            serviceTypes.ForEach(s => context.ServiceTypes.Add(s));
            context.SaveChanges();

            var bookings = new List<Booking>
            {
                new Booking
                {
                    Date=DateTime.Parse("2021-10-29"),
                    StartDate=DateTime.Parse("2021-10-29 08:00"),
                    EndDate=DateTime.Parse("2021-10-29 17:00"),
                    IsActive=true,
                    Description="Ferien",
                    EmployeeID=1,
                    CustomerID=1,
                    ServiceTypeID=1
                },
                new Booking
                {
                    Date=DateTime.Parse("2021-10-28"),
                    StartDate=DateTime.Parse("2021-10-28 08:00"),
                    EndDate=DateTime.Parse("2021-10-28 12:00"),
                    IsActive=true,
                    Description="Meeting durchgeführt",
                    EmployeeID=1,
                    CustomerID=2,
                    ServiceTypeID=3
                },
                new Booking
                {
                    Date=DateTime.Parse("2021-10-28"),
                    StartDate=DateTime.Parse("2021-10-28 13:00"),
                    EndDate=DateTime.Parse("2021-10-28 15:00"),
                    IsActive=true,
                    Description="Zeichnen",
                    EmployeeID=1,
                    CustomerID=2,
                    ServiceTypeID=4
                },
                new Booking
                {
                    Date=DateTime.Parse("2021-10-27"),
                    StartDate=DateTime.Parse("2021-10-27 15:00"),
                    EndDate=DateTime.Parse("2021-10-27 17:00"),
                    IsActive=true,
                    Description="Planungen",
                    EmployeeID=1,
                    CustomerID=3,
                    ServiceTypeID=5
                },
                //Heinz Ferien 01.11.2021 - 14.01.2021
                new Booking
                {
                    Date=DateTime.Parse("2021-11-01"),
                    StartDate=DateTime.Parse("2021-11-01 08:00"),
                    EndDate=DateTime.Parse("2021-11-01 16:00"),
                    IsActive=true,
                    Description="Ferien",
                    EmployeeID=4,
                    CustomerID=1,
                    ServiceTypeID=1
                },
                new Booking
                {
                    Date=DateTime.Parse("2021-11-02"),
                    StartDate=DateTime.Parse("2021-11-02 08:00"),
                    EndDate=DateTime.Parse("2021-11-02 16:00"),
                    IsActive=true,
                    Description="Ferien",
                    EmployeeID=4,
                    CustomerID=1,
                    ServiceTypeID=1
                },
                new Booking
                {
                    Date=DateTime.Parse("2021-11-03"),
                    StartDate=DateTime.Parse("2021-11-03 08:00"),
                    EndDate=DateTime.Parse("2021-11-03 16:00"),
                    IsActive=true,
                    Description="Ferien",
                    EmployeeID=4,
                    CustomerID=1,
                    ServiceTypeID=1
                },
                new Booking
                {
                    Date=DateTime.Parse("2021-11-04"),
                    StartDate=DateTime.Parse("2021-11-04 08:00"),
                    EndDate=DateTime.Parse("2021-11-04 16:00"),
                    IsActive=true,
                    Description="Ferien",
                    EmployeeID=4,
                    CustomerID=1,
                    ServiceTypeID=1
                },
                new Booking
                {
                    Date=DateTime.Parse("2021-11-05"),
                    StartDate=DateTime.Parse("2021-11-05 08:00"),
                    EndDate=DateTime.Parse("2021-11-05 16:00"),
                    IsActive=true,
                    Description="Ferien",
                    EmployeeID=4,
                    CustomerID=1,
                    ServiceTypeID=1
                },
                new Booking
                {
                    Date=DateTime.Parse("2021-11-08"),
                    StartDate=DateTime.Parse("2021-11-08 08:00"),
                    EndDate=DateTime.Parse("2021-11-08 16:00"),
                    IsActive=true,
                    Description="Ferien",
                    EmployeeID=4,
                    CustomerID=1,
                    ServiceTypeID=1
                },
                new Booking
                {
                    Date=DateTime.Parse("2021-11-09"),
                    StartDate=DateTime.Parse("2021-11-09 08:00"),
                    EndDate=DateTime.Parse("2021-11-09 16:00"),
                    IsActive=true,
                    Description="Ferien",
                    EmployeeID=4,
                    CustomerID=1,
                    ServiceTypeID=1
                },
                new Booking
                {
                    Date=DateTime.Parse("2021-11-10"),
                    StartDate=DateTime.Parse("2021-11-10 08:00"),
                    EndDate=DateTime.Parse("2021-11-10 16:00"),
                    IsActive=true,
                    Description="Ferien",
                    EmployeeID=4,
                    CustomerID=1,
                    ServiceTypeID=1
                },
                new Booking
                {
                    Date=DateTime.Parse("2021-11-11"),
                    StartDate=DateTime.Parse("2021-11-11 08:00"),
                    EndDate=DateTime.Parse("2021-11-11 16:00"),
                    IsActive=true,
                    Description="Ferien",
                    EmployeeID=4,
                    CustomerID=1,
                    ServiceTypeID=1
                },
                new Booking
                {
                    Date=DateTime.Parse("2021-11-12"),
                    StartDate=DateTime.Parse("2021-11-11 08:00"),
                    EndDate=DateTime.Parse("2021-11-11 16:00"),
                    IsActive=true,
                    Description="Ferien",
                    EmployeeID=4,
                    CustomerID=1,
                    ServiceTypeID=1
                }
            };

            bookings.ForEach(s => context.Bookings.Add(s));
            context.SaveChanges();

        }
    }
}