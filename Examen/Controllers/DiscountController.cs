using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Controllers
{
    public class DiscountController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Discount discount)
        {
            EmployeeContext context = new EmployeeContext();

            context.Discounts.Add(discount);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Discount");
        }

        public IActionResult Index()
        {
            EmployeeContext context = new EmployeeContext();

            var discountList = context.Discounts.ToList();

            return View(discountList);
        }

        public IActionResult Details(int? id)
        {
            EmployeeContext context = new EmployeeContext();

            if (id == null)
            {
                return NotFound();
            }

            var discount = context.Discounts.Find(id);

            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }

        public IActionResult Update(int? id)
        {
            EmployeeContext context = new EmployeeContext();

            if (id == null)
            {
                return NotFound();
            }

            var discount = context.Discounts.Find(id);

            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Discount discount)
        {
            EmployeeContext context = new EmployeeContext();

            context.Discounts.Update(discount);
            await context.SaveChangesAsync();

            if (discount == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Discount");
        }

        public IActionResult Delete(int? id)
        {
            EmployeeContext context = new EmployeeContext();

            if (id == null)
            {
                return NotFound();
            }

            var discount = context.Discounts.Find(id);

            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            EmployeeContext context = new EmployeeContext();

            var discount = await context.Discounts.FindAsync(id);

            context.Discounts.Remove(discount);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Discount");
        }
    }
}
