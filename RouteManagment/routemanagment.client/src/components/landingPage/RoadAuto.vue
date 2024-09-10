<script setup>
</script>

<template>
    <div class="container-road">
        <img src="../../assets/svg/road.svg" alt="road svg">
    </div>

    <div class="container-auto">
        <img src="../../assets/svg/auto.svg" alt="auto svg">
    </div>
</template>

<style scoped>
    .container-road{
        flex-direction: column;
        justify-content: flex-end;
        align-items: flex-start;
        margin-top: auto;

    }
    /* .road{
        display: flex;
        flex-direction: column;
        justify-content: flex-end;
        align-items: flex-start;
     
    } */
    .container-road img{
        min-width: 100%;
        max-width: 100%;
    }

    .container-auto{
        display: grid;
    }
    .container-auto img{
        margin: auto;
        min-width: 100%;
        max-width: 100%;
        margin-bottom: 22%;
    }
</style>