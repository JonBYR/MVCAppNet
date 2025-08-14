using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MVCAppDbContext _context;

        public HomeController(ILogger<HomeController> logger, MVCAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            var totalExpenses = allExpenses.Sum(e => e.value);
            ViewBag.Expenses = allExpenses;
            return View(allExpenses);
        }
        public IActionResult CreateExpense(int? id)
        {
            if (id != null) 
            {
                var expense = _context.Expenses.SingleOrDefault(e => e.id == id);
                return View(expense);
            }
            return View();
        }
        public IActionResult DeleteExpense(int id)
        {
            var expense = _context.Expenses.SingleOrDefault(e => e.id == id);
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }
        public IActionResult ExpenseForm(Expense model)
        {
            if(model.id == 0)
            {
                _context.Expenses.Add(model);
            }
            else
            {
                _context.Expenses.Update(model);
            }
                _context.SaveChanges();
            return RedirectToAction("index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
