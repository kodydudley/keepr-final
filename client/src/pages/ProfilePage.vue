<template>
  <div class="about container-fluid">
    <div class="row mt-5">
      <div class="col-3 text-center my-auto">
        <img class="rounded img-fluid" :src="activeProfile.picture" alt="" />
      </div>
      <div class="col-8">
        <div class="row">
          <div class="header-text">
            {{ activeProfile.name }}
          </div>
        </div>
        <div class="row">
          <div class="subheader-text">
            Vaults: {{ profileVaults.length }}
          </div>
        </div>
        <div class="row">
          <div class="subheader-text">
            Keeps: {{ profileKeeps.length }}
          </div>
        </div>
      </div>
    </div>
    <div class="row mt-5">
      <div class="col-10 offset-1 d-flex">
        <div class="section-header">
          Vaults
        </div>
        <create-vault-component />
      </div>
    </div>
    <div class="col-10 offset-1 mt-5">
      <div class="card-columns">
        <profileVaultsComponent v-for="vault in profileVaults" :key="vault.id" :vault-prop="vault" />
      </div>
    </div>
    <div class="row mt-5 ">
      <div class="col-10 offset-1 d-flex">
        <div class="section-header">
          Keeps
        </div>
        <create-keep-component />
      </div>
    </div>
    <div class="col-10 offset-1 mt-5">
      <div class="card-columns">
        <profileKeepsComponent v-for="keep in profileKeeps" :key="keep.id" :keep-prop="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import CreateKeepComponent from '../components/CreateKeepComponent'
import CreateVaultComponent from '../components/CreateVaultComponent'
import ProfileKeepsComponent from '../components/ProfileKeepsComponent'
import ProfileVaultsComponent from '../components/ProfileVaultsComponent'
import { profileService } from '../services/ProfileService'
import { useRoute } from 'vue-router'
export default {
  name: 'Profile',
  setup() {
    const route = useRoute()
    onMounted(() => {
      profileService.getProfileById(route.params.profileId)
      profileService.getProfileKeeps(route.params.profileId)
      profileService.getProfileVaults(route.params.profileId)
    })
    return {
      activeProfile: computed(() => AppState.activeProfile),
      profileKeeps: computed(() => AppState.profileKeeps),
      profileVaults: computed(() => AppState.profileVaults)
    }
  },
  components: { CreateKeepComponent, CreateVaultComponent, ProfileKeepsComponent, ProfileVaultsComponent }
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
