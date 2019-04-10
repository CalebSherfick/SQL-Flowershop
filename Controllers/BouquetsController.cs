using System.Collections.Generic;
using fullFlowershopServer.Models;
using fullFlowershopServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace fullFlowershopServer.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BouquetsController : ControllerBase
  {
    private readonly BouquetsRepository _br;
    public BouquetsController(BouquetsRepository br)
    {
      _br = br;
    }

    //GET api/Bouquets
    [HttpGet]
    public ActionResult<IEnumerable<Bouquet>> Get()
    {
      return Ok(_br.Get());
    }

    [HttpGet("{id}")]
    public ActionResult<Bouquet> Get(int id)
    {
      return Ok(_br.Get(id));
    }

    [HttpPost]
    public ActionResult<Bouquet> Create([FromBody] Bouquet newBouquet)
    {
      return _br.CreateBouquet(newBouquet);
    }

    [HttpPut("{id}")]
    public ActionResult<Bouquet> Edit(int id, [FromBody]Bouquet editBouquet)
    {
      return _br.EditBouquet(id, editBouquet);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      bool wasSuccessful = _br.DeleteBouquet(id);
      if (wasSuccessful)
      {
        return Ok();
      }
      return BadRequest();
    }





















  }


}