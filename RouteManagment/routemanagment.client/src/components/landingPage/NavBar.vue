<script setup>
    import ButtonLogin from './ButtonLogin.vue';
</script>

<template>
    <v-layout>
      <v-app-bar class="nav-bar" elevation="0" border>
        <v-toolbar-title> V.1.0 </v-toolbar-title>
        <v-list class="d-flex">
          <v-list-item v-for="(item, index) in items" :Key="index">
            <v-list-item-title>{{item}}</v-list-item-title>
          </v-list-item>
        </v-list>
        <v-spacer></v-spacer>
        <div class=".btn-login">
          <ButtonLogin/>
        </div> 
      </v-app-bar>
    </v-layout>
</template>

<style scoped>
  .nav-bar{
    background-color: transparent;
    color: white;
  }
  .btn-login{
    margin:0% 5em 0% 0%;
  }
  .d-flex{
    background-color:transparent;
    color:white;
  }

</style>
<script>
  import {ref, watch} from "vue";

  let items = ref(["About Us","Blog", "How to use"]);
</script>