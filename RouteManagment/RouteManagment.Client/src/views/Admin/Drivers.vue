<template>
    <Menu>
        <BoardData :headers="headers" :desserts="desserts"></BoardData>
    </Menu>
</template>
<script setup>
import {ref} from 'vue'
import Menu from "../../components/dashboards/layout/Menu.vue";
import BoardData from "../../components/dashboards/layout/BoardData.vue";


const headers = ref([
    {name:"Documnet number"},
    {name:"Name"},
    {name:"Last Name"},
    {name:"Email"},
    {name:"Driving License"}
]);
const desserts = ref([
    {}
]);
</script>
<style scoped>
</style>