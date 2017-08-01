using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using LinqToExcel;
using System.Data.SqlClient;
using GAForecast.Models;
using System.Diagnostics;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using adftestCom;
namespace GAForecast.Controllers
{
    public class HomeController : Controller
    {
        //  DataModel db = new DataModel();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase FileUpload)
        {

            List<string> data = new List<string>();
            if (FileUpload != null)
            {
                // tdata.ExecuteCommand("truncate table OtherCompanyAssets");  
                //if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                //{

                string[] ext = (Path.GetFileName(FileUpload.FileName)).Split('.');
                string filename = Guid.NewGuid().ToString().Substring(0, 20) + "." + ext[1];
                var targetpath = Path.Combine(Server.MapPath("~/Xlxs/"), filename);
                FileUpload.SaveAs(targetpath);
                string pathToExcelFile = targetpath;
                var connectionString = "";
                //if (filename.EndsWith(".xls"))
                //{
                //    connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                //}
                //else if (filename.EndsWith(".xlsx"))
                //{
                connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);


                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                DataTable Contents = new DataTable();
                DataTable Sheets = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sht = "";
                foreach (DataRow dr in Sheets.Rows)
                {
                    sht = dr[2].ToString().Replace("'", "");
                }
                //  var adapter = new OleDbDataAdapter("SELECT * FROM [" + sht + "]", connectionString);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(@"Select * From [" + sht + "]", connectionString))
                {
                    adapter.Fill(Contents);
                }
                using (var db = new DataModel())
                {
                    foreach (DataRow dr in Contents.Rows)
                    {
                        if (dr["Placering"].GetType() == typeof(string) || dr["Placeringens_beskrivning"].GetType() == typeof(string) || dr["Arbetsorder"].GetType() == typeof(string))
                        {

                            Rapporteringsdatum rapp = new Rapporteringsdatum();
                            rapp.Placering = (dr["Placering"].ToString() != null && dr["Placering"].ToString() != "NULL") ? dr["Placering"].ToString() : null;
                            rapp.Placeringens_beskrivning = dr["Placeringens_beskrivning"].ToString();
                            rapp.Arbetsorder = (dr["Arbetsorder"].ToString() != null && dr["Arbetsorder"].ToString() != "NULL") ? dr["Arbetsorder"].ToString() : null;
                            rapp.Arbetstyp = (dr["Arbetstyp"].ToString() != null && dr["Arbetstyp"].ToString() != "NULL") ? dr["Arbetstyp"].ToString() : null;
                            rapp.Problemkod = (dr["Problemkod"].ToString() != null && dr["Problemkod"].ToString() != "NULL") ? dr["Problemkod"].ToString() : null;
                            rapp.Problemkodsbeskrivning = (dr["Problemkodsbeskrivning"].ToString() != null && dr["Problemkodsbeskrivning"].ToString() != "NULL") ? dr["Problemkodsbeskrivning"].ToString() : null;
                            rapp.Orsakskod = (dr["Orsakskod"].ToString() != null && dr["Orsakskod"].ToString() != "NULL") ? dr["Orsakskod"].ToString() : null;
                            rapp.Orsaksbeskrivning = (dr["Orsaksbeskrivning"].ToString() != null && dr["Orsaksbeskrivning"].ToString() != "NULL") ? dr["Orsaksbeskrivning"].ToString() : null;
                            rapp.Åtgärdskod = (dr["Åtgärdskod"].ToString() != null && dr["Åtgärdskod"].ToString() != "NULL") ? dr["Åtgärdskod"].ToString() : null;
                            rapp.Åtgärdskodsbeskrivning = (dr["Åtgärdskodsbeskrivning"].ToString() != null && dr["Åtgärdskodsbeskrivning"].ToString() != "NULL") ? dr["Åtgärdskodsbeskrivning"].ToString() : null;
                            rapp.Beskrivning_av_utfört_arbete_och_långtext = (dr["Beskrivning_av_utfört_arbete_och_långtext"].ToString() != null && dr["Beskrivning_av_utfört_arbete_och_långtext"].ToString() != "NULL") ? dr["Beskrivning_av_utfört_arbete_och_långtext"].ToString() : null;
                            rapp.Arbetsorderbeskrivning_och_långtext = (dr["Arbetsorderbeskrivning_och_långtext"].ToString() != null && dr["Arbetsorderbeskrivning_och_långtext"].ToString() != "NULL") ? dr["Arbetsorderbeskrivning_och_långtext"].ToString() : null;


                            if (!object.Equals(dr["Antal_timmar"], DBNull.Value) && dr["Antal_timmar"].ToString() != "NULL")
                                rapp.Antal_timmar = Convert.ToInt32(dr["Antal_timmar"]);

                            if (!object.Equals(dr["Arbetskostnad"], DBNull.Value) && dr["Arbetskostnad"].ToString() != "NULL")
                                rapp.Arbetskostnad = Convert.ToDecimal(dr["Arbetskostnad"]);

                            if (!object.Equals(dr["Materialkostnad"], DBNull.Value) && dr["Materialkostnad"].ToString() != "NULL")
                                rapp.Materialkostnad = Convert.ToDecimal(dr["Materialkostnad"]);

                            if (!object.Equals(dr["Verktygskostnad"], DBNull.Value) && dr["Verktygskostnad"].ToString() != "NULL")
                                rapp.Verktygskostnad = Convert.ToDecimal(dr["Verktygskostnad"]);
                            if (!object.Equals(dr["Rapporteringsdatum"], DBNull.Value))
                                rapp.Rapporteringsdatum1 = Convert.ToDateTime(dr["Rapporteringsdatum"]);

                            if (!object.Equals(dr["Verkligt_startdatum"], DBNull.Value))
                                rapp.Verkligt_startdatum = Convert.ToDateTime(dr["Verkligt_startdatum"]);

                            if (!object.Equals(dr["verkligt_slutdatum"], DBNull.Value))
                                rapp.verkligt_slutdatum = Convert.ToDateTime(dr["verkligt_slutdatum"]);
                            if (!object.Equals(dr["överliggande_ao"], DBNull.Value) && dr["överliggande_ao"].ToString() != "NULL")
                                rapp.överliggande_ao = Convert.ToInt32(dr["överliggande_ao"]);

                            db.Rapporteringsdatums.Add(rapp);
                            db.SaveChanges();
                        }
                        // writetext.WriteLine(rapp.Rapporteringsdatum1);
                    }
                }


            }
            return RedirectToAction("Months");
        }
        public ActionResult Months()
        {
            using (var db = new DataModel())
            {
                var items = db.CostDataMonths.OrderByDescending(o => o.Rapporteringsdatum).ToList();
                return View(items);
            }
        }
        [HttpPost]
        public ActionResult Months(CostDataMonth model)
        {
            using (var db = new DataModel())
            {
                var all = db.Rapporteringsdatums.Where(w => w.Rapporteringsdatum1.HasValue).ToList();
                var items = all.GroupBy(g => new { g.Rapporteringsdatum1.Value.Month, g.Rapporteringsdatum1.Value.Year }).ToList();
                foreach (var item in items)
                {
                    if (item.FirstOrDefault().Rapporteringsdatum1.HasValue)
                    {
                        decimal x1 = all.Where(w => w.Rapporteringsdatum1.HasValue && w.Rapporteringsdatum1.Value.Month == item.FirstOrDefault().Rapporteringsdatum1.Value.Month && w.Rapporteringsdatum1.Value.Year == item.FirstOrDefault().Rapporteringsdatum1.Value.Year).Select(s => s.Arbetskostnad).Sum().Value;
                        decimal x2 = all.Where(w => w.Rapporteringsdatum1.HasValue && w.Rapporteringsdatum1.Value.Month == item.FirstOrDefault().Rapporteringsdatum1.Value.Month && w.Rapporteringsdatum1.Value.Year == item.FirstOrDefault().Rapporteringsdatum1.Value.Year).Select(s => s.Materialkostnad).Sum().Value;
                        decimal x3 = all.Where(w => w.Rapporteringsdatum1.HasValue && w.Rapporteringsdatum1.Value.Month == item.FirstOrDefault().Rapporteringsdatum1.Value.Month && w.Rapporteringsdatum1.Value.Year == item.FirstOrDefault().Rapporteringsdatum1.Value.Year).Select(s => s.Verktygskostnad).Sum().Value;
                        CostDataMonth CDM = new CostDataMonth()
                        {
                            Rapporteringsdatum = item.FirstOrDefault().Rapporteringsdatum1,
                            Arbetskostnad = x1,
                            Materialkostnad = x2,
                            Verktygskostnad = x3
                        };
                        db.CostDataMonths.Add(CDM);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Months");
            }
        }
        public ActionResult Matlab()
        {

            using (var db = new DataModel())
            {
                var items = db.StationaryCostDatas.ToList();
               
                return View(items);
            }
        }
        [HttpPost]
        public ActionResult Matlab(StationaryCostData model)
        {
            try
            {

                using (var db = new DataModel())
                {
                    var matlabTable = db.CostDataMonths.ToList();
                    var Arbetskostnad_list = matlabTable.Select(s => Convert.ToDouble(s.Arbetskostnad.Value)).ToList();
                    var Materialkostnad_list = matlabTable.Select(s => Convert.ToDouble(s.Materialkostnad.Value)).ToList();
                    var Verktygskostnad_list = matlabTable.Select(s => Convert.ToDouble(s.Verktygskostnad.Value)).ToList();
                    MyAdfTest x = new MyAdfTest();
                    //Run Function For All Data in one column  for Arbetskostnad
                    MWArray Z1 = new MWNumericArray(Arbetskostnad_list.ToArray());
                    MWArray[] results_Arbetskostnad = x.adftest(4, Z1);
                    //Run Function For All Data in one column  for Materialkostnad
                    MWArray Z2 = new MWNumericArray(Materialkostnad_list.ToArray());
                    MWArray[] results_Materialkostnad = x.adftest(4, Z2);
                    //Run Function For All Data in one column  for Verktygskostnad
                    MWArray Z3 = new MWNumericArray(Verktygskostnad_list.ToArray());
                    MWArray[] results_Verktygskostnad = x.adftest(4, Z3);

                    using (StreamWriter writer = new StreamWriter(Server.MapPath("~/write.txt")))
                    {
                        writer.WriteLine("Arbetskostnad");
                        writer.WriteLine(results_Arbetskostnad[0] + " - " + results_Arbetskostnad[1] + " - " + results_Arbetskostnad[2] + " - " + results_Arbetskostnad[3]);
                        writer.WriteLine("Materialkostnad");
                        writer.WriteLine(results_Materialkostnad[0] + " - " + results_Materialkostnad[1] + " - " + results_Materialkostnad[2] + " - " + results_Materialkostnad[3]);
                        writer.WriteLine("Verktygskostnad");
                        writer.WriteLine(results_Verktygskostnad[0] + " - " + results_Verktygskostnad[1] + " - " + results_Verktygskostnad[2] + " - " + results_Verktygskostnad[3]);
                       
                    }
                    //StationaryCostData SCD = new StationaryCostData()
                    //{
                    //    Arbetskostnad = Convert.ToDecimal(results_Arbetskostnad[1]),//result for first value
                    //    Materialkostnad = Convert.ToDecimal(results_Materialkostnad[1]),//result for first value
                    //    Verktygskostnad = Convert.ToDecimal(results_Verktygskostnad[1])//result for first value
                    //};
                  //  db.StationaryCostDatas.Add(SCD);
                  //  db.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
            return View();
        }

    }
}