<template>
    <div class="add__new--company">
        <div class="pa-4 text-center">
                    <v-dialog
                    v-model="dialog"
                    min-width="200"
                    max-width="600"
                    >
                    <template v-slot:activator="{ props: activatorProps }">
                        <v-btn
                        class="text-none font-weight-regular"
                        prepend-icon="mdi-account-tie"
                        text="New company"
                        variant="tonal"
                        color="green-darken-4"
                        v-bind="activatorProps"
                        ></v-btn>
                    </template>

                    <v-card
                        class="d-flex text-center text-green-darken-4 "
                        prepend-icon="mdi-account-tie-woman"
                        title="Add a new company administrator"
                    >
                    <v-card-text>
                        <SignUp>
                            <AddCompany></AddCompany>
                        </SignUp>
                    </v-card-text>
                    </v-card>
                    </v-dialog>
                </div>
    </div>
</template>

<script setup>
import {ref} from 'vue'
import SignUp from '../../forms/people/register/SignUp.vue';
import AddCompany from './AddCompany.vue';

const dialog = ref(false)
</script>

