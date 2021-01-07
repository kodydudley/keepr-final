<template>
  <div class="profileKeepsComponent card border-0">
    <img :src="profileKeeps.img" class="img-fluid round" alt="">
    <div class="card-img-overlay d-flex justify-content-end flex-column text-light">
      <h6 class="text-left text-white">
        {{ profileKeeps.name }}
      </h6>
    </div>
    <div class="card-img-overlay d-flex justify-content-right">
      <router-link :to="{name: 'Profile', params: {profileId: profileKeeps.creatorId}}">
        <img class="tiny-picture left-side " :src="profileKeeps.creator.picture" alt="">
      </router-link>
    </div>
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
  name: 'ProfileKeepsComponent',
  props: ['keepProp'],
  setup(props) {
    const state = reactive({
    })
    return {
      state,
      profileKeeps: computed(() => props.keepProp)

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
