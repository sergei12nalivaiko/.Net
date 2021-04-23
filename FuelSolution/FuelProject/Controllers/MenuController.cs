using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FuelProject.Models;

namespace FuelProject.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        FuelBaseContext db = new FuelBaseContext();
        public List<Tank> tanks = new List<Tank>();
        public List<FuelDailyStatement> fuelDailies = new List<FuelDailyStatement>();
        public List<FuelDailyStatement> fuelDailiesSearch = new List<FuelDailyStatement>();
        public List<FuelDailyStatement> fuelDailiesDelete = new List<FuelDailyStatement>();

        public List<int> fuelDailiesDateSearch = new List<int>();

        public List<int> summaDate = new List<int>();
        public double fuelSUM;
        // GET: Menu
        public ActionResult ViewCalibration()
        {
            tanks = db.Tanks.ToList();
            return View(tanks);
        }

        public ActionResult ViewFuelDailyStatement()
        {
            fuelDailies = db.FuelDailyStatements.ToList();
            return View(fuelDailies);
        }

        public ActionResult Calculation()
        {
            Session["fuelSUM"] = fuelSUM;

            return View();
        }


        public ActionResult CalculationResult(string numberTank, string levelSM, string levelMM, string density)
        {
            int numberTankC = Int32.Parse(numberTank);
            int levelSMC = Int32.Parse(levelSM);
            int levelMMC = Int32.Parse(levelMM);
            double densityC = Double.Parse(density);
            List<Tank> z = (from d in db.Tanks where (d.TankNumber == numberTankC) where d.LevelSM == levelSMC select d).ToList();
            double levelFuel = (z[0].Capacity + (levelMMC * z[0].CoefCapacity)) * densityC;
            FuelSum(levelFuel);
            ViewBag.Result = levelFuel;

            return PartialView();
        }



        public void FuelSum(double i)
        {

            //Session["fuelSUM"] = fuelSUM;
            fuelSUM = (double)Session["fuelSUM"];
            Session["fuelSUM"] = fuelSUM + i;
        }

        public ActionResult Summa()
        {
            fuelSUM = (double)Session["fuelSUM"];
            ViewBag.Summa = fuelSUM;
            return PartialView();
        }

        [HttpGet]
        public ActionResult CreateFuelStatement()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateFuelStatement(FuelDailyStatement fuelDailyStatement)
        {
            //string b = fuelDailyStatement.Density.ToString();
            
            //IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "," };
            //double c = double.Parse(b, formatter);
            //fuelDailyStatement.Density = Convert.ToDouble(b);
            db.FuelDailyStatements.Add(fuelDailyStatement);
            db.SaveChanges();
            return PartialView("~/Views/Menu/CreateFSAjax.cshtml");
        }



        [HttpGet]
        public ActionResult Delete(int id, int numString)
        {
            fuelDailiesDelete = (from s in db.FuelDailyStatements where id == s.NumberStatement select s).ToList();
            if (fuelDailiesDelete == null)
            {
                return View();
            }
            return PartialView(fuelDailiesDelete[numString-1]);
        }

        [HttpPost, ActionName("Delete")]
        public void DeleteConfirmed(int id,int numString)
        {
            //FuelDailyStatement u = db.FuelDailyStatements.Find(id);
            fuelDailiesDelete = (from s in db.FuelDailyStatements where id == s.NumberStatement select s).ToList();
            //if (fuelDailiesDelete == null)
            //{
            //    return View();
            //}
            db.FuelDailyStatements.Remove(fuelDailiesDelete[numString-1]);
            db.SaveChanges();
            //return PartialView();
        }


        public ActionResult DeleteFuelStatement1()
        {

            return View();
        }




        public ActionResult FuelStatementSearch(string numberOfStatement)
        {
            int num = Int32.Parse(numberOfStatement);
            fuelDailiesSearch = (from n in db.FuelDailyStatements where n.NumberStatement == num select n).ToList();
            if (fuelDailiesSearch.Count == 0)
            {
                ViewBag.Not = "Ведомость с таким номером не существует!!!";
                return PartialView("~/Views/Menu/NotExist.cshtml");
            }
            else
            {
                float sumL = (from n in db.FuelDailyStatements where n.NumberStatement == num select n.VolumeLiters).Sum();
                float sumKG = (from n in db.FuelDailyStatements where n.NumberStatement == num select n.Weight).Sum();
                int counterStatement = fuelDailiesSearch.Count();
                ViewBag.SL = sumL;
                ViewBag.KG = sumKG;
                ViewBag.CountState = counterStatement;
                return PartialView(fuelDailiesSearch);
            }          
        }

        public ActionResult calculationOfAmountL1()
        {

            return PartialView(fuelDailiesSearch);
        }
        [HttpPost]
        public ActionResult FuelStatementDateSearch(string Date, string Date1)
        {

            DateTime dm = new DateTime();
            DateTime dm1 = new DateTime();
            dm = DateTime.Parse(Date);
            dm1 = DateTime.Parse(Date1);
            fuelDailiesDateSearch = (from f in db.FuelDailyStatements where dm <=f.Date where dm1>=f.Date select f.NumberStatement).Distinct().ToList();
            ViewBag.FDS = fuelDailiesDateSearch;

            var summaSLD= (from f in db.FuelDailyStatements where dm <= f.Date where dm1 >= f.Date select f.VolumeLiters).Sum();
            ViewBag.SummaSDV = summaSLD;

            var summaSKGD = (from f in db.FuelDailyStatements where dm <= f.Date where dm1 >= f.Date select f.Weight).Sum();
            ViewBag.SummaSKGDV = summaSKGD;

            //summaDate = (from f in db.FuelDailyStatements where dm <= f.Date where dm1 >= f.Date select f.VolumeLiters).ToList();
            //ViewBag.SummaLitr = summaDate;


            var groupSumL = from f in db.FuelDailyStatements
                           where dm <= f.Date
                           where dm1 >= f.Date
                           group f by f.NumberStatement into g
                           select new { L = g.Sum(L=>L.VolumeLiters)};

            ViewBag.GS = groupSumL;

            var groupSumK = from f in db.FuelDailyStatements
                            where dm <= f.Date
                            where dm1 >= f.Date
                            group f by f.NumberStatement into g
                            select new { K = g.Sum(K => K.Weight) };

            ViewBag.GSK = groupSumK;

            return PartialView();
        }
        [HttpGet]
        public ActionResult EnterMeasureMentsFuel()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult EnterMeasureMentsFuel(InventoryFuel inventoryFuel)
        {
            db.InventoryFuels.Add(inventoryFuel);
            db.SaveChanges();
            List<InventoryFuel> inventory = (from d in db.InventoryFuels select d).ToList();

            List<InventoryGSM> inventoryGSM = (from d in db.InventoryGSMs select d).ToList();

            ViewBag.InvF = inventory.Last();

            ViewBag.Inv = inventoryGSM.Last();
            return PartialView("~/Views/LogInUser/UserMenu1.cshtml");
        }

        [HttpGet]
        public ActionResult EnterMeasureMentsGSM()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult EnterMeasureMentsGSM(InventoryGSM inventoryGSM)
        {
            db.InventoryGSMs.Add(inventoryGSM);
            db.SaveChanges();
            return PartialView("~/Views/LogInUser/UserMenu.cshtml");
        }
    }
}