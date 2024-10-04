<template>
    <Menu>
        <template v-slot:BarTools>
            <div class="contain__toolBar">
                <ToolBarRoutes></ToolBarRoutes>
            </div>
        </template>
        <template v-slot:other>
            <v-row  align="center">
                <v-col >
                    <BoardData :headers="headers" :desserts="desserts" class="contain__table-data"></BoardData>
                </v-col>
                <v-col >
                    <Map class="contain__map-map"></Map>
                </v-col>
            </v-row>
            <v-row justify="center" align="center">
                <v-col>
                    <Stops class="contain__card-stops"></Stops>
                </v-col>
                <v-col>
                    
                </v-col>
            </v-row>
            <div class="contain__map">
            </div>
        </template>
                
                
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