using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FuelProject.Models;

namespace FuelProject.Controllers
{
    public class LogInUserController : Controller
    {

        FuelBaseContext db = new FuelBaseContext();


        [HttpPost]
        public ActionResult UserMenu(User user)
        {
           
            List<InventoryFuel> inventory = (from d in db.InventoryFuels select d).ToList();

            List<InventoryGSM> inventoryGSM = (from d in db.InventoryGSMs select d).ToList();

            ViewBag.InvF = inventory.Last();

            ViewBag.Inv = inventoryGSM.Last();
            return PartialView();
        }

        public ActionResult UserMenu1()
        {
            List<InventoryFuel> inventory = (from d in db.InventoryFuels select d).ToList();

            List<InventoryGSM> inventoryGSM = (from d in db.InventoryGSMs select d).ToList();

            ViewBag.InvF = inventory.Last();

            ViewBag.Inv = inventoryGSM.Last();


            return PartialView();
        }

        public ActionResult StartPage()
        {
            return View();
        }
    }
}