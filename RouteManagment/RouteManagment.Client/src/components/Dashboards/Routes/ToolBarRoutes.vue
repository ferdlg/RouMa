<template>
        <v-card>
            <v-toolbar
            >
            <slot>
                <AddForm></AddForm>
            </slot>
            </v-toolbar>
        </v-card>
</template>

<script setup>
import {ref} from 'vue'
import AddForm from './AddForm.vue';
</script>
<style scoped>

</style>