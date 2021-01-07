<template>
  <div class="vaultNamesComponent">
    <button class="btn btn-transparent">
      <div v-if="profile.id == profileVaults.creatorId">
        {{ profileVaults.name }}
      </div>
    </button>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'

export default {
  name: 'VaultNamesComponent',
  props: ['vaultProp'],
  setup(props) {
    const state = reactive({
    })
    return {
      state,
      profile: computed(() => AppState.profile),
      profileVaults: computed(() => props.vaultProp)

    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
