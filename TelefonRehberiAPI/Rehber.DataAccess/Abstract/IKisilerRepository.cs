using Rehber.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DataAccess.Abstract
{
    public interface IKisilerRepository
    {
        Task<List<Kisiler>> GetAllKisilers();
        Task<Kisiler> GetKisilerById(int id);
        Task<Kisiler> GetKisilerByName(string name);
        Task<Kisiler> CreateKisiler(Kisiler kisiler);
        Task<Kisiler> UpdateKisiler(Kisiler kisiler);
        Task DeleteKisiler(int id);
    }
}
