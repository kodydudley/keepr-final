using System;
using amazen_server.Repositories;
using amazen_server.Models;

namespace amazen_server.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;
    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    public Profile GetOrCreateProfile(Profile userInfo)
    {
      Profile foundProfile = _repo.GetByEmail(userInfo.Email);
      if (foundProfile == null)
      {
        return _repo.Create(userInfo);
      }
      return foundProfile;
    }

    public object GetProfileById(string profileId)
    {
      Profile foundProfile = _repo.GetProfileById(profileId);
      if (foundProfile == null)
      {
        throw new Exception("This Profile does not exist!");
      }
      return foundProfile;
    }
  }
}