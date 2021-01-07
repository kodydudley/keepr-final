import { AppState } from '../AppState'
import router from '../router'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getPublicKeeps() {
    try {
      const res = await api.get('api/keeps')
      logger.log('all keeps', res.data)
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
      logger.log(keepId)
    } catch (err) {
      logger.error(err)
    }
  }

  async viewCount(keep, keepId) {
    try {
      await api.get('api/keeps/' + keepId)
      keep.views++
    } catch (err) {
      logger.log(err)
    }
  }
}

export const keepsService = new KeepsService()
