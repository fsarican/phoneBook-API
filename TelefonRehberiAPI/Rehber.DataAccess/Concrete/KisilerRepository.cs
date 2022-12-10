using Microsoft.EntityFrameworkCore;
using Rehber.DataAccess.Abstract;
using Rehber.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DataAccess.Concrete
{
    public class KisilerRepository : IKisilerRepository
    {
        public async Task<Kisiler> CreateKisiler(Kisiler kisiler)
        {
            using (var rehberDbContext = new RehberDbContext())
            {
                rehberDbContext.Kisilers.Add(kisiler);
                await rehberDbContext.SaveChangesAsync();
                return kisiler;
            }
        }

        public async Task DeleteKisiler(int id)
        {
            using (var rehberDbContext = new RehberDbContext())
            {
                var deletedKisiler = await GetKisilerById(id);
                rehberDbContext.Kisilers.Remove(deletedKisiler);
                await rehberDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Kisiler>> GetAllKisilers()
        {
            using (var kisilerDbContext = new RehberDbContext())
            {
                return await kisilerDbContext.Kisilers.ToListAsync();
            }
        }

        public async Task<Kisiler> GetKisilerById(int id)
        {
            using (var rehberDbContext = new RehberDbContext())
            {
                return await rehberDbContext.Kisilers.FindAsync(id);
            }
        }

        public async Task<Kisiler> GetKisilerByName(string name)
        {
            using (var rehberDbContext = new RehberDbContext())
            {
                return await rehberDbContext.Kisilers.FirstOrDefaultAsync(x => x.KisiAd.ToLower()==name.ToLower());
            }
        }

        public async Task<Kisiler> UpdateKisiler(Kisiler kisiler)
        {
            using (var rehberDbContext = new RehberDbContext())
            {
                rehberDbContext.Kisilers.Update(kisiler);
                await rehberDbContext.SaveChangesAsync();
                return kisiler;
            }
        }
    }
}
