<template>
    <v-container>
        <v-table density="comfortable" hover="true">
            <thead>
                <tr>
                    <th v-for="header, index in headers " :key="index">{{header.name}}</th>
                    
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>wy</td>
                </tr>
            </tbody>
        </v-table>
    </v-container>
</template>
<script setup>
    import {defineProps} from 'vue'
    const props = defineProps({
        headers:{
            type:Array,
            required: true,
        },
        desserts:{
            type:Array,
            required: true,
        },
    });
    const getItemValue = (item, index) =>{
        const keys = Object.keys(item)
        return item[keys[index]];
    };
</script>

<style>
</style>