using Rehber.Business.Abstract;
using Rehber.DataAccess.Abstract;
using Rehber.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Business.Concrete
{
    public class KisilerManager : IKisilerService
    {
        private IKisilerRepository _kisilerRepository;

        public KisilerManager(IKisilerRepository kisilerRepository)
        {
            //_kisilerRepository=new KisilerRepository();
            _kisilerRepository= kisilerRepository;
        }
        public async Task<Kisiler> CreateKisiler(Kisiler kisiler)
        {
            return await _kisilerRepository.CreateKisiler(kisiler);
        }

        public async Task DeleteKisiler(int id)
        {
            await _kisilerRepository.DeleteKisiler(id);
        }

        public async Task<List<Kisiler>> GetAllKisilers()
        {
            return await _kisilerRepository.GetAllKisilers();
        }

        public async Task<Kisiler> GetKisilerById(int id)
        {
            if (id>0)
            {
                return await _kisilerRepository.GetKisilerById(id);
            }

            throw new Exception("id 1 den küçük olamaz!!");

        }

        public async Task<Kisiler> GetKisilerByName(string name)
        {
            return await _kisilerRepository.GetKisilerByName(name);
        }

        public async Task<Kisiler> UpdateKisiler(Kisiler kisiler)
        {
            return await _kisilerRepository.UpdateKisiler(kisiler);
        }
    }
}
