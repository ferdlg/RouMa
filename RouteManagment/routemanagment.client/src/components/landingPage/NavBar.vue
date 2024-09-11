<script setup>
    import ButtonLogin from './ButtonLogin.vue';
</script>
<template>
  <div class="container-nav">
    <v-layout>
         <v-app-bar class="nav-bar" elevation="0" border >
           <v-toolbar-title> V.1.0 </v-toolbar-title>
           <v-spacer></v-spacer>
           <v-list class="d-flex">
             <v-list-item v-for="(item, index) in items" :Key="index">
               <v-list-item-title>{{item}}</v-list-item-title>
             </v-list-item>
           </v-list>
           <v-spacer></v-spacer>
           <div class=".btn-login">
             <ButtonLogin/>
           </div> 
           <v-spacer></v-spacer>
         </v-app-bar>
       </v-layout>
  </div>
</template>

<style scoped>
  .nav-bar{
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: var(--color-primary-background);
    color: white;
  }
  .btn-login{
    margin: 10px;
  }
  .d-flex{
    background-color:transparent;
    color:white;
  }
</style>

<script>
    import {ref, watch} from "vue";
    let items = ref(["About Us", "Blog", "How to use"]);
</script> 