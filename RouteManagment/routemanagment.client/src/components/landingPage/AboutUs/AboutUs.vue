<script setup>
import Parallax from './Parallax.vue'
import Carousel from './Carousel.vue'
import TextCard from './TextCard.vue'
import ListItems from './ListItems.vue'
</script>

<template>
    <v-container class="container-card">
        <Parallax/>
        <Carousel/>
        <TextCard/>
        <ListItems/>
    </v-container>
</template>

<style scoped>
    .container-card{
        background-color: aliceblue;
    }
</style>