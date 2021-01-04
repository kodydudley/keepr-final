using System;
using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;
using System.Linq;

namespace amazen_server.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    public Keep Create(Keep newKeep)
    {
      newKeep.Id = _repo.Create(newKeep);
      return newKeep;
    }

    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    public IEnumerable<Keep> GetKeepsByProfileId(string profileId, string Id)
    {
      return _repo.GetKeepsByProfileId(profileId);
    }

    public Keep GetById(int id)
    {
      var foundKeep = _repo.GetById(id);
      if (foundKeep == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundKeep;
    }

    public string Delete(int id, Profile userInfo)
    {
      if (_repo.Delete(id))
      {
        return ("The keep has been deleted.");
      }
      throw new Exception("That didn't work! It's still there!");
    }

    public Keep Edit(Keep updated, Profile userInfo)
    {
      Keep original = _repo.GetById(updated.Id);
      if (original == null)
      {
        throw new Exception("This keep does not exist!");
      }
      if (original.CreatorId != userInfo.Id)
      {
        throw new Exception("Access Denied! You did not create this Keep!");
      }
      else
      {
        _repo.Edit(updated);
        return _repo.GetById(updated.Id);
      }
    }
  }
}