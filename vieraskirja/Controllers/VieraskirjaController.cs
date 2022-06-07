using Microsoft.AspNetCore.Mvc;
using vieraskirja.Data;

namespace vieraskirja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VieraskirjaController : ControllerBase
    {
        private readonly ILogger<VieraskirjaController> _logger;
        private readonly VieraskirjaContext _db;

        public VieraskirjaController(ILogger<VieraskirjaController> logger, VieraskirjaContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public List<Kirjoitus> HaeKirjoitukset(int? limit)
        {
            List<Kirjoitus> kirjoitukset = new List<Kirjoitus>();
            if (limit.HasValue)
            {
                kirjoitukset = _db.Kirjoitukset.OrderByDescending(o => o.PVM).Take(limit.Value).ToList();
            }
            else
            {
                kirjoitukset = _db.Kirjoitukset.OrderByDescending(o => o.PVM).ToList();
            }
            return kirjoitukset;
        }
        [HttpPost]
        public Kirjoitus Kirjoita(Kirjoitus model)
        {
            model.PVM = DateTime.Now;
            _db.Kirjoitukset.Add(model);
            _db.SaveChanges();
            return model;
        }
    }
}