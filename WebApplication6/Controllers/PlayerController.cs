using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;

namespace WebApplication6.Controllers
{
    public class PlayerController : Controller
    {
        private readonly VolleyballContext _context;
        public PlayerController(VolleyballContext context)
        {
            _context= context;
        }
        public IActionResult Create()
        { // Pozisyonları veritabanından alıyoruz
            var positions = _context.Positions.ToList();

            // Pozisyonları ViewBag'e ekliyoruz
            ViewBag.Position = new SelectList(positions, "PositionId", "PositionName");
            // Pozisyonları veritabanından alıyoruz
            var countries = _context.Countries.ToList();

            // Pozisyonları ViewBag'e ekliyoruz
            ViewBag.Country = new SelectList(countries, "CountryId", "CountryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Player model, IFormFile FotoUrl)
        {
            // Resim dosyası kontrolü
            if (FotoUrl != null && FotoUrl.Length > 0)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                // Dizin yoksa oluştur
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                var fileName = Path.GetFileName(FotoUrl.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                // Dosyayı sunucuya kaydet
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await FotoUrl.CopyToAsync(stream);
                }

                // Model'e resim yolunu ekle
                model.FotoUrl = "/images/" + fileName;
            }
            if (ModelState.IsValid)
            {
                _context.Players.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            var positions = _context.Positions.ToList();
            ViewBag.Position = new SelectList(positions, "PositionId", "PositionName");

            var countries = _context.Countries.ToList();
            ViewBag.Country = new SelectList(countries, "CountryId", "CountryName");
            return View(model);
        }
        public async Task<IActionResult> List()
        {
            var oyuncular=await _context.Players
                .Include(p =>p.Position)
                .Include(p=>p.Country)
                .ToListAsync();
            var pozisyonlar= await _context.Positions.ToListAsync();
            var ulkeler = await _context.Countries.ToListAsync();
            var viewModel = new PlayerListViewModel
            {
                Players = oyuncular,
                Positions = pozisyonlar,
                Countries=ulkeler
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Edit(int? id)
        {
           
            // Pozisyonları veritabanından alıyoruz
            var positions = _context.Positions.ToList();

            // Pozisyonları ViewBag'e ekliyoruz
            ViewBag.Position = new SelectList(positions, "PositionId", "PositionName");

            var countries = _context.Countries.ToList();
            ViewBag.Country = new SelectList(countries, "CountryId", "CountryName");
            if (id == null)
            {
                return NotFound();
            }
            var oync = await _context.Players.FindAsync(id);
            if (oync == null)
            {
                return NotFound();
            }
            return View(oync);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Player model, IFormFile FotoUrl)
        {
            if (id != model.PlayerId)
            {
                return NotFound();
            }

            // Mevcut oyuncuyu veritabanından alın
            var existingPlayer = await _context.Players.FindAsync(id);
            if (existingPlayer == null)
            {
                return NotFound();
            }

            // Fotoğraf yüklenmişse işle
            if (FotoUrl != null && FotoUrl.Length > 0)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var fileName = Path.GetFileName(FotoUrl.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                // Dosyayı sunucuya kaydet
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await FotoUrl.CopyToAsync(stream);
                }

                // Model'e yeni resim yolunu ekle
                model.FotoUrl = "/images/" + fileName;
            }
            else
            {
                // Resim güncellenmediyse mevcut resmi koru
                model.FotoUrl = existingPlayer.FotoUrl;
            }

            if(Model.IsValid)
{
try
{
_context.Update(model);
await _context.SaveChangesAsync();
}
catch(DbConcurrencyException)
{
if(!_context.Players.Any(p => p.PlayerId==model.PlayerId)
{
return NotFound();
}
else
{
throw;
}
}
return RedirectToAction("List");
}


            // Pozisyon ve ülke bilgilerini hata durumunda ViewBag'e ekle
            var positions = _context.Positions.ToList();
            ViewBag.Position = new SelectList(positions, "PositionId", "PositionName");

            var countries = _context.Countries.ToList();
            ViewBag.Country = new SelectList(countries, "CountryId", "CountryName");

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var oyuncu = await _context.Players.FindAsync(id);
            if(oyuncu == null)
            {
                return NotFound();
            }
            return View(oyuncu);
        }
        [HttpPost]
        public async Task<IActionResult> Delete (int id)
        {
            var oyuncu = await _context.Players.FindAsync(id);
            _context.Players.Remove(oyuncu);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Details()
        {
            var oyuncular = await _context.Players
                .Include(p => p.Position)
                .Include(p => p.Country)
                .ToListAsync();
            var pozisyonlar = await _context.Positions.ToListAsync();
            var ulkeler = await _context.Countries.ToListAsync();
            var viewModel = new PlayerListViewModel
            {
                Players = oyuncular,
                Positions = pozisyonlar,
                Countries = ulkeler
            };
            return View(viewModel);
        }
    }
}
