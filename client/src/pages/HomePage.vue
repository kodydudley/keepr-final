<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="row">
      <keepComponent v-for="keep in keeps" :keep-prop="keep" :key="keep.id" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'Home',
  setup() {
    onMounted(() => {
      keepsService.getPublicKeeps()
    })
    return {
      keeps: computed(() => AppState.keeps)
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
</style>
