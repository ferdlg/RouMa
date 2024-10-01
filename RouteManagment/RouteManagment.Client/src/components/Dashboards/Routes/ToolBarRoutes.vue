<template>
    <ToolBar>
        <AddForm></AddForm>
        <v-chip color="gray">Select</v-chip>
        <v-btn variant="outline"
        icon="mdi-table-filter"
        ></v-btn>
    </ToolBar>

</template>

<script setup>
import {ref} from 'vue'
import AddForm from './AddForm.vue';
import ToolBar from '../layout/ToolBar.vue';
</script>
<style scoped>

</style>