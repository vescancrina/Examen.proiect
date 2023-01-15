using EmployeeManager.Models;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            EmployeeContext context = new EmployeeContext();

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Product");
        }

        public IActionResult Index()
        {
            EmployeeContext context = new EmployeeContext();

            var productList = context.Products.ToList();

            return View(productList);
        }

        public IActionResult Details(int? id)
        {
            EmployeeContext context = new EmployeeContext();

            if (id == null)
            {
                return NotFound();
            }

            var product = context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Update(int? id)
        {
            EmployeeContext context = new EmployeeContext();

            if (id == null)
            {
                return NotFound();
            }

            var product = context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product)
        {
            EmployeeContext context = new EmployeeContext();

            context.Products.Update(product);
            await context.SaveChangesAsync();

            if (product == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Product");
        }

        public IActionResult Delete(int? id)
        {
            EmployeeContext context = new EmployeeContext();

            if (id == null)
            {
                return NotFound();
            }

            var product = context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            EmployeeContext context = new EmployeeContext();

            var product = await context.Products.FindAsync(id);

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Product");
        }
    }
}
