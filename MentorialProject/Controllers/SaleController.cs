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

    public SaleController(IRepository<Sale> repository) {
      _repository = repository;
    }

    // GET: api/Sale
    [HttpGet]
    public async Task<IActionResult> Get() {
      IEnumerable<Sale> sales = await _repository.GetAll();
      return Ok(sales);
    }

    // GET: api/Sale/5
    [HttpGet("{id}", Name = "Get")]
    public async Task<IActionResult> Get(int id) {
      Sale sale = await _repository.Get(id);

      if (sale == null) {
        return NotFound("The sale record couldn't be found.");
      }

      return Ok(sale);
    }

    // POST: api/Sale
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Sale sale) {
     
        // using CreateOrUpdate method makes it necessary to check for existance
        Sale saleCheckForExist = await _repository.Get(sale.id);

        if (saleCheckForExist != null) {
          // Do some stuff with object
          // ...
          await _repository.AddOrUpdate(saleCheckForExist);
        }
        else {
          saleCheckForExist = new Sale();
          // Do some stuff
          await _repository.AddOrUpdate(saleCheckForExist);
        }
        return Ok(sale);
    }


    // DELETE: api/Sale/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Sale sale) {

      await _repository.Delete(sale);
      return NoContent();
    }
  }
}