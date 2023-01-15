using EmployeeManager.Models;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Store store)
        {
            EmployeeContext context = new EmployeeContext();

            context.Stores.Add(store);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Store");
        }

        public IActionResult Index()
        {
            EmployeeContext context = new EmployeeContext();

            var storeList = context.Stores.ToList();

            return View(storeList);
        }

        [HttpPost]
        public IActionResult Index(Product product)
        {
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Update(int? id)
        {
            EmployeeContext context = new EmployeeContext();

            if (id == null)
            {
                return NotFound();
            }

            var store = context.Stores.Find(id);

            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        public IActionResult Details(int? id)
        {
            EmployeeContext context = new EmployeeContext();

            if (id == null)
            {
                return NotFound();
            }

            var store = context.Stores.Find(id);

            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Store store)
        {
            EmployeeContext context = new EmployeeContext();

            context.Stores.Update(store);
            await context.SaveChangesAsync();

            if (store == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Store");
        }

        public IActionResult Delete(int? id)
        {
            EmployeeContext context = new EmployeeContext();

            if (id == null)
            {
                return NotFound();
            }

            var store = context.Stores.Find(id);

            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            EmployeeContext context = new EmployeeContext();

            var store = await context.Stores.FindAsync(id);
 
            context.Stores.Remove(store);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Store");
        }
    }
}
