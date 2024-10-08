<template>
    <Menu>
            <div class="contain__toolBar-drivers">
                <ToolBarDriver></ToolBarDriver>
            </div>
            <v-row>
                <v-col>
                    <div class="contain__gallery-drivers">
                        <Gallery :objects="objects" :fields="fields"></Gallery>
                    </div>
                </v-col>
                <v-col>
                    <v-row>
                        <v-col cols="24" md="12" lg="6">
                            <TransportDriver></TransportDriver>
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col cols="24" md="12" lg="6" align-self="end">
                            <RouteDriver></RouteDriver>
                        </v-col>
                    </v-row>
                </v-col>
            </v-row>
    </Menu>
</template>
<script setup>
import {ref} from 'vue'
import Menu from "../../components/dashboards/layout/Menu.vue";
import Gallery from "../../components/dashboards/layout/Gallery.vue";
import ToolBarDriver from '../../components/dashboards/drivers/ToolBarDriver.vue';
import TransportDriver from '../../components/dashboards/drivers/TransportDriver.vue';
import RouteDriver from '../../components/dashboards/drivers/RouteDriver.vue'

const select = ref(false)
const objects = ref([
    {id:987654321},
    {id:987654322},
    {id:987654323},
    {id:987654324},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
    {id:987654325},
]);
const fields = ref([
    {name:'Transport: ', id:1},
    {name:'Route: ', id:1},
    {name:'License driving: ', id:1},
]);
</script>
<style scoped>
</style>