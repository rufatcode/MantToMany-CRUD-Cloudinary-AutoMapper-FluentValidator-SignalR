using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lab10_FrontToBack.DataContext;
using Lab10_FrontToBack.Models;
using Lab10_FrontToBack.ViewModels.BrandVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab10_FrontToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class BrandController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public BrandController(IMapper mapper,AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {

            return View(_mapper.Map<List<GetBrandVM>>(await _appDbContext.Brands.AsNoTracking().ToListAsync()));
        }
        public async Task<IActionResult> Post()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Post(PostBrandVM postBrandVM)
        {
            if (!ModelState.IsValid) return View();
            else if (await _appDbContext.Brands.AnyAsync(b=>b.Name.ToLower()==postBrandVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", $"{postBrandVM.Name} already has exist");
                return View();
            }
            Brand brand = _mapper.Map<Brand>(postBrandVM);
            brand.CreatedAt = DateTime.Now;
            await _appDbContext.Brands.AddAsync(brand);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Delete(int? Id)
        {
            if (Id == null) return BadRequest();
            else if (!await _appDbContext.Brands.AnyAsync(b => b.Id == Id)) return NotFound();
            _appDbContext.Brands.Remove(await _appDbContext.Brands.FirstOrDefaultAsync(b => b.Id == Id));
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Put(int? id)
        {
            if (id == null) return BadRequest();
            else if (!await _appDbContext.Brands.AnyAsync(b => b.Id == id)) return NotFound();
            return View(_mapper.Map<PutBrandVM>(await _appDbContext.Brands.FirstOrDefaultAsync(b => b.Id == id)));
        }
        [HttpPost]
        public async Task<IActionResult> Put(int? id,PutBrandVM putBrandVM)
        {
            if (id == null) return BadRequest();
            else if (!await _appDbContext.Brands.AnyAsync(b => b.Id == id)) return NotFound();
            else if (!ModelState.IsValid)
            {
                return View(_mapper.Map<PutBrandVM>(await _appDbContext.Brands.FirstOrDefaultAsync(b => b.Id == id)));
            }
            else if (await _appDbContext.Brands.AnyAsync(b=>b.Name.ToLower()==putBrandVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", $"{putBrandVM.Name} already has exist");
                return View(_mapper.Map<PutBrandVM>(await _appDbContext.Brands.FirstOrDefaultAsync(b => b.Id == id)));
            }
            Brand brand = await _appDbContext.Brands.FirstOrDefaultAsync(b => b.Id == id);
            _mapper.Map(putBrandVM, brand);
            brand.UpdatedAt = DateTime.Now;
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

