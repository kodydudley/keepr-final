<template>
  <div class="vaultNamesComponent">
    {{ profileVaults.name }}
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
