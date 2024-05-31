using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet.Actions;
using Lab10_FrontToBack.DataContext;
using Lab10_FrontToBack.Models;
using Lab10_FrontToBack.Services.Interfaces;
using Lab10_FrontToBack.ViewModels.ProductVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab10_FrontToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IPhotoAccessor _photoAccessor;
        public ProductController(AppDbContext appDbContext,IMapper mapper,IFileService fileService,IPhotoAccessor photoAccessor)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _fileService = fileService;
            _photoAccessor = photoAccessor;
        }
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<GetProductVM>>(await _appDbContext.Products
                .AsNoTracking()
                .Include(p=>p.ProductImages)
                .Include(p=>p.ProductTags)
                .ThenInclude(pt=>pt.Tag)
                .Include(p=>p.Category).Include(p=>p.Brand).ToListAsync()));
        }
        public async Task<IActionResult> Post()
        {
            ViewBag.Categories = new SelectList(await _appDbContext.Categories.AsNoTracking().ToListAsync(), "Id", "Name");
            ViewBag.Brands = new SelectList(await _appDbContext.Brands.AsNoTracking().ToListAsync(), "Id", "Name");
            ViewBag.Tags = new SelectList(await _appDbContext.Tags.AsNoTracking().ToListAsync(), "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostProductVM postProductVM)
        {
            ViewBag.Categories = new SelectList(await _appDbContext.Categories.AsNoTracking().ToListAsync(), "Id", "Name");
            ViewBag.Brands = new SelectList(await _appDbContext.Brands.AsNoTracking().ToListAsync(), "Id", "Name");
            ViewBag.Tags = new SelectList(await _appDbContext.Tags.AsNoTracking().ToListAsync(), "Id", "Name");
            if (!ModelState.IsValid) return View();
            else if (await _appDbContext.Products.AnyAsync(p=>p.Name.ToLower()==postProductVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", $"{postProductVM.Name} already has exist");
                return View();
            }
            else if (postProductVM.Images.Any(i=>!_fileService.IsImage(i)))
            {
                ModelState.AddModelError("Images", "You can upload only image");
                return View();
            }
            else if (postProductVM.Images.Any(i => !_fileService.IsLengthSuit(i,1000)))
            {
                ModelState.AddModelError("Images", "image legth must be smaller than 1 mb");
                return View();
            }
            Product product = _mapper.Map<Product>(postProductVM);
            product.CreatedAt = DateTime.Now;
            foreach (var image in postProductVM.Images)
            {
                ImageUploadResult imageResoult = await _photoAccessor.AddPhoto(image);
                product.ProductImages.Add(new ProductImages { ProductId=product.Id,Url=imageResoult.SecureUrl.ToString(),PublicId=imageResoult.PublicId,CreatedAt=DateTime.Now});
            }
            foreach (var tagId in postProductVM.TagIds)
            {
                product.ProductTags.Add(new ProductTag { CreatedAt = DateTime.Now, TagId = tagId, ProductId = product.Id });
            }
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Put(int ?id)
        {
            if (id == null) return BadRequest();
            else if (!await _appDbContext.Products.AnyAsync(b => b.Id == id)) return NotFound();
            ViewBag.Categories = new SelectList(await _appDbContext.Categories.AsNoTracking().ToListAsync(), "Id", "Name");
            ViewBag.Brands = new SelectList(await _appDbContext.Brands.AsNoTracking().ToListAsync(), "Id", "Name");
            ViewBag.Tags = new SelectList(await _appDbContext.Tags.AsNoTracking().ToListAsync(), "Id", "Name");

            return View(_mapper.Map<PutProductVM>(await _appDbContext.Products.FirstOrDefaultAsync(p=>p.Id==id)));
        }
        [HttpPost]
        public async Task<IActionResult> Put(int ?id,PutProductVM putProductVM)
        {
            ViewBag.Categories = new SelectList(await _appDbContext.Categories.AsNoTracking().ToListAsync(), "Id", "Name");
            ViewBag.Brands = new SelectList(await _appDbContext.Brands.AsNoTracking().ToListAsync(), "Id", "Name");
            ViewBag.Tags = new SelectList(await _appDbContext.Tags.AsNoTracking().ToListAsync(), "Id", "Name");
            if (!ModelState.IsValid) return View();
            else if (id == null) return BadRequest();
            else if (!await _appDbContext.Products.AnyAsync(b => b.Id == id)) return NotFound();
            Product existProduct= await _appDbContext.Products.Include(p=>p.ProductImages).Include(p=>p.ProductTags).FirstOrDefaultAsync(p => p.Id == id);
            if (await _appDbContext.Products.AnyAsync(p => p.Name.ToLower() == putProductVM.Name.ToLower()&&putProductVM.Name.ToLower()!=existProduct.Name.ToLower()))
            {
                ModelState.AddModelError("Name", $"{putProductVM.Name} already has exist");
                return View(_mapper.Map<PutProductVM>(existProduct));
            }
            if (putProductVM.Images!=null)
            {
                if (putProductVM.Images.Any(i => !_fileService.IsImage(i)))
                {
                    ModelState.AddModelError("Images", "You can upload only image");
                    return View(_mapper.Map<PutProductVM>(existProduct));
                }
                else if (putProductVM.Images.Any(i => !_fileService.IsLengthSuit(i, 1000)))
                {
                    ModelState.AddModelError("Images", "image legth must be smaller than 1 mb");
                    return View(_mapper.Map<PutProductVM>(existProduct));
                }
            }
            _mapper.Map(putProductVM, existProduct);
            existProduct.UpdatedAt = DateTime.Now;
            List<string> oldPulicIds = existProduct.ProductImages.Select(pi => pi.PublicId).ToList();
            
            if (putProductVM.Images!=null)
            {
                List<ProductImages> productImages = new();
                foreach (var image in putProductVM.Images)
                {
                    ImageUploadResult imageResoult = await _photoAccessor.AddPhoto(image);
                    productImages.Add(new ProductImages { ProductId = existProduct.Id, Url = imageResoult.SecureUrl.ToString(), PublicId = imageResoult.PublicId, CreatedAt = DateTime.Now });
                }
                existProduct.ProductImages = productImages;
            }
            if (putProductVM.TagIds!=null)
            {
                List<ProductTag> productTags = new();
                foreach (var tagId in putProductVM.TagIds)
                {
                    productTags.Add(new ProductTag { CreatedAt = DateTime.Now, TagId = tagId, ProductId = existProduct.Id });
                }
                existProduct.ProductTags = productTags;
            }
            int rowAffected= await _appDbContext.SaveChangesAsync();
            if (rowAffected>0&&putProductVM.Images!=null)
            {
                foreach (var oldpublicId in oldPulicIds)
                {
                    await _photoAccessor.DeletePhoto(oldpublicId);
                }
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
             if (id == null) return BadRequest();
            else if (!await _appDbContext.Products.AnyAsync(b => b.Id == id)) return NotFound();
            Product product = await _appDbContext.Products.Include(p=>p.ProductImages).FirstOrDefaultAsync(p => p.Id == id);
            List<string> oldPulicIds = product.ProductImages.Select(pi => pi.PublicId).ToList();
            _appDbContext.Products.Remove(product);
            int rowAffected = await _appDbContext.SaveChangesAsync();
            if (rowAffected > 0)
            {
                foreach (var oldpublicId in oldPulicIds)
                {
                    await _photoAccessor.DeletePhoto(oldpublicId);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

