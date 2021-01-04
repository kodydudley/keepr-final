using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using amazen_server.Models;
using System.Linq;

namespace amazen_server.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT keep.*, profile.* FROM keeps keep INNER JOIN profiles profile ON keep.creatorId = profile.id ";

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(Keep newKeep)
    {
      string sql = @"
        INSERT INTO keeps
        (name, description, img, creatorId, views, keeps, shares)
        VALUES
        (@Name, @Description, @Img, @CreatorId, @Views, @Keeps, @Shares);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }
  }
}