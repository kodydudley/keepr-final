<template>
  <div class="profileVaultsComponent card border-0">
    <router-link :to="{name: 'VaultPage', params:{vaultId: vaultProp.id}}">
      <img :src="profileVaults.img" class="img-fluid round" alt="">
      <div class="card-img-overlay d-flex justify-content-end flex-column text-light">
        <h6 class="text-left text-light">
          {{ profileVaults.name }}
        </h6>
      </div>
      <div class="card-img-overlay d-flex justify-content-right">
        <router-link :to="{name: 'Profile', params: {profileId: profileVaults.creatorId}}">
          <img class="tiny-picture left-side " :src="profileVaults.creator.picture" alt="">
        </router-link>
      </div>
    </router-link>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
// import { AppState } from '../AppState'
// import CreateKeepComponent from '../components/CreateKeepComponent'
// import CreateVaultComponent from '../components/CreateVaultComponent'
// import ProfileKeepsComponent from '../components/ProfileKeepsComponent'
// import { profileService } from '../services/ProfileService'
// import { useRoute } from 'vue-router'
export default {
  name: 'ProfileVaultsComponent',
  props: ['vaultProp'],
  setup(props) {
    const state = reactive({
    })
    return {
      state,
      profileVaults: computed(() => props.vaultProp)

    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.round{
  border-radius: 15px;
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

</style>
