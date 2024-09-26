<template>
    <Menu>
        <BoardData :headers="headers" :desserts="desserts"></BoardData>
    </Menu>
</template>
<script setup>
import {ref} from 'vue'
import Menu from '../../components/dashboards/layout/Menu.vue';
import BoardData from '../../components/dashboards/layout/BoardData.vue';
const headers = ref ([
      {name: "Request Number", icon:''},
      {name: "Date", icon:''},
      {name: "Pdf", icon:''}
    ]);
    const desserts = ref ([
      {origin: "1", destination: "2", transport:"3", passengers:"4"},
      {origin: "1",destination: "2",transport:"3", passengers:"4"},
      {origin: "1",destination: "2",transport:"3", passengers:"4"},
    ]);

</script>
<style scoped>
</style>