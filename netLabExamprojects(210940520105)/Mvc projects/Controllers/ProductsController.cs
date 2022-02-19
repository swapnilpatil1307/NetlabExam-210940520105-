using LabExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace LabExamProject.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Products> objpr = new List<Products>();
            
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDB;Integrated Security=True;";
            connect.Open();

            SqlCommand cm = new SqlCommand();
            cm.Connection = connect;
            cm.CommandType = System.Data.CommandType.StoredProcedure;
            cm.CommandText = "SelectAll";

            try
            {
                SqlDataReader dataread = cm.ExecuteReader();
                while(dataread.Read())
                {
                    Products p = new Products();
                    p.ProductId = (int)dataread["ProductId"];
                    p.ProductName = dataread["ProductName"].ToString();
                    p.Rate = (decimal)dataread["Rate"];
                    p.Description = dataread["Description"].ToString();
                    p.CategoryName = dataread["CategoryName"].ToString();

                    objpr.Add(p);

                }

            }
            catch(Exception e)
            {
                ViewBag.msg = e;
            }
            finally
            {

                connect.Close();
            }

            return View(objpr);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDB;Integrated Security=True;";
            connect.Open();

            SqlCommand cm = new SqlCommand();
            cm.Connection = connect;
            cm.CommandType = System.Data.CommandType.StoredProcedure;
            cm.CommandText = "fetchSingleOB";
            cm.Parameters.AddWithValue("ProductId", id);

           try
            {
                SqlDataReader dataread = cm.ExecuteReader();
                Products p= null;
                dataread.Read();
                p = new Products();
                {
                    p.ProductId = (int)dataread["ProductId"];
                    p.ProductName = dataread["ProductName"].ToString();
                    p.Rate = (decimal)dataread["Rate"];
                    p.Description = dataread["Description"].ToString();
                    p.CategoryName = dataread["CategoryName"].ToString();
                };
            }
            catch(Exception e)
            {
                ViewBag.msg = e;
            }
            finally
            {
                connect.Close();
            }



            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products obj)
        {
            try
            {
                // TODO: Add update logic here
                SqlConnection connect = new SqlConnection();
                connect.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDB;Integrated Security=True;";
                connect.Open();

                SqlCommand cm = new SqlCommand();
                cm.Connection = connect;
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "Update Products set ProductId=@ProductId, ProductName=@ProductName,Rate=@Rate,Description=@Description,CategoryName=@CategoryName where ProductId="+id;
            
                cm.Parameters.AddWithValue("ProductName", obj.ProductName);
                cm.Parameters.AddWithValue("Rate", obj.Rate);
                cm.Parameters.AddWithValue("Description", obj.Description);
                cm.Parameters.AddWithValue("CategoryName", obj.CategoryName);

                try
                {
                    cm.ExecuteNonQuery();
                    return RedirectToAction("Index");

                }
                catch(Exception e)
                {
                    ViewBag.msg = e;
                }
                finally
                {
                    connect.Close();
                }
                return View();

               
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
