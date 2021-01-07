using System;
using System.Collections.Generic;
using System.Data;
using amazen_server.Models;
using Dapper;

namespace amazen_server.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT vault.*, profile.* FROM vaults vault INNER JOIN profiles profile ON vault.creatorId = profile.id ";

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(Vault newVault)
    {
      string sql = @"
        INSERT INTO vaults
        (id, creatorId, name, description, isPrivate, img)
        VALUES
        (@Id, @CreatorId, @Name, @Description, @IsPrivate, @Img);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    public IEnumerable<Vault> Get(string profileId)
    {
      string sql = populateCreator;
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, splitOn: "id");
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    public Vault GetById(int id)
    {
      string sql = "SELECT * FROM vaults WHERE id = @Id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }

    // internal object GetVaultsByProfileId(string id)
    // {
    //   throw new NotImplementedException();
    // }

    internal IEnumerable<Vault> GetVaultsByProfileId(string profileId)
    {
      string sql = @"
      SELECT
      vault.*,
      profile.*
      FROM vaults vault
      JOIN profiles profile ON vault.creatorId = profile.id;";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, new { profileId }, splitOn: "id");
    }
  }
}