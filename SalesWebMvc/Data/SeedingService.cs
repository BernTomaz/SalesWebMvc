using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums; // <— ADICIONE ESTE
using System;
using System.Linq;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private readonly SalesWebMvcContext _context;
        public SeedingService(SalesWebMvcContext context) => _context = context;

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
                return; // já populado

            var d1 = new Department { Name = "Computers" };
            var d2 = new Department { Name = "Electronics" };
            var d3 = new Department { Name = "Fashion" };

            var s1 = new Seller { Name = "Bob Brown", Email = "bob@test.com", BirthDate = new DateTime(1990, 1, 1), BaseSalary = 1200.0, Department = d1 };
            var s2 = new Seller { Name = "Maria Green", Email = "maria@test.com", BirthDate = new DateTime(1988, 5, 10), BaseSalary = 1500.0, Department = d2 };

            var r1 = new SalesRecord { Date = DateTime.Today.AddDays(-10), Amount = 1100.0, Status = SalesStatus.Billed, Seller = s1 };
            var r2 = new SalesRecord { Date = DateTime.Today.AddDays(-5), Amount = 800.0, Status = SalesStatus.Pending, Seller = s2 };

            _context.AddRange(d1, d2, d3, s1, s2, r1, r2);
            _context.SaveChanges();
        }
    }
}
