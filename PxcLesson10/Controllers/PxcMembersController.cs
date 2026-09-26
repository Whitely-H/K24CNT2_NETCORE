
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PxcLesson10.Models;

public class PxcMembersController : Controller
{
    private readonly PxcK24cnt2lesson10Context _context;

    public PxcMembersController(PxcK24cnt2lesson10Context context)
    {
        _context = context;
    }

    // GET: PXCMEMBERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.PxcMembers.ToListAsync());
    }

    // GET: PXCMEMBERS/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pxcmember = await _context.PxcMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pxcmember == null)
        {
            return NotFound();
        }

        return View(pxcmember);
    }

    // GET: PXCMEMBERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PXCMEMBERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,PxcUserName,PxcPassword,PxcFullName,PxcEmail,PxcPhone,PxcStatus")] PxcMember pxcmember)
    {
        if (ModelState.IsValid)
        {
            _context.Add(pxcmember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(pxcmember);
    }

    // GET: PXCMEMBERS/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pxcmember = await _context.PxcMembers.FindAsync(id);
        if (pxcmember == null)
        {
            return NotFound();
        }
        return View(pxcmember);
    }

    // POST: PXCMEMBERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,PxcUserName,PxcPassword,PxcFullName,PxcEmail,PxcPhone,PxcStatus")] PxcMember pxcmember)
    {
        if (id != pxcmember.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(pxcmember);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PxcMemberExists(pxcmember.Id))
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
        return View(pxcmember);
    }

    // GET: PXCMEMBERS/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pxcmember = await _context.PxcMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pxcmember == null)
        {
            return NotFound();
        }

        return View(pxcmember);
    }

    // POST: PXCMEMBERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var pxcmember = await _context.PxcMembers.FindAsync(id);
        if (pxcmember != null)
        {
            _context.PxcMembers.Remove(pxcmember);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PxcMemberExists(long? id)
    {
        return _context.PxcMembers.Any(e => e.Id == id);
    }
}
