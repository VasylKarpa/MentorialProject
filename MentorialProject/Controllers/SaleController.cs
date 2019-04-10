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
      try {
        // using CreateOrUpdate method makes it necessary to check for existance
        Sale saleCheckForExist = _repository.Get(sale.id);

        if (saleCheckForExist != null) {
          // Do some stuff with object
          // ...
          _repository.AddOrUpdate(saleCheckForExist);
        }
        else {
          saleCheckForExist = new Sale();
          // Do some stuff
          _repository.AddOrUpdate(saleCheckForExist);
        }
        return Ok(sale);
      }
      catch (Exception ex) {
        return StatusCode(500, "Internal Server Error");
      }
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