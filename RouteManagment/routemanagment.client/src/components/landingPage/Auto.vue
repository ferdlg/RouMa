
<template>
    <div class="container">
        <img class="container__auto" src="../../assets/svg/auto.svg" alt="auto svg">
    </div>
</template>

<script setup>
import ButtonGet from './ButtonGet.vue';
</script>
<style scoped>
    .container{
        max-height: 50%;
        width: 100%;
    }
    .container__auto{
        min-width: 50%;
        max-width: 50%;
        margin-bottom: 12%;
    }
</style>