<template>
  <div class="vaultPage">
    <div class="row mt-5">
      <div class="col-12 ml-5 header">
        {{ activeVault.name }}
        <button v-show="profile.id == activeVault.creatorId" class="btn btn-transparent" @click.prevent="deleteVault(activeVault.id)">
          <i class="fa fa-trash text-danger" aria-hidden="true"></i>
        </button>
      </div>
    </div>
    <div class="row">
      <div class="col-8 offset-2">
        <h6>
          Keeps: {{ activeVaultKeeps.length }}
        </h6>
      </div>
    </div>
    <div class="flex-grow-1 d-flex container-fluid align-items-center"></div>
    <div class="col-10 offset-1 mt-5">
      <div class="card-columns">
        <vaultKeepsComponent v-for="vaultKeep in activeVaultKeeps" :v-k-prop="vaultKeep" :key="vaultKeep" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
import swal from 'sweetalert'

// import { keepsService } from '../services/KeepsService'
export default {
  name: 'VaultPage',
  setup(props) {
    const route = useRoute()
    onMounted(() => {
      // keepsService.getPublicKeeps()
      vaultsService.getVaultKeepsById(route.params.vaultId)
      vaultsService.getById(route.params.vaultId)
    })
    return {
      deleteVault(id) {
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
              vaultsService.deleteVault(id)
            } else {
              swal('Your imaginary file is safe!')
            }
          })
      },
      // keeps: computed(() => AppState.keeps)
      activeVaultKeeps: computed(() => AppState.activeVaultKeeps),
      activeVault: computed(() => AppState.activeVault),
      profile: computed(() => AppState.profile)

    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }

}
.header{
  font-size: 3em;
}
@media (min-width: 12em) {
    .card-columns {
        -webkit-column-count: 2;
        -moz-column-count: 2;
        column-count: 2;
    }
}

@media (min-width: 48em) {
    .card-columns {
        -webkit-column-count: 3;
        -moz-column-count: 3;
        column-count: 3;
    }
}

@media (min-width: 62em) {
    .card-columns {
        -webkit-column-count: 4;
        -moz-column-count: 4;
        column-count: 4;
    }
}

@media (min-width: 75em) {
    .card-columns {
        -webkit-column-count: 4;
        -moz-column-count: 4;
        column-count: 4;
    }
}
</style>
