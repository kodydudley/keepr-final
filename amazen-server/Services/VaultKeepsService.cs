using System;
using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;
using System.Linq;

namespace amazen_server.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      newVaultKeep.Id = _repo.Create(newVaultKeep);
      return newVaultKeep;
    }

    public IEnumerable<VaultKeep> Get()
    {
      return _repo.Get();
    }

    public VaultKeep GetById(int id)
    {
      var foundVaultKeep = _repo.GetById(id);
      if (foundVaultKeep == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundVaultKeep;
    }
    public string Delete(int id, Profile userInfo)
    {
      VaultKeep original = _repo.GetById(id);
      if (original.CreatorId == userInfo.Id)
      {
        if (_repo.Delete(id))
        {
          return ("The Vault Keep has been deleted.");
        }
        return ("Can't delete");
      }
      else
      {
        return ("Access not granted!");
      }
    }

    public object GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }
  }
}