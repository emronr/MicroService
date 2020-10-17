using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MicroService.CustomerAPI.Models;
using MicroService.Business.Abstract;
using MicroService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroService.CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerservice)
        {
            _customerService = customerservice;
        }
        // GET: api/customer
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                var items = new CustomerListModel();
                items.Customers = _customerService.GetAll();
                return StatusCode(StatusCodes.Status200OK, items.Customers.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        // GET: api/customer/id
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            try
            {

                var entity = _customerService.GetById(id.ToString());
                if(entity == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                var model = new CustomerModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
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

        // POST: api/customer
        [HttpPost]
        public IActionResult Create([FromBody] CustomerModel model)
        {
            try
            {
                model.CreatedAt = DateTime.Now.ToString();
                model.UpdatedAt = DateTime.Now.ToString();
                Random rnd = new Random();
                var entity = new Customers()
                {
                    Id = CreateRandomID(50),
                    Name = model.Name,
                    Email = model.Email,
                    CreatedAt = Convert.ToDateTime(model.CreatedAt),
                    UpdatedAt = Convert.ToDateTime(model.UpdatedAt)
                };

                string ok = _customerService.Create(entity);

                return StatusCode(StatusCodes.Status201Created, entity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
        // PUT : api/customer/id
        [HttpPut("{id}", Name = "Put")]
        public IActionResult Update(CustomerModel model)
        {
            try
            {

                var entity = _customerService.GetById(model.Id);
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.UpdatedAt = DateTime.Now;

                _customerService.Update(entity);
                return StatusCode(StatusCodes.Status200OK, model);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);

            }
        }
        // PUT : api/customer/id
        [HttpDelete("{id}", Name = "Delete")]
        public IActionResult Delete(string id)
        {
            try
            {
                if (_customerService.Delete(id))
                {
                    var items = new CustomerListModel();
                    items.Customers = _customerService.GetAll();
                    return StatusCode(StatusCodes.Status200OK, items.Customers.ToList());
                }

               return StatusCode(StatusCodes.Status204NoContent);


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