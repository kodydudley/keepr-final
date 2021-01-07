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
      newKeep.Views = 0;
      newKeep.Keeps = 0;
      newKeep.Shares = 0;
      string sql = @"
        INSERT INTO keeps
        (name, description, img, creatorId, views, keeps, shares)
        VALUES
        (@Name, @Description, @Img, @CreatorId, @Views, @Keeps, @Shares);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }


    public IEnumerable<Keep> Get()
    {
      string sql = populateCreator;
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, splitOn: "id");
    }
    internal IEnumerable<Keep> GetKeepsByProfileId(string profileId)
    {
      string sql = @"
      SELECT
      keep.*,
      profile.*
      FROM keeps keep
      JOIN profiles profile ON keep.creatorId = profile.id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { profileId }, splitOn: "id");
    }

    public Keep GetById(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    internal void Edit(Keep updated)
    {
      string sql = @"
      UPDATE keeps
      SET
      views = @Views
      WHERE id = @Id;";
      _db.Execute(sql, updated);
    }

    internal void EditKeepAmount(Keep updated)
    {
      string sql = @"
      UPDATE keeps
      SET
      keeps = @Keeps
      WHERE id = @Id;";
      _db.Execute(sql, updated);
    }
  }
}