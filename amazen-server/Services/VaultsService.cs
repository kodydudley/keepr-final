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

    public IEnumerable<Vault> Get(string profileId)
    {
      return _repo.Get(profileId).ToList().FindAll(v => v.CreatorId == profileId || !v.IsPrivate);
    }

    public Vault GetById(int id, Profile userInfo)
    {
      var foundVault = _repo.GetById(id);
      if (foundVault == null)
      {
        throw new Exception("Invalid Id");
      }
      else if (!foundVault.IsPrivate || foundVault.CreatorId == userInfo.Id)
      {
        return foundVault;
      }
      else
      {
        throw new Exception("Access not granted!");
      }
    }
    public string Delete(int id, Profile userInfo)
    {
      Vault original = _repo.GetById(id);
      if (userInfo.Id == original.CreatorId)
      {
        if (_repo.Delete(id))
        {
          return ("This has been deleted!");
        }
        return ("Can't delete");
      }
      else
      {
        return ("Access not granted!");
      }
    }

    internal object GetVaultsByProfileId(string profileId, string id)
    {
      return _repo.GetVaultsByProfileId(id).ToList().FindAll(vault => vault.CreatorId == profileId && !vault.IsPrivate || vault.CreatorId == id);
    }

  }
}