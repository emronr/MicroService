using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MicroService.OrderAPI.Models;
using MicroService.Business.Abstract;
using MicroService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroService.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/order
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                var items = new OrderListModel();
                items.Orders = _orderService.GetAll();
                return StatusCode(StatusCodes.Status200OK, items.Orders.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        // GET: api/order/id
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            try
            {

                var entity = _orderService.GetById(id.ToString());
                if (entity == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                var model = new OrderModel()
                {
                    Id = entity.Id,
                    ImageUrl = entity.ImageUrl,
                    CustomerId = entity.CustomerId,
                    Price = entity.Price,
                    Quantity = entity.Quantity,
                    Status = entity.Status,
                    CreatedAt = entity.CreatedAt.ToString(),
                    UpdatedAt = entity.UpdatedAt.ToString()
                };
                return StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }

        }
        // GET: api/order/customerid

        [Route("getbycustomer/{customerid?}")]
        [HttpGet]
        public IActionResult GetByCustomer(string customerid)
        {
            try
            {

                var model = _orderService.GetByCustomer(customerid);
                return StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }

        }

        // POST: api/order
        [HttpPost]
        public IActionResult Create([FromBody] OrderModel model)
        {
            try
            {
                model.CreatedAt = DateTime.Now.ToString();
                model.UpdatedAt = DateTime.Now.ToString();
                Random rnd = new Random();
                var entity = new Orders()
                {
                    Id = CreateRandomID(50),
                    ImageUrl = model.ImageUrl,
                    CustomerId = model.CustomerId,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    Status = model.Status,
                    CreatedAt = Convert.ToDateTime(model.CreatedAt),
                    UpdatedAt = Convert.ToDateTime(model.UpdatedAt)
                };

                string ok = _orderService.Create(entity);
                if (ok == "created")
                {
                    return StatusCode(StatusCodes.Status201Created, entity);

                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, model);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
        // PUT : api/order/id
        [HttpPut("{id}", Name = "Put")]
        public IActionResult Update(OrderModel model)
        {
            try
            {

                var entity = _orderService.GetById(model.Id);
                entity.ImageUrl = model.ImageUrl;
                entity.CustomerId = model.CustomerId;
                entity.Price = model.Price;
                entity.Quantity = model.Quantity;
                entity.Status = model.Status;

                entity.UpdatedAt = DateTime.Now;

                if (_orderService.Update(entity))
                {
                    return StatusCode(StatusCodes.Status200OK, model);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, model);
                }

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        // PUT : api/order/id
        [HttpDelete("{id}", Name = "Delete")]
        public IActionResult Delete(string id)
        {
            try
            {
                if (_orderService.Delete(id))
                {
                    var items = new OrderListModel();
                    items.Orders = _orderService.GetAll();
                    return StatusCode(StatusCodes.Status200OK, items.Orders.ToList());
                }

                return StatusCode(StatusCodes.Status204NoContent);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        // PUT : api/order/id
        [Route("changestatus")]
        [HttpPut("{id}", Name = "Put")]
        public IActionResult ChangeStatus(StatusModel model)
        {
            try
            {

                if (_orderService.changeStatus(model.orderid, model.status))
                {

                    var modelforOrder = _orderService.GetById(model.orderid);
                    return StatusCode(StatusCodes.Status200OK, modelforOrder);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, model);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        public string CreateRandomID(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

    }
}
