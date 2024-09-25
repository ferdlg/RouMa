<template>
   <v-responsive>
     <v-app-bar class="nav-bar d-flex">
         <v-toolbar-title>
          <a href="#/" class="nav-link">V1.0.0</a>
          </v-toolbar-title>
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
    justify-content: space-between;
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

  .nav-list-item{
    margin: 0 10px;
  }
  .nav-link{
    color: white;
    text-decoration: none;
  }
  .nav-link:hover{
    color: var(--color-secundary-background);
  }

  @media (max-width: 768px){

    .nav-list{
      flex-direction: row;
    }
    .nav-list-item{
      margin: 5px 0;
    }
  }
</style>
