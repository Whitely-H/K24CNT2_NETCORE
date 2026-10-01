using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreLAB6_EF.Data;
using NetCoreLAB6_EF.Models;

namespace NetCoreLAB6_EF.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'AppDbContext.Products' is null.");
            }

            var products = _context.Products
                .Include(p => p.Category);

            return View(await products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(
                _context.Categories,
                "Id",
                "Name"
            );

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // Upload ảnh ở đây nếu có

                product.CreatedDate = DateTime.Now;

                _context.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Nạp lại Category dropdown
            ViewData["CategoryId"] =
                new SelectList(
                    _context.Categories,
                    "Id",
                    "Name",
                    product.CategoryId
                );

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(
                _context.Categories,
                "Id",
                "Name",
                product.CategoryId
            );

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Lấy Product cũ
                    var oldProduct = await _context.Products
                        .AsNoTracking()
                        .FirstOrDefaultAsync(p => p.Id == id);

                    // Upload hình mới
                    var files = HttpContext.Request.Form.Files;

                    if (files.Count > 0 && files[0].Length > 0)
                    {
                        var file = files[0];

                        var fileName = file.FileName;

                        var directory = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot",
                            "Product"
                        );

                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        var path = Path.Combine(
                            directory,
                            fileName
                        );

                        using (var stream = new FileStream(
                            path,
                            FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        product.Image = fileName;
                    }
                    else
                    {
                        // Không upload ảnh mới
                        // Giữ lại ảnh cũ
                        product.Image = oldProduct?.Image;
                    }

                    _context.Update(product);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(
                _context.Categories,
                "Id",
                "Name",
                product.CategoryId
            );

            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem(
                    "Entity set 'AppDbContext.Products' is null."
                );
            }

            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                // Xóa file hình ảnh
                if (!string.IsNullOrEmpty(product.Image))
                {
                    var imagePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "Product",
                        product.Image
                    );

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?
                .Any(e => e.Id == id))
                .GetValueOrDefault();
        }
    }
}