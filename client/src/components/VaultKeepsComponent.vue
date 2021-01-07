<template>
  <div class="vaultKeepsComponent card border-0" data-toggle="modal" :data-target="'#keepModal'+ state.keepData.id">
    <div class="card border-0" data-toggle="modal" :data-target="'#keepModal'+ state.keepData.id">
      <img class="img-fluid round" style="width: 100%; height: auto" :src="state.keepData.img" alt="">
      <div class="card-img-overlay d-flex justify-content-end flex-column text-light">
        <h6 class="text-left text-white">
          {{ state.keepData.name }}
        </h6>
      </div>
      <div class="card-img-overlay d-flex justify-content-right">
        <router-link data-dismiss="modal" :to="{name: 'ActiveProfile', params: {profileId: state.keepData.creatorId}}">
          <img class="tiny-picture left-side " :src="state.keepData.creator.picture" alt="">
        </router-link>
      </div>
    </div>
  </div>

  <!-- MODAL SECTION -->
  <div class="modal fade keepModal"
       :id="'keepModal' + state.keepData.id"
       tabindex="-1"
       role="document"
       aria-labelledby="myLargeModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="row">
          <div class="col-6">
            <img :src="state.keepData.img" class="img-fluid m-2" alt="">
          </div>
          <div class="col-5 ml-2">
            <div class="row">
              <div class="col-6 text-center">
                <i class="far fa-eye green"></i> {{ state.keepData.views }}
              </div>
              <div class="col-6 text-center">
                <i class="fab fa-korvue green"></i>
              </div>
            </div>
            <div class="row mt-5 mb-5">
              <div class="col-12 text-center mb-5">
                <h2>
                  {{ state.keepData.name }}
                </h2>
                <h6 class="mt-5 text-grey">
                  {{ state.keepData.description }}
                </h6>
              </div>
            </div>
            <div class="row mt-5 d-flex justify-content-around">
              <router-link data-dismiss="modal" :to="{name: 'Home'}">
                <div class="btn btn-danger bottom-left" @click.prevent="deleteVK(state.keepData.vaultKeepId)">
                  Remove from Vault
                </div>
              </router-link>
              <!-- <div class="dropdown bottom-left">
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
              </div> -->
              <button type="button" class="btn btn-transparent text-danger bottom-middle">
                <i class="fa fa-trash" aria-hidden="true"></i>
              </button>
              <router-link data-dismiss="modal" :to="{name: 'ActiveProfile', params: {profileId: state.keepData.creatorId}}">
                <img class="tiny-picture left-side " :src="state.keepData.creator.picture" alt="">
              </router-link>
              <p class="mt-3 bottom-right">
                {{ state.keepData.creator.name }}
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { vaultsService } from '../services/VaultsService'
import swal from 'sweetalert'
export default {
  name: 'VaultKeepsComponent',
  props: ['vKProp'],
  setup(props) {
    const state = reactive({
      keepData: props.vKProp
    })
    return {
      state,
      deleteVK(id) {
        swal({
          title: 'Are you sure?',
          text: 'Once deleted, you will not be able to recover this imaginary file!',
          icon: 'warning',
          buttons: true,
          dangerMode: true
        })
          .then((willDelete) => {
            if (willDelete) {
              swal('Poof! Your imaginary file has been deleted!', {
                icon: 'success'
              })
              vaultsService.deleteVK(id)
            } else {
              swal('Your imaginary file is safe!')
            }
          })
      }
    }
  },
  components: {}
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
