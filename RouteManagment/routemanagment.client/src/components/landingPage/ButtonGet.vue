<script setup>
</script>

<template>
    <div class="container-btn">
        <button class="btn-get" type="button"><p>Get Stared</p></button>
    </div>
</template>

<style scoped>
    .container-btn{
        display: flex; 
        justify-content: flex-end;
        align-items: flex-start;
        flex-direction: column;
        width: 50%;
    }
    .btn-get{
        padding: 3% 1% 3% 1%;
        width: 100%;
        background-color: var(--color-secundary-background);
        border-radius: 50px;
        border-style: inset;
    }
    .btn-get b{
        font-weight: 300;
    }

</style>