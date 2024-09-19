<script setup>
import Parallax from './Parallax.vue'
import Carousel from './Carousel.vue'
import TextCard from './TextCard.vue'
import ListItems from './ListItems.vue'
</script>

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

<style scoped>
.section{
    /* background-color: rgba(137, 43, 226, 0.11); */
    padding: 5%;
    display: grid;
    grid-template-areas: "card carousel" "list list" ;
    grid-template-columns: 1fr 1fr ;
    grid-gap: 2rem;
}

.section__carousel{
    grid-area: carousel ;
}
.section__text-card{
    grid-area: card;
    display: flex;
    justify-content: flex-end;
}
.section__list-items{
    grid-area: list;
    padding: 1%;
}

</style>