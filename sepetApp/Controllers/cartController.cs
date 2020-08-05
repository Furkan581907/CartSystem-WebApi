using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sepetApp.Models;
using sepetApp.Models.Entities;

namespace sepetApp.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    public class cartController : ControllerBase
    {

        CartSystemContext db = new CartSystemContext();
        
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery]int id)
        {
            try
            {
                var data = db.Product.Where(s => s.Id == id).ToList();
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("add")]
        public async Task<IActionResult> add(int cartId,int productId,int quantity)
        {
            try
            {
                var cart = db.Cart.FirstOrDefault(s => s.Id == cartId);
                CartDetail cartDetail = new CartDetail();
                cartDetail.product = db.Product.FirstOrDefault(s => s.Id == productId);
                cartDetail.Quantity = quantity;
                cart.Products += JsonConvert.SerializeObject(cartDetail);
                db.SaveChanges();
                return Ok("200");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("empty")]
        public async Task<IActionResult> empty(int cartId)
        {
            try
            {
                var cart = db.Cart.FirstOrDefault(s => s.Id == cartId);
                CartDetail cartDetail = new CartDetail();
                cart.Products ="";
                db.SaveChanges();
                return Ok("200");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("remove")]
        public async Task<IActionResult> remove(int cartId,int productId)
        {
            try
            {
                var cart = db.Cart.FirstOrDefault(s => s.Id == cartId);
                var products = JsonConvert.DeserializeObject<List<CartDetail>>(cart.Products);
                foreach (var item in products)
                {
                    if (item.product.Id == productId)
                        products.Remove(item);
                }
                return Ok("200");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("loadfromjson")]
        public async Task<IActionResult> loadfromjson()
        {
            try
            {
                var carts = db.Cart.ToList();
                return Ok(carts);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        public IActionResult Index()
        {
            return Ok("geldi");
        }
    }



    
}