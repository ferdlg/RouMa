<script setup>
    import ButtonLogin from './ButtonLogin.vue';
</script>
<template>
    <v-layout>
         <v-app-bar class="nav-bar" elevation="0" border >
           <v-toolbar-title> V.1.0 </v-toolbar-title>
           <v-spacer></v-spacer>
           <v-list class="nav-list" dense>
             <v-list-item v-for="(item, index) in items" :Key="index">
                <v-icon>{{ item.icon }}</v-icon>
               <v-list-item-title >{{item.text}}</v-list-item-title>
             </v-list-item>
           </v-list>
           <v-spacer></v-spacer>
           <div class=".btn-login">
             <ButtonLogin/>
           </div> 
           <v-spacer></v-spacer>
         </v-app-bar>
       </v-layout>
</template>
<script>
    import {ref} from "vue";
    
    const items = ref ([
      {text: "About Us", icon:"mdi-information"},
      {text: "Blog", icon:"mdi-newspaper"},
      {text: "How to use", icon:"mdi-help-circle"},
    ]);
</script> 

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
  .nav-list{
    display: flex;
    background-color:transparent;
    color:white;
  }
</style>
