<template>
  <div class="keepComponent col-2 my-3 p-0 justify-content-between">
    <div class="col-10 offset-1">
      <button type="button" data-toggle="modal" data-target=".keepModal" class="border border-none p-0 m-0">
        <img class="img-fluid" :src="keep.img" alt="">
      </button>
    </div>
    <!-- MODAL SECTION -->
    <div class="modal fade keepModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="row">
            <div class="col-6"></div>
            <div class="col-5">
              <div class="row">
                <h2>
                  {{ keep.name }} plus more stuff to see what happens
                </h2>
              </div>
              <div class="row">
                <h6>{{ keep.description }}</h6>
              </div>
              <div class="row mt-5">
                <button class="btn btn-success">
                  Add to Vualt
                </button>
                <button class="btn btn-transparent text-danger">
                  <i class="fa fa-trash" aria-hidden="true"></i>
                </button>
                <img class="small-picture" :src="keep.creator.picture" alt="">
                {{ keep.creator.name }}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'KeepComponent',
  props: ['keepProp'],
  setup(props) {
    return {
      keep: computed(() => props.keepProp)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.small-picture{
  height: 50px;
}

</style>
