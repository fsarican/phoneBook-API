using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rehber.Business.Abstract;
using Rehber.Entity;
using System.Threading.Tasks;

namespace Rehber.APII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KisilerController : ControllerBase
    {
        private IKisilerService _kisilerService;

        public KisilerController(IKisilerService kisilerService)
        {
            _kisilerService = kisilerService;

        }


        /// <summary>
        /// Tüm Kayıtları getir
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var kisiler = await _kisilerService.GetAllKisilers();
            return Ok(kisiler);
        }

        /// <summary>
        /// Id İle Kişi Bul
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]//api/kisilers/getkisilerbyid/2
        public async Task<IActionResult> GetKisilerById(int id)
        {
            var kisiler = await _kisilerService.GetKisilerById(id);
            if (kisiler!=null)
            {
                return Ok(kisiler);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetKisilerByName(string name)
        {
            var kisiler = await _kisilerService.GetKisilerByName(name);
            if (kisiler!=null)
            {
                return Ok(kisiler);
            }
            return NotFound();
        }

        /// <summary>
        /// Yeni Bir Kişi Oluştur
        /// </summary>
        /// <param name="kisiler"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> KisiEkle([FromBody] Kisiler kisiler)
        {
            var kisiEkle = await _kisilerService.CreateKisiler(kisiler);
            return CreatedAtAction("Get", new { id = kisiEkle.Id }, kisiEkle);
        }

        /// <summary>
        /// Kişi Güncelle
        /// </summary>
        /// <param name="kisiler"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> KisiGüncelle([FromBody] Kisiler kisiler)
        {
            if (await _kisilerService.GetKisilerById(kisiler.Id)!=null)
            {
                return Ok(_kisilerService.UpdateKisiler(kisiler));
            }
            return NotFound();
        }

        /// <summary>
        /// Kişi Sil
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> KisiSil(int id)
        {
            if (await _kisilerService.GetKisilerById(id)!=null)
            {
                await _kisilerService.DeleteKisiler(id);
                return Ok();
            }
            return NotFound();

        }
    }
}
