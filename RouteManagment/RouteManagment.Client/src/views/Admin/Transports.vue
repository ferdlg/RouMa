<template>
    <Menu>
        <ToolBarTransport></ToolBarTransport>
        <Gallery :objects="objects" :fields="fields"></Gallery>
    </Menu>
</template>
<script setup>
import {ref} from 'vue'
import Menu from "../../components/dashboards/layout/Menu.vue";
import Gallery from "../../components/dashboards/layout/Gallery.vue";
import ToolBarTransport from '../../components/dashboards/transport/ToolBarTransport.vue';



const objects = ref([
    {id:'AWS203'},
    {id:'AWS203'},
    {id:'AWS203'},
    {id:'AWS203'},
    {id:'AWS203'}
]);
const fields = ref([
    {name:'Route: ', id:1},
    {name:'Capacity: ', id:15},
    {name:'Passengers: ', id:11},
]);
</script>
<style scoped>
</style>