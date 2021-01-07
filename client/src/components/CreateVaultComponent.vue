<template>
  <div class="createVaultComponent">
    <button class="green pl-2 btn-transparent btn mt-2" data-toggle="modal" data-target="#CreateVaultModal">
      <i class="fa fa-plus fa-2x" aria-hidden="true"></i>
    </button>
  </div>

  <!-- MODAL SECTION -->
  <div class="modal fade"
       id="CreateVaultModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">
            New Vault
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form action="" @submit.prevent="create(state.newVault)">
            <h6 class="my-2">
              Title
            </h6>
            <input class="form-control"
                   type="text"
                   v-model="state.newVault.name"
                   placeholder="Title..."
                   required
            >
            <h6 class="my-2">
              Image Url
            </h6>
            <input class="form-control" v-model="state.newVault.img" type="text" placeholder="URL..." required>
            <textarea class="form-control"
                      name=""
                      id=""
                      cols="10"
                      rows="10"
                      v-model="state.newVault.description"
                      placeholder="Description..."
            >Description</textarea>
            <div class="form-check mt-2">
              <input type="checkbox" class="form-check-input" id="exampleCheck1" v-model="state.newVault.isPrivate">
              <label class="form-check-label" for="exampleCheck1">Private?</label>
              <small class="form-text text-muted">Private Vaults can only be seen by you.</small>
            </div>
            <div>
              <button type="submit" class="btn greenBG mt-4 float-right">
                Create
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'CreatVaultComponent',
  setup() {
    const state = reactive({
      newVault: {
        name: '',
        img: '',
        description: '',
        isPrivate: false
      }
    })
    return {
      state,
      create(newVault) {
        vaultsService.create(newVault)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.green{
  color: #55EFC4;
}
.greenBG{
  background-color: #55EFC4;
}

</style>
