<template>
  <div class="creatKeepComponent">
    <button class="green pl-2 btn-transparent btn mt-2" data-toggle="modal" data-target="#CreateKeepModal">
      <i class="fa fa-plus fa-2x" aria-hidden="true"></i>
    </button>
  </div>

  <!-- MODAL SECTION -->

  <div class="modal fade"
       id="CreateKeepModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">
            New Keep
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form action="" @submit.prevent="create(state.newKeep)">
            <h6 class="my-2">
              Title
            </h6>
            <input class="form-control"
                   type="text"
                   v-model="state.newKeep.name"
                   placeholder="Title..."
                   required
            >
            <h6 class="my-2">
              Image Url
            </h6>
            <input class="form-control" type="text" v-model="state.newKeep.img" placeholder="URL..." required>
            <h6 class="my-2">
              Description
            </h6>
            <input class="form-control" type="text-area" v-model="state.newKeep.description" placeholder="Keep Description..." required>
            <button class="btn greenBG mt-4 float-right">
              Create
            </button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'CreatKeepComponent',
  setup() {
    const state = reactive({
      newKeep: {
        name: '',
        description: '',
        img: ''
      }
    })
    return {
      state,
      create(newKeep) {
        keepsService.create(newKeep)
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
