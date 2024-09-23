<template>
  <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />
   <v-responsive>
     <v-app-bar class="nav-bar d-flex">
         <v-toolbar-title>V1.0.0</v-toolbar-title>
         <v-toolbar-items class="d-sm-flex">
           <v-list class="nav-list" dense>
             <v-list-item
             v-for="(item, index) in items"
             :key="index"
             class="nav-list-item"
             >
               <v-list-item-icon>
                 <v-icon>{{ item.icon }}</v-icon>
               </v-list-item-icon>
               <v-list-item-content>
                  <a :href="'#'+ item.path" class="nav-link">{{item.text}}</a>
               </v-list-item-content>
             </v-list-item>
             <ButtonLogin/>
           </v-list>
         </v-toolbar-items>
       </v-app-bar>
   </v-responsive>
</template>


<script setup>
    import ButtonLogin from './ButtonLogin.vue';
    import {ref} from "vue";
    
    const items = ref ([
      {text: "About Us", icon:"mdi-information" ,path:'about-us'},
      {text: "Contact Us", icon:"mdi-phone" ,path:'contact-us'},
      {text: "Transports", icon:"mdi-car" ,path:'transports'},
    ]);
</script>
<style scoped>
  .v-app-bar {
    position: fixed;
    top: 0;
    width: 100%;
    z-index: 1000;
  }

  .nav-bar{
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: var(--color-primary-background);
    color: rgba(255, 255, 255, 0.527);
  }
  .btn-login{
    margin: 10px;
  }
  .nav-list{
    display: flex;
    background-color:transparent;
    color:white;
  }

  .nav-link{
    color: white;
    text-decoration: none;
  }
  .nav-link:hover{
    color: var(--color-secundary-background);
  }
</style>
