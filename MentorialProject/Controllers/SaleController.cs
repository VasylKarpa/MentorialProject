using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorialProject.DAL.Enteties;
using MentorialProject.Domain.Interfaces.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentorialProject.Controllers {
  [Route("api/sale")]
  [ApiController]
  public class SaleController : ControllerBase {
    private readonly IRepository<Sale> _repository;

    public SaleController(IRepository<Sale> _repository) {
      _repository = _repository;
    }

    // GET: api/Sale
    [HttpGet]
    public IActionResult Get() {
      IEnumerable<Sale> sales = _repository.GetAll();
      return Ok(sales);
    }

    // GET: api/Sale/5
    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(int id) {
      Sale sale = _repository.Get(id);

      if (sale == null) {
        return NotFound("The sale record couldn't be found.");
      }

      return Ok(sale);
    }

    // POST: api/Sale
    [HttpPost]
    public IActionResult Post([FromBody] Sale sale) {
      if (sale == null) {
        return BadRequest("Sale is null.");
      }

      _repository.Add(sale);
      return CreatedAtRoute("Get", new { Id = sale.id }, sale);
    }

    //Put: api/Sale/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Sale sale) {
      if (sale == null) {
        return BadRequest("Sale is null.");
      }

      Sale saleToUpdate = _repository.Get(id);
      if (saleToUpdate == null) {
        return NotFound("The Sale record couldn't be found.");
      }

      _repository.Update(saleToUpdate, sale);
      return NoContent();
    }

    // DELETE: api/Sale/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
      Sale sale = _repository.Get(id);
      if (sale == null) {
        return NotFound("The sale record couldn't be found.");
      }

      _repository.Delete(sale);
      return NoContent();
    }
  }
}