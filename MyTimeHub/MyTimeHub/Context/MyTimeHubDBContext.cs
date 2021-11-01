using MyTimeHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyTimeHub.Context
{
    public class MyTimeHubDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}