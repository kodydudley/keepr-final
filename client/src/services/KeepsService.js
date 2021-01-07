import { AppState } from '../AppState'
import router from '../router'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getPublicKeeps() {
    try {
      const res = await api.get('api/keeps')
      AppState.keeps = res.data
    } catch (err) {
      logger.error(err)
    }
  }

  async create(newKeep) {
    try {
      await api.post('api/keeps/', newKeep)
      router.push({ name: 'Home' })
    } catch (err) {
      logger.error(err)
    }
  }

  async deleteKeep(keepId) {
    try {
      await api.delete('api/keeps/' + keepId)
      this.getPublicKeeps()
    } catch (err) {
      logger.error(err)
    }
  }

  async viewCount(id) {
    try {
      await api.put('api/keeps/' + id + '?views=1')
      this.getPublicKeeps()
    } catch (err) {
      logger.log(err)
    }
  }

  async keepCount(id) {
    try {
      await api.put('api/keeps/' + id + '/keepAmount?keeps=1')
    } catch (err) {
      logger.error(err)
    }
  }
}

export const keepsService = new KeepsService()
