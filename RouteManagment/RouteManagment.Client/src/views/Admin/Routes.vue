<template>
    <Menu>
            <div class="contain__toolBar">
                <ToolBarRoutes></ToolBarRoutes>
            </div>
            <div class="contain__table">
                <BoardData :headers="headers" :desserts="desserts" class="contain__table-data"></BoardData>
            </div>
            <div class="contain__card">
                <Stops class="contain__card-stops"></Stops>
            </div>
            <div class="contain__map">
                <Map class="contain__map-map"></Map>
            </div>
    </Menu>
   
</template>
<script setup>
import {ref} from 'vue'
import Menu from '../../components/dashboards/layout/Menu.vue'
import ToolBarRoutes from '../../components/dashboards/routes/ToolBarRoutes.vue'
import BoardData from '../../components/dashboards/layout/BoardData.vue'
import Stops from '../../components/dashboards/routes/Stops.vue'
import Map from '../../components/dashboards/routes/Map.vue'


    const headers = ref ([
      {name: "Origin", icon:''},
      {name: "Destination", icon:''},
      {name: "Transport", icon:''},
      {name: "Passengers", icon:''},
      {name: "Open on Map", icon:''},
    ]);
    const desserts = ref ([
      {origin: "1", destination: "2", transport:"3", passengers:"4", openToMap:'link'},
      {origin: "1",destination: "2",transport:"3", passengers:"4", openToMap:'link'},
      {origin: "1",destination: "2",transport:"3", passengers:"4", openToMap:'link'},
    ]);

</script>
<style src="../../assets/css/views/routes.css"></style>