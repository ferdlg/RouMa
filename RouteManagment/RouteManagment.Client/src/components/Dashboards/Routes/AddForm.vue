<template>
    <div class="add__new--route">
                    <div class="pa-4 text-center">
                    <v-dialog
                    v-model="dialog"
                    min-width="200"
                    max-width="600"
                    >
                    <template v-slot:activator="{ props: activatorProps }">
                        <v-btn
                        class="text-none font-weight-regular"
                        prepend-icon="mdi-routes"
                        text="New route"
                        variant="tonal"
                        color="green-darken-3"
                        v-bind="activatorProps"
                        ></v-btn>
                    </template>

                    <v-card
                        color="grey-lighten-5"
                        prepend-icon="mdi-routes"
                        title="Add a new route"
                        class="text-purple-darken-4"
                    >
                    <stepper></stepper>
                    </v-card>
                    </v-dialog>
                </div>
    </div>
                <v-spacer></v-spacer>
               
</template>

<script setup>
import {ref} from 'vue'
import Stepper from './Stepper.vue';
    
    const dialog = ref(false)
</script>

<style scoped>
</style>