using SalesWebMvc.Models;
using System;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;


namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;
        public DepartmentService(SalesWebMvcContext context) => _context = context;

        public async Task<List<Department>> FindAllAsync()
            => await _context.Department.OrderBy(d => d.Name).ToListAsync();
    }
}

