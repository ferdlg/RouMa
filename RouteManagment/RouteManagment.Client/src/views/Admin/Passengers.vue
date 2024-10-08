<template>
    <Menu>
        <ToolBarPassenger></ToolBarPassenger>
        <Gallery :objects="objects" :fields="fields"></Gallery>
    </Menu>
   
</template>
<script setup>
import{ref} from 'vue'
import Menu from "../../components/dashboards/layout/Menu.vue";
import Gallery from "../../components/dashboards/layout/Gallery.vue";
import ToolBarPassenger from '../../components/dashboards/passengers/ToolBarPassenger.vue';

const objects = ref([
    {id:987654325},
    {id:987654326},
    {id:987654327},
    {id:987654328},
    {id:987654329}
]);
const fields = ref([
    {name:'Transport: ', id:1},
    {name:'Company: ', id:1},
    {name:'Route: ', id:1},
]);

</script>
<style scoped>
</style>