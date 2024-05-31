using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lab10_FrontToBack.DataContext;
using Lab10_FrontToBack.Models;
using Lab10_FrontToBack.ViewModels.CategoryVM;
using Lab10_FrontToBack.ViewModels.TagVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab10_FrontToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TagController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public TagController(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<GetTagVM>>(await _appDbContext.Tags.AsTracking().ToListAsync()));
        }
        public async Task<IActionResult> Post()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostTagVM postTagVM)
        {
            if (!ModelState.IsValid) return View();
            else if (await _appDbContext.Tags.AnyAsync(t=>t.Name.ToLower()==postTagVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", $"{postTagVM.Name} already has created");
                return View();
            }
            Tag tag = _mapper.Map<Tag>(postTagVM);
            tag.CreatedAt = DateTime.Now;
            await _appDbContext.Tags.AddAsync(tag);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Delete(int? id)
        {
            if (id == null) return BadRequest();
            else if (!await _appDbContext.Tags.AnyAsync(t => t.Id == id)) return NotFound();
             _appDbContext.Tags.Remove(await _appDbContext.Tags.FirstOrDefaultAsync(t => t.Id == id));
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Put(int? id)
        {
            if (id == null) return BadRequest();
            else if (!await _appDbContext.Tags.AnyAsync(t => t.Id == id)) return NotFound();
            return View(_mapper.Map<PutTagVM>(await _appDbContext.Tags.FirstOrDefaultAsync(t=>t.Id==id)));
        }
        [HttpPost]
        public async Task<IActionResult> Put(int? id,PutTagVM putTagVM)
        {
            if (id == null) return BadRequest();
            else if (!await _appDbContext.Tags.AnyAsync(t => t.Id == id)) return NotFound();
            Tag tag = await _appDbContext.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if (!ModelState.IsValid) return View(_mapper.Map<PutTagVM>(tag));
             else if (await _appDbContext.Tags.AnyAsync(t=>t.Name.ToLower()==putTagVM.Name.ToLower()&&putTagVM.Name.ToLower()!=tag.Name.ToLower()))
            {
                ModelState.AddModelError("Name", $"{putTagVM.Name} already has created");
                return View();
            }
            _mapper.Map(putTagVM, tag);
            tag.UpdatedAt = DateTime.Now;
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

