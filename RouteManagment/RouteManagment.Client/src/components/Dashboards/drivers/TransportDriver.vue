<template>
    <v-card class="mx-auto" max-width="500">
    <v-img 
    class="align-end" 
    :src="card.src" 
    height="200px" 
    gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
    cover>
          <v-card-title class="text-white  aling-end">{{ card.title }}</v-card-title>
    </v-img>
    </v-card>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import slide3 from '../../../assets/images/slide3.jpg';
  
  const card = ref({
    title: 'Transport (Placa)',
    src: slide3,
  });
  </script>
  