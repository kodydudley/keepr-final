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

  async addToVault(vaultId, keepId) {
    try {
      const newVault = {
        VaultId: vaultId,
        KeepId: keepId
      }
      logger.log(newVault)
      const res = await api.post('api/vaultkeeps', newVault)
      logger.log(res.data)
    } catch (err) {
      logger.error(err)
    }
  }

  async getById(id) {
    try {
      const res = await api.get('api/vaults/' + id)
      AppState.activeVault = res.data
    } catch (err) {
      logger.error(err)
    }
  }

  async getVaultKeepsById(id) {
    try {
      const res = await api.get('api/vaults/' + id + '/keeps')
      AppState.activeVaultKeeps = res.data
      logger.log(AppState.activeVaultKeeps)
    } catch (err) {
      logger.error(err)
    }
  }

  async deleteVK(id) {
    try {
      await api.delete('api/vaultkeeps/' + id)
    } catch (err) {
      logger.log(err)
    }
  }

  async deleteVault(id) {
    try {
      await api.delete('api/vaults/' + id)
    } catch (err) {
      logger.log(err)
    }
  }
}

export const vaultsService = new VaultsService()
