<script setup>
</script>

<template>
    <v-col cols="12" md="4" sm="6" class="container-btn">
        <v-col cols="auto" class="container-btn">
            <v-btn rounded="xl" size="x-large" class="btn-get" border-b-lg>
                Get Sarted
                <img src="../../assets/icons/flecha-derecha.svg" >
            </v-btn>
        </v-col>
    </v-col>
</template>

<style scoped>
    .container-btn{
        /* display: flex; */
        justify-content: flex-end;
        align-items: flex-start;
        flex-direction: column;
    }
    .btn-get{
        padding: 10px;
        background-color: var(--color-primary-button);
        border-color: var(--color-primary-button);
        
    }

    .btn-get img{
        width: 10%;
        margin-left: 20px;
    }

</style>