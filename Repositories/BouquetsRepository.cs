using System;
using System.Data;
using Dapper;
using fullFlowershopServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace fullFlowershopServer.Repositories
{
  public class BouquetsRepository
  {
    private readonly IDbConnection _db;
    public BouquetsRepository(IDbConnection db)
    {
      _db = db;
    }


    public object Get()
    {
      return _db.Query<Bouquet>("SELECT * FROM bouquets");
    }
    public object Get(int Id)
    {
      return _db.QueryFirstOrDefault<Bouquet>($"SELECT * FROM bouquets WHERE id = @Id", new { Id });
    }

    public ActionResult<Bouquet> CreateBouquet(Bouquet bouquet)
    {
      _db.Execute("INSERT INTO bouquets (name)"
      + "VALUES (@Name)", bouquet);
      return bouquet;
    }

    public ActionResult<Bouquet> EditBouquet(int id, Bouquet bouquet)
    {
      string query = @"
UPDATE bouquets SET
name = @Name
WHERE id = @Id;
SELECT * FROM bouquets WHERE id = @Id;
";
      return _db.QueryFirstOrDefault<Bouquet>(query, bouquet);
    }

    public bool DeleteBouquet(int Id)
    {
      int wasSuccessful = _db.Execute("DELETE FROM bouquets WHERE id = @Id", new { Id });
      return wasSuccessful > 0;
    }








  }
}