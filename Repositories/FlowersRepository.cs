using System;
using System.Data;
using Dapper;
using fullFlowershopServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace fullFlowershopServer.Repositories
{
  public class FlowersRepository
  {
    private readonly IDbConnection _db;
    public FlowersRepository(IDbConnection db)
    {
      _db = db;
    }


    public object Get()
    {
      return _db.Query<Flower>("SELECT * FROM flowers");
    }
    public object Get(int Id)
    {
      return _db.QueryFirstOrDefault<Flower>($"SELECT * FROM flowers WHERE id = @Id", new { Id });
    }

    public ActionResult<Flower> CreateFlower(Flower flower)
    {
      _db.Execute("INSERT INTO flowers (name, color)"
      + "VALUES (@Name, @Color)", flower);
      return flower;
    }

    public ActionResult<Flower> EditFlower(int id, Flower flower)
    {
      string query = @"
UPDATE flowers SET
name = @Name,
color = @Color
WHERE id = @Id;
SELECT * FROM flowers WHERE id = @Id;
";
      return _db.QueryFirstOrDefault<Flower>(query, flower);
    }

    public bool DeleteFlower(int Id)
    {
      int wasSuccessful = _db.Execute("DELETE FROM flowers WHERE id = @Id", new { Id });
      return wasSuccessful > 0;
    }








  }
}