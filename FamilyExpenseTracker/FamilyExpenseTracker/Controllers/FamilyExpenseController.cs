using FamilyExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyExpenseTracker.Controllers
{
    public class FamilyExpenseController : Controller
    {
        // GET: FamilyExpense
        public ActionResult GetFamilyExpenses()
        {
            FamilyExpenseModelManager familyExpenseModelManager = new FamilyExpenseModelManager();
            List<FamilyExpenseViewModel> familyExpenses = familyExpenseModelManager.GetFamilyExpenses();
            return View(familyExpenses);
        }
    }
}