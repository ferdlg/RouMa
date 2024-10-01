<template>
<div class="add__new--transport">
        <div class="pa-4 text-center">
                    <v-dialog
                    v-model="dialog"
                    min-width="200"
                    max-width="600"
                    >
                    <template v-slot:activator="{ props: activatorProps }">
                        <v-btn
                        class="text-none font-weight-regular"
                        prepend-icon="mdi-train-car"
                        text="New transport"
                        variant="tonal"
                        color="orange-darken-3"
                        v-bind="activatorProps"
                        ></v-btn>
                    </template>

                    <v-card
                        class="d-flex text-center text-orange-darken-3"
                        prepend-icon="mdi-train-car"
                        title="Add a new transport"
                    >
                    <v-card-text>
                        <AddFormT></AddFormT>
                    </v-card-text>
                    </v-card>
                    </v-dialog>
                </div>
    </div>
</template>
<script setup>
import {ref} from 'vue'
import AddFormT from '../../forms/transport/AddFormT.vue';

const dialog = ref(false)

</script>
