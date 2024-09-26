
<template>
    <Parallax/>
    <v-container>
        <div class="section">
            <div class="section__carousel">
                <Carousel/>
            </div>
            <div class="section__text-card">
                <TextCard/>
            </div>
            <div class="section__list-items">
                <ListItems/>
            </div>
        </div>
    </v-container>
</template>

<script setup>
import Parallax from './Parallax.vue'
import Carousel from './Carousel.vue'
import TextCard from './TextCard.vue'
import ListItems from './ListItems.vue'
</script>
<style src="../../../assets/css/components/landingPage/aboutUs/about-us.css"></style>