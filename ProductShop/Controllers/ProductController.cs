using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ApplicationDbContext dbc;
        public ProductController(ApplicationDbContext dbc_in) { 
            dbc = dbc_in;
        }
        [HttpGet]
        [Route("/Product/GetList")]
        public ActionResult Read()
        {
            return Ok(new { data = dbc.Products.ToList() });
        }

        [HttpPost]
        [Route("/Product/Insert")]
        public ActionResult Insert(Product p)
        {
            if (p == null)
            {
                return BadRequest("Dữ liệu sản phẩm không hợp lệ.");
            };
            dbc.Products.Add(p);
            dbc.SaveChanges();
            return Ok(new { data = p });
        }


        [HttpPost]
        [Route("/Product/Update")]
        public ActionResult Update(int id, string barcode, string name, string categoryName, decimal purchasePrice, decimal salePrice, string notes)
        {
            Product p = new Product();
            p.ID = id;
            p.Barcode = barcode;
            p.Name = name;
            p.CategoryName = categoryName;
            p.PurchasePrice = purchasePrice;
            p.SalePrice = salePrice;
            p.Notes = notes;

            dbc.Products.Update(p);
            dbc.SaveChanges();
            return Ok(new { data = p });
        }

        [HttpPost]
        [Route("/Product/Delete")]
        public ActionResult Delete(int id)
        {
            Product p = new Product();
            p.ID = id;


            dbc.Products.Remove(p);
            dbc.SaveChanges();
            return Ok(new { data = p });
        }



        [HttpGet]
        [Route("/Product/Search")]
        public ActionResult Search(string s)
        {
            return Ok(new { data = dbc.Products.Where(item => item.Name.Contains(s) || item.Barcode.Contains(s)).ToList() });
        }
    }
}
