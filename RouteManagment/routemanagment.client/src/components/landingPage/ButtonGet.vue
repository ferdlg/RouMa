<script setup>
</script>

<template>
    <div class="container-btn"></div>
        <v-btn class="btn-get">
            Get Stared
            <v-icon>mdi-trending-neutral</v-icon>
        </v-btn>
</template>

<style scoped>
    .container-btn{
        display: flex; 
        justify-content: flex-end;
        align-items: flex-start;
        flex-direction: column;
        width: 40%;
    }
    .btn-get{
        background-color: var(--color-secundary-background);
        border-radius: 50px;
    }
    

</style>