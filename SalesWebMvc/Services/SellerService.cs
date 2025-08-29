using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        // LISTAR TODOS
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller
                .Include(s => s.Department) // opcional
                .ToListAsync();
        }

        // INSERIR
        public async Task InsertAsync(Seller obj)
        {
            // Se vier só o DepartmentId, garante o tracking do EF
            if (obj.Department == null && obj.DepartmentId != 0)
            {
                var dep = await _context.Department.FindAsync(obj.DepartmentId);
                if (dep != null) obj.Department = dep;
            }

            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        // BUSCAR POR ID
        public async Task<Seller?> FindByIdAsync(int id)
        {
            return await _context.Seller
                .Include(s => s.Department)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // ATUALIZAR
        public async Task UpdateAsync(Seller obj)
        {
            var exists = await _context.Seller.AnyAsync(s => s.Id == obj.Id);
            if (!exists)
                throw new NotFoundException("Id not found");

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        // REMOVER
        public async Task RemoveAsync(int id)
        {
            var seller = await _context.Seller.FindAsync(id);
            if (seller == null)
                throw new NotFoundException("Seller not found");

            try
            {
                _context.Seller.Remove(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // ajuste a mensagem conforme sua regra de negócio
                throw new IntegrityException("Can't delete seller because he/she has sales");
            }
        }
    }
}
