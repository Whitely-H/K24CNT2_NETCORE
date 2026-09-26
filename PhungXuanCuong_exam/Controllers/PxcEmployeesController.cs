
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhungXuanCuong2410900014_exam.Models;

public class PxcEmployeesController : Controller
{
    private readonly PxcEmployee2410900014DbContext _context;

    public PxcEmployeesController(PxcEmployee2410900014DbContext context)
    {
        _context = context;
    }

    // GET: PXCEMPLOYEES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.PxcEmployees.ToListAsync());
    }

    // GET: PXCEMPLOYEES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pxcemployee = await _context.PxcEmployees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pxcemployee == null)
        {
            return NotFound();
        }

        return View(pxcemployee);
    }

    // GET: PXCEMPLOYEES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PXCEMPLOYEES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,PxcName,PxcGender,PxcBirthDay,PxcEmail,PxcPhone,PxcActive")] PxcEmployee pxcemployee)
    {
        if (ModelState.IsValid)
        {
            _context.Add(pxcemployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(pxcemployee);
    }

    // GET: PXCEMPLOYEES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pxcemployee = await _context.PxcEmployees.FindAsync(id);
        if (pxcemployee == null)
        {
            return NotFound();
        }
        return View(pxcemployee);
    }

    // POST: PXCEMPLOYEES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,PxcName,PxcGender,PxcBirthDay,PxcEmail,PxcPhone,PxcActive")] PxcEmployee pxcemployee)
    {
        if (id != pxcemployee.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(pxcemployee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PxcEmployeeExists(pxcemployee.Id))
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
        return View(pxcemployee);
    }

    // GET: PXCEMPLOYEES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pxcemployee = await _context.PxcEmployees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pxcemployee == null)
        {
            return NotFound();
        }

        return View(pxcemployee);
    }

    // POST: PXCEMPLOYEES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var pxcemployee = await _context.PxcEmployees.FindAsync(id);
        if (pxcemployee != null)
        {
            _context.PxcEmployees.Remove(pxcemployee);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PxcEmployeeExists(int? id)
    {
        return _context.PxcEmployees.Any(e => e.Id == id);
    }
}
