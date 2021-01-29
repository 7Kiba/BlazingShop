using BlazorApp1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class AppointmentService
    {
        private readonly ApplicationDbContext _dbContext;
        public AppointmentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateAppointment(Appointment appointment)
        {
            appointment.ProductId = appointment.Product.Id;
            appointment.Product = null;

            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
