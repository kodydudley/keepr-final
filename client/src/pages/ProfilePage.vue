<template>
  <div class="about container-fluid">
    <div class="row mt-5">
      <div class="col-3 text-center my-auto">
        <img class="rounded img-fluid" :src="profile.picture" alt="" />
      </div>
      <div class="col-8">
        <div class="row">
          <div class="header-text">
            {{ profile.name }}
          </div>
        </div>
        <div class="row">
          <div class="subheader-text">
            Vaults:
          </div>
        </div>
        <div class="row">
          <div class="subheader-text">
            Keeps:
          </div>
        </div>
      </div>
    </div>
    <div class="row mt-5">
      <div class="col-10 offset-1">
        <div>
          <span class="section-header">
            Vaults
          </span>
          <span class="green pl-2">
            <i class="fa fa-plus fa-2x" aria-hidden="true"></i>
          </span>
        </div>
      </div>
    </div>
    <div class="row mt-5">
      <div class="col-10 offset-1">
        <div>
          <span class="section-header">
            Keeps
          </span>
          <span class="green pl-2">
            <i class="fa fa-plus fa-2x" aria-hidden="true"></i>
          </span>
        </div>
      </div>
    </div>
    <!-- MODAL SECTIONS -->
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Profile',
  setup() {
    return {
      profile: computed(() => AppState.profile)
    }
  }
}
</script>

<style scoped>
.height{
  height: 20vh;
}

.header-text{
  font-size: 3em;
}
.subheader-text{
  font-size: 2em;
}

.section-header{
  font-size: 2.5em;
}

.green{
  color: #55EFC4;
}

</style>
