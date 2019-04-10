using System.Collections.Generic;
using fullFlowershopServer.Models;
using fullFlowershopServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace fullFlowershopServer.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FlowersController : ControllerBase
  {
    private readonly FlowersRepository _fr;
    public FlowersController(FlowersRepository fr)
    {
      _fr = fr;
    }

    //GET api/flowers
    [HttpGet]
    public ActionResult<IEnumerable<Flower>> Get()
    {
      return Ok(_fr.Get());
    }

    [HttpGet("{id}")]
    public ActionResult<Flower> Get(int id)
    {
      return Ok(_fr.Get(id));
    }

    [HttpPost]
    public ActionResult<Flower> Create([FromBody] Flower newFlower)
    {
      return _fr.CreateFlower(newFlower);
    }

    [HttpPut("{id}")]
    public ActionResult<Flower> Edit(int id, [FromBody]Flower editFlower)
    {
      return _fr.EditFlower(id, editFlower);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      bool wasSuccessful = _fr.DeleteFlower(id);
      if (wasSuccessful)
      {
        return Ok();
      }
      return BadRequest();
    }





















  }


}