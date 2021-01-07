<template>
  <div class="keepComponent card border-0" @click.prevent="viewCount()" data-toggle="modal" :data-target="'#keepModal'+ keep.id">
    <img class="img-fluid round" style="width: 100%; height: auto" :src="keep.img" alt="">
    <div class="card-img-overlay d-flex justify-content-end flex-column text-light">
      <h6 class="text-left text-white">
        {{ keep.name }}
      </h6>
    </div>
    <div class="card-img-overlay d-flex justify-content-right">
      <router-link data-dismiss="modal" :to="{name: 'ActiveProfile', params: {profileId: keep.creatorId}}">
        <img class="tiny-picture left-side " :src="keep.creator.picture" alt="">
      </router-link>
    </div>
  </div>
  <!-- MODAL SECTION -->
  <div class="modal fade keepModal"
       :id="'keepModal' + keep.id"
       tabindex="-1"
       role="document"
       aria-labelledby="myLargeModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="row">
          <div class="col-6">
            <img :src="keep.img" class="img-fluid m-2" alt="">
          </div>
          <div class="col-5 ml-2">
            <div class="row">
              <div class="col-6 text-center">
                <i class="far fa-eye green"></i> {{ keep.views }}
              </div>
              <div class="col-6 text-center">
                <i class="fab fa-korvue green"></i>
              </div>
            </div>
            <div class="row mt-5 mb-5">
              <div class="col-12 text-center mb-5">
                <h2>
                  {{ keep.name }}
                </h2>
                <h6 class="mt-5 text-grey">
                  {{ keep.description }}
                </h6>
              </div>
            </div>
            <div class="row mt-5 d-flex justify-content-around">
              <div class="dropdown bottom-left">
                <button class="btn btn-success dropdown-toggle"
                        type="button"
                        id="dropdownMenuButton"
                        data-toggle="dropdown"
                        aria-haspopup="true"
                        aria-expanded="false"
                >
                  Add to Vault
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                  <a v-for="vault in profileVaults" :key="vault.id" class="dropdown-item" href="#">
                    <div @click="addToVault(vault.id, keep.id)">
                      <vault-names-component :vault-prop="vault" />
                    </div>
                  </a>
                </div>
              </div>
              <button v-show="profile.id == keep.creatorId" @click="deleteKeep(keep.id)" type="button" class="btn btn-transparent text-danger bottom-middle">
                <i class="fa fa-trash" aria-hidden="true"></i>
              </button>
              <router-link data-dismiss="modal" :to="{name: 'ActiveProfile', params: {profileId: keep.creatorId}}">
                <img class="tiny-picture left-side " :src="keep.creator.picture" alt="">
              </router-link>
              <p class="mt-3 bottom-right">
                {{ keep.creator.name }}
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import VaultNamesComponent from './VaultNamesComponent.vue'
// import { useRoute } from 'vue-router'

export default {
  name: 'KeepComponent',
  props: ['keepProp'],
  setup(props) {
    // const route = useRoute()
    const state = reactive({
    })
    return {
      state,
      keep: computed(() => props.keepProp),
      profile: computed(() => AppState.profile),
      profileVaults: computed(() => AppState.profileVaults),

      async getActiveKeep(keepId) {
        keepsService.getActiveKeep(keepId)
      },
      deleteKeep(keepId) {
        logger.log(keepId)
        keepsService.deleteKeep(keepId)
      },
      viewCount() {
        keepsService.viewCount(props.keepProp.id)
      },
      addToVault(vaultId, keepId) {
        vaultsService.addToVault(vaultId, keepId)
        logger.log(vaultId)
      }

    }
  },
  components: { VaultNamesComponent }
}
</script>

<style lang="scss" scoped>
.small-picture{
  height: 50px;
  border-radius: 5px;
}
.tiny-picture{
  height: 40px;
  border-radius: 20px;
}

.round{
  border-radius: 15px;
}

.green{
  color: #55EFC4;
}

.left-side{
  // margin-left: 85%;
  // margin-bottom: 0%;
  position: absolute;
  bottom: 5%;
  right: 5%;
}

.bottom-left{
  position: absolute;
  bottom: 5%;
  right: 60%
}

.bottom-middle{
  position: absolute;
  bottom: 5%;
}

.bottom-right{
  position: absolute;
  right: 0%;
  bottom: 15%
}

.text-grey{
  color: gray
}

</style>
