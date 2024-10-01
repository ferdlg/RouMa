<template>
    <v-row >
        <v-col  justify="center"
        class="d-flex child-flex justify-center "
        v-for="object, index in objects" :key="index">
        <v-card class="gallery__card"
        :title=object.id
        >
        <v-card-text>
            <p v-for="field, index in fields" :key="index">{{field.name}} {{field.id}}</p>
            <v-img>Img</v-img>
        </v-card-text>
        </v-card>
        </v-col>
    </v-row>
</template>
<script setup>
import {defineProps} from 'vue'

const props=defineProps({
    objects:{
        type:Array,
        required:true
    },
    fields:{
        type:Array,
        required:true
    }
});

const getItemValue = (item, index)=>{
    const keys = Object.keys(item)
    return item[keys[index]]
}

</script>
<style scoped>
.gallery__card{ 
    min-width: 200px;
    min-height: 200px;
}

</style>