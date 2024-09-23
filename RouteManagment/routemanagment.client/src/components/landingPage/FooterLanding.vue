
<template>
      <v-footer>{{footer.date}}|{{footer.projectName}}</v-footer>
</template>

<script setup>
import {ref} from 'vue';
   const footer = ref(
      {
    date: 2024,
    projectName: 'RouMa'
   }
)
</script>
<style>
</style>