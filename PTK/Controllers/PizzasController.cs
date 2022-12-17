using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTK.Data;
using PTK.Models;

namespace PTK.Controllers
{
    public class PizzasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PizzasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pizzas
        public async Task<IActionResult> Index()
        {
            ViewData["ChefofPizza"] = await _context.ChefofPizza.ToListAsync();
            ViewData["Chefs"] = await _context.Chef.ToListAsync();
            var applicationDbContext = _context.Pizza.Include(p => p.Menus);
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult SearchForm()
        {
            return View();
        }

        public async Task<IActionResult> SearchResult(string Title)
        {
            return View("Index", await _context.Pizza.Where(a => a.Title.Contains(Title)).ToListAsync());

        }

        // GET: Pizzas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza
                .Include(p => p.Menus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // GET: Pizzas/Create
        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Name" ,"Logo");
            ViewData["ChefId"] = new SelectList(_context.Chef, "Id", "Name");
            return View();
        }

        // POST: Pizzas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,URL,Price,MenuId")] Pizza pizza, List<int> Chefs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizza);
                await _context.SaveChangesAsync();
                List<ChefofPizza> chefofPizza = new List<ChefofPizza>();
                foreach (int chef in Chefs)
                {
                  chefofPizza.Add(new ChefofPizza { ChefId = chef, PizzaId = pizza.Id });
                }
                _context.ChefofPizza.AddRange(chefofPizza);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Name", pizza.MenuId);
            return View(pizza);
        }

        // GET: Pizzas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }
            IList<ChefofPizza> chefofPizzas = await _context.ChefofPizza.Where<ChefofPizza>(a => a.ChefId == pizza.Id).ToListAsync();
            IList<int> listChefs = new List<int>();
            foreach (ChefofPizza chefofPizza in chefofPizzas)
            {
                listChefs.Add(chefofPizza.ChefId);
            }
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Id", pizza.MenuId);
            ViewData["ChefId"] = new MultiSelectList(_context.Chef, "Id", "Name", listChefs.ToArray());
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,URL,Price,MenuId")] Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaExists(pizza.Id))
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
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Name", pizza.MenuId);
            return View(pizza);
        }

        // GET: Pizzas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza
                .Include(p => p.Menus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // POST: Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pizza = await _context.Pizza.FindAsync(id);
            _context.Pizza.Remove(pizza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaExists(int id)
        {
            return _context.Pizza.Any(e => e.Id == id);
        }
    }
}
