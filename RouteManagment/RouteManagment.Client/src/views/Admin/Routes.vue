<template>
    <Menu>
        <v-container class="contain">
            <TableRoutes :headers="headers" :desserts="desserts" class="contain__table"></TableRoutes>
            <ToolBarRoutes class="contain__toolBar"></ToolBarRoutes>
            <Map class="contain__map"></Map>
        </v-container>
    </Menu>
   
</template>
<script setup>
import Menu from '../../components/Dashboards/Layout/Menu.vue';
import TableRoutes from '../../components/Dashboards/BoardData.vue';

import {ref} from 'vue'
import ToolBarRoutes from '../../components/Dashboards/Routes/ToolBarRoutes.vue';
import Map from '../../components/Dashboards/Routes/Map.vue';
    const headers = ref ([
      {name: "Origin", icon:''},
      {name: "Destination", icon:''},
      {name: "Transport", icon:''},
      {name: "Passengers", icon:''},
      {name: "Open on Map", icon:''},
    ]);
    const desserts = ref ([
      {origin: "1", destination: "2", transport:"3", passengers:"4"},
      {origin: "1",destination: "2",transport:"3", passengers:"4"},
      {origin: "1",destination: "2",transport:"3", passengers:"4"},
    ]);
</script>
<style scoped>
.contain{
    display: grid;
    grid-template-areas:'table toolBar' 'map map' ;
    grid-template-columns: 2fr 1fr;
}
.contain__table{
    grid-area: table;
}
.contain__toolBar{
    grid-area: toolBar;
}
.contain__map{
    grid-area: map;
}
</style>