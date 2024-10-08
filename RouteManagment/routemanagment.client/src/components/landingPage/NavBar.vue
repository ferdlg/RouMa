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
<style src="../../assets/css/components/landingPage/nav-bar.css">
</style>
