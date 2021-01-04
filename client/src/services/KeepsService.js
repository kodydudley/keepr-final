import { AppState } from '../AppState'
// import router from '../router'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getPublicKeeps() {
    try {
      const res = await api.get('api/keeps')
      logger.log(res.data)
      AppState.keeps = res.data
    } catch (err) {
      logger.error(err)
    }
  }
}

export const keepsService = new KeepsService()
