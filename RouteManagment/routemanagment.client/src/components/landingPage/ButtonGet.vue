<script setup>
</script>

<template>
    <div class="container-btn">
        <v-btn class="btn-get" >
            Get Stared
            <v-icon>mdi-arrow_forward</v-icon>
        </v-btn>
    </div>
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
    }
    

</style>