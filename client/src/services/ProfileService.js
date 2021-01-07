import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProfileService {
  async getProfile() {
    try {
      const res = await api.get('api/profile')
      AppState.profile = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getProfileById(profileId) {
    try {
      const res = await api.get('api/profiles/' + profileId)
      AppState.activeProfile = res.data
    } catch (err) {
      logger.error(err)
    }
  }

  async getProfileKeeps(profileId) {
    try {
      const res = await api.get('api/profiles/' + profileId + '/keeps')
      AppState.profileKeeps = res.data
    } catch (err) {
      logger.log(err)
    }
  }

  async getProfileVaults(profileId) {
    try {
      const res = await api.get('api/profiles/' + profileId + '/vaults')
      AppState.profileVaults = res.data
    } catch (err) {
      logger.log(err)
    }
  }
}

export const profileService = new ProfileService()
