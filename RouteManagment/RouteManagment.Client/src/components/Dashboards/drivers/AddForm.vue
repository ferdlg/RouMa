<template>
    <div class="add__new--driver">
        <div class="pa-4 text-center">
                    <v-dialog
                    v-model="dialog"
                    min-width="200"
                    max-width="600"
                    >
                    <template v-slot:activator="{ props: activatorProps }">
                        <v-btn
                        class="text-none font-weight-regular"
                        prepend-icon="mdi-steering"
                        text="New driver"
                        variant="tonal"
                        color="blue-darken-4"
                        v-bind="activatorProps"
                        ></v-btn>
                    </template>

                    <v-card
                        class="d-flex text-center text-blue-darken-4"
                        prepend-icon="mdi-steering"
                        title="Add a new driver"
                    >
                    <v-card-text>
                        <SignUp></SignUp>
                    </v-card-text>
                    </v-card>
                    </v-dialog>
                </div>
    </div>
</template>
<script setup>
import {ref} from 'vue'
import SignUp from '../../forms/people/register/SignUp.vue';

const dialog = ref(false)
</script>
<style>
</style>