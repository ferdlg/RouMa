<script setup>
import Parallax from './Parallax.vue'
import Carousel from './Carousel.vue'
import TextCard from './TextCard.vue'
import ListItems from './ListItems.vue'
</script>

<template>
    <Parallax/>
    <div class="container-items">
        <div class="container-carousel">
            <Carousel/>
        </div>
        <div class="container-text-card">
            <TextCard/>
        </div>
        <div class="container-list-items">
            <ListItems/>
        </div>
    </div>
</template>

<style scoped>
.container-items{
    /* background-color: rgba(137, 43, 226, 0.11); */
    padding: 5%;
    display: grid;
    grid-template-areas: "carousel card" "list list" ;
    grid-template-columns: 1fr 1fr;
    grid-gap: 2rem;
}

.container-items .container-carousel{
    grid-area: carousel ;
}
.container-items .container-text-card{
    grid-area: card;
    display: flex;
    align-items: center;  
}
.container-items .container-list-items{
    grid-area: list;
    padding: 1%;
}

</style>