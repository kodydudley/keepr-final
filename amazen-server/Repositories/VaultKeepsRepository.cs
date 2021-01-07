using System;
using System.Collections.Generic;
using System.Data;
using amazen_server.Models;
using Dapper;

namespace amazen_server.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT vaultKeep.*, profile.* FROM vaultKeeps vaultKeep INNER JOIN profiles profile ON vaultKeep.creatorId = profile.id ";

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(VaultKeep newVaultKeep)
    {
      string sql = @"
        INSERT INTO vaultKeeps
        (id, creatorId, keepId, vaultId)
        VALUES
        (@Id, @CreatorId, @KeepId, @VaultId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVaultKeep);
    }
    public IEnumerable<VaultKeep> Get()
    {
      string sql = @"
      SELECT * FROM vaultKeeps";
      return _db.Query<VaultKeep>(sql);
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM vaultKeeps WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    internal object GetKeepsByVaultId(int vaultId)
    {
      string sql = @"
      SELECT keep.*,
      vaultkeep.id as VaultKeepId,
      profile.*
      FROM vaultkeeps vaultkeep
      JOIN keeps keep on keep.id = vaultkeep.keepId
      JOIN profiles profile ON profile.id = keep.creatorId
      WHERE vaultId = @Vaultid;";
      return _db.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { vaultId }, splitOn: "id");

    }

    public VaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultKeeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }
  }
}