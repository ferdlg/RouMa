
<template>
            <v-carousel hide-delimiters
            :continuous="true"
            :show-arrows="false"
            height="300"
            cycle
            hide-delimiter-background
            >
              <v-carousel-item class="carousel-item"
              v-for="(slide, i) in slides"
              :key="i"
              :src="slide.src"
              >
              </v-carousel-item>
            </v-carousel>
          
</template>

<script setup>
  import {ref} from "vue";
  import slide1 from '../../../assets/images/slide1.jpg';
  import slide2 from '../../../assets/images/slide2.jpg';
  import slide3 from '../../../assets/images/slide3.jpg';


  const slides = ref([
          {src : slide1},
          {src : slide2},
          {src : slide3}
        ],
  )
</script>
<style scoped>
</style>

