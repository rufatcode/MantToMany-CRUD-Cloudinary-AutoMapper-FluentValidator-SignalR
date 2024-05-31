using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet.Actions;
using Lab10_FrontToBack.DataContext;
using Lab10_FrontToBack.Models;
using Lab10_FrontToBack.Services.Interfaces;
using Lab10_FrontToBack.ViewModels.CategoryVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab10_FrontToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IPhotoAccessor _photoAccessor;
        private readonly IFileService _fileService;
        public CategoryController(AppDbContext appDbContext,IMapper mapper,IPhotoAccessor photoAccessor,IFileService fileService)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _photoAccessor = photoAccessor;
            _fileService = fileService;
        }
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<GetCategoryVM>>(await _appDbContext.Categories.Include(c=>c.SubCategoiries).Include(c=>c.Parent).AsNoTracking().ToListAsync()));
        }
        public async Task<IActionResult> Post()
        {
            ViewBag.ParentCategories = new SelectList(await _appDbContext.Categories.Where(c => c.ParentId == null).ToListAsync(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Post(PostCategoryVM postCategoryVM)
        {
            ViewBag.ParentCategories = new SelectList(await _appDbContext.Categories.Where(c => c.ParentId == null).ToListAsync(), "Id", "Name");
            if (!ModelState.IsValid) return View();
            else if (await _appDbContext.Categories.AnyAsync(c => c.Name.ToLower() == postCategoryVM.Name.ToLower())) ModelState.AddModelError("Name", $"{postCategoryVM.Name} already has created");
            else if (!_fileService.IsImage(postCategoryVM.Image))
            {
                ModelState.AddModelError("Image", "you can upload only image");
                return View();
            }
            else if (!_fileService.IsLengthSuit(postCategoryVM.Image,1000))
            {
                ModelState.AddModelError("Image", "image length must be smaller than 1mb");
                return View();
            }
            Category category = _mapper.Map<Category>(postCategoryVM);
            ImageUploadResult imageUploadResult =await _photoAccessor.AddPhoto(postCategoryVM.Image);
            category.PublicId = imageUploadResult.PublicId;
            category.ImageUrl = imageUploadResult.SecureUrl.ToString();
            category.CreatedAt = DateTime.Now;
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

