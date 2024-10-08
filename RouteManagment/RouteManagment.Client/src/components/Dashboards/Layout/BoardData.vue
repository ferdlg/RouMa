<template>
        <v-card class="card">
            <v-data-table 
                color="green"
                height="300px"
                fixed-header
            >
                <thead>
                <tr>
                    <th v-for="header, index in headers" :key="index" class="text-left">
                    {{header.name}}
                    </th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                <tr  v-for="item, value in desserts" :key="value">
                    <td v-for="header, index in headers" :key="index">
                        {{getItemValue(item, index)}}
                    </td>
                    <td class="d-flex">
                        <EditInfo></EditInfo>
                        <Remove></Remove>
                    </td>
                </tr>
                </tbody>
            </v-data-table>
        </v-card>
    
    </template>

<script setup>
import {defineProps} from 'vue'
import EditInfo from './EditInfo.vue'
import Remove from './Remove.vue';
const props = defineProps({
    headers:{
        type: Array,
        required:true,
    },
    desserts:{
        type: Array,
        required: true,
    },
});

    const getItemValue = (item,index)=>{
            const keys = Object.keys(item)
            return item[keys[index]];
    };

</script>
<style scoped>
.card{
    margin-top: 1em;
}
</style>