<script setup>
</script>

<template>
    <section class="container-road-auto">
        <div class="road">
            <img src="../../assets/svg/road.svg" alt="road svg">
        </div>
        <div class="auto">
            <img src="../../assets/svg/auto.svg" alt="auto svg">
        </div>
    </section>
</template>

<style scoped>
    .container-road-auto{
        background-color: pink;
        display: flex;
        margin: 0;
    }
    .road{
        display: flex;
        flex-direction: column;
        justify-content: flex-end;
        align-items: flex-start;
        max-width: 95%;
        max-height: 100vh;
    }
    .road img{
        max-width: 95%;
    }

    .auto{
        background-color: blueviolet;
        padding: 10px;
    }
</style>