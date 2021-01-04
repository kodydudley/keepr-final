using System;
using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;
using System.Linq;

namespace amazen_server.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    public Vault Create(Vault newVault)
    {
      newVault.Id = _repo.Create(newVault);
      return newVault;
    }

    public IEnumerable<Vault> Get()
    {
      return _repo.Get();
    }

    public Vault GetById(int id)
    {
      var foundVault = _repo.GetById(id);
      if (foundVault == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundVault;
    }
    public string Delete(int id, Profile userInfo)
    {
      if (_repo.Delete(id))
      {
        return ("The keep has been deleted.");
      }
      throw new Exception("That didn't work! It's still there!");
    }
  }
}