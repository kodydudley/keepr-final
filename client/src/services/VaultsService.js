// import { AppState } from '../AppState'
// import router from '../router'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultsService {
  async create(newVault) {
    try {
      await api.post('api/vaults/', newVault)
      logger.log(newVault)
    } catch (err) {
      logger.error(err)
    }
  }

  async get() {
    try {
      const res = await api.get('api/vaults')
      AppState.vaults = res.data
    } catch (err) {
      logger.error(err)
    }
  }
}

export const vaultsService = new VaultsService()
