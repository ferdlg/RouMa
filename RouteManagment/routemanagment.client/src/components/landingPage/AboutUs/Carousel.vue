<script setup>
  import slide1 from '../../../assets/images/slide1.jpg';
  import slide2 from '../../../assets/images/slide2.jpg';
  import slide3 from '../../../assets/images/slide3.jpg';
</script>

<template>
        <v-card
            class="mx-auto"
            elevation="24"
            max-width="444"
          >
            <v-carousel hide-delimiters=""
              :continuous="true"
              :show-arrows="false"
              height="300"
              cycle
              hide-delimiter-background
            >
              <v-carousel-item
                v-for="(slide, i) in slides"
                :key="i"
                :src="slide.src"
              >
              </v-carousel-item>
            </v-carousel>
          </v-card>
</template>

<style scoped>
  
</style>

<script>
  export default {
    data () {
      return {
        slides: [
          {src : slide1},
          {src : slide2},
          {src : slide3}
        ],
      }
    },
  }
</script>