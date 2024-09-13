<script setup>
import About from '../../../assets/images/About.jpg'
  
</script>

<template>
    <v-parallax
    height="200"
    :src= "About" >
    <div class="d-flex flex-column fill-height justify-center align-center text-white">
      <h1 class="text-h4 font-weight-thin mb-4">
        About Us
      </h1>
      <h4 class="subheading">
        Home >> About Us
      </h4>
    </div>
  </v-parallax>

</template>

<style scoped>
.container-elements{
    background-color: aliceblue;
}
</style>
<script>
  export default {
    data () {
      return {
        About
      }
    },
  }
</script>