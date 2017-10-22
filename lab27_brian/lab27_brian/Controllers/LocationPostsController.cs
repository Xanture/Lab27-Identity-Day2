using lab27_brian.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace lab27_brian.Controllers
{
    [Authorize]
    public class LocationPostsController : Controller
    {
        private readonly lab27_brianContext _context;

        public LocationPostsController(lab27_brianContext context)
        {
            _context = context;
        }

        // GET: LocationPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationPost.ToListAsync());
        }

        // GET: LocationPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationPost = await _context.LocationPost
                .SingleOrDefaultAsync(m => m.LocationID == id);
            if (locationPost == null)
            {
                return NotFound();
            }

            return View(locationPost);
        }

        // GET: LocationPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocationPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationID,Review,Image,Contact,Location")] LocationPost locationPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationPost);
        }

        // GET: LocationPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationPost = await _context.LocationPost.SingleOrDefaultAsync(m => m.LocationID == id);
            if (locationPost == null)
            {
                return NotFound();
            }
            return View(locationPost);
        }

        // POST: LocationPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationID,Review,Image,Contact,Location")] LocationPost locationPost)
        {
            if (id != locationPost.LocationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationPostExists(locationPost.LocationID))
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
            return View(locationPost);
        }

        // GET: LocationPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationPost = await _context.LocationPost
                .SingleOrDefaultAsync(m => m.LocationID == id);
            if (locationPost == null)
            {
                return NotFound();
            }

            return View(locationPost);
        }

        // POST: LocationPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationPost = await _context.LocationPost.SingleOrDefaultAsync(m => m.LocationID == id);
            _context.LocationPost.Remove(locationPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationPostExists(int id)
        {
            return _context.LocationPost.Any(e => e.LocationID == id);
        }
    }
}
