<script setup>
</script>

<template>
    <v-col cols="12" md="4" sm="6" class="container-btn">
        <v-btn rounded="xl" size="x-large" block class="btn-get">Get Started</v-btn>
    </v-col>
</template>

<style scoped>
    .container-btn{
        display: flex;
        justify-content: flex-end;
        align-items: flex-start;
        flex-direction: column;
    }
    .btn-get{
        background-color: var(--color-primary-button);
        border-color: var(--color-primary-button);
    }
</style>