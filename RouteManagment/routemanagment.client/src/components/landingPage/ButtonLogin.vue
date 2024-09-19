<script setup>
    import {useRouter} from 'vue-router';

    const router = useRouter();
    const navigateToSignIn = ()=>{
        router.push({name: 'SignIn'})
    };
</script>

<template>
    <v-btn 
    @click="navigateToSignIn"
    class="btn" 
    elevation="8">
        Login
        <v-icon class="btn__icon-login">mdi-login</v-icon>
    </v-btn>
</template>

<style scoped>
    .btn{
        background-color: var(--color-secundary-background);
        /* border-color: var(--color-secundary-background); */
        color: black;
        border-radius: 30px;
        border-color: transparent;
    }
</style>