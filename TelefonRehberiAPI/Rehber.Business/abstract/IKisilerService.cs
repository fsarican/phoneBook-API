using Rehber.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Business.Abstract
{
    public interface IKisilerService
    {
        Task<List<Kisiler>> GetAllKisilers();
        Task<Kisiler> GetKisilerById(int id); 
        Task<Kisiler> GetKisilerByName(string name);
        Task<Kisiler> CreateKisiler(Kisiler kisiler);
        Task<Kisiler> UpdateKisiler(Kisiler kisiler);
        Task DeleteKisiler(int id);
    }
}
