<template>
  <div class="vaultNamesComponent">
    <button class="btn btn-transparent">
      {{ profileVaults.name }}
    </button>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'

export default {
  name: 'VaultNamesComponent',
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

</style>
