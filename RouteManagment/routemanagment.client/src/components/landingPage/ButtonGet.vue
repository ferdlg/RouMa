
<template>
    <div class="container"></div>
        <v-btn class="container__btn-get">
            Get Stared
            <v-icon>mdi-trending-neutral</v-icon>
        </v-btn>
</template>

<script setup>
</script>
<style scoped>
    .container{
        display: flex; 
        justify-content: flex-end;
        align-items: flex-start;
        flex-direction: column;
        width: 40%;
    }
    .container__btn-get{
        background-color: var(--color-secundary-background);
        border-radius: 50px;
    }
</style>