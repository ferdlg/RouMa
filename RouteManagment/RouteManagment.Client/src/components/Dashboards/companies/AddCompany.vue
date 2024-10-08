<template>
    <div class="text-subtitle-1 text-center  text-blue-darken-4">Company<v-icon icon="mdi-domain"></v-icon></div>
    <form @submit.prevent="submit">
                <v-container>
                    <v-row>
                        <v-col>
                            <div class="text-subtitle-2 text-start  text-blue-darken-4">Company name</div>
                            <v-text-field
                            v-model="name.value.value"
                            placeholder="Company name "
                            density="compact"
                            variant="outlined"
                            rounded
                            ></v-text-field>
                        </v-col>
                        <v-col>
                            <div class="text-subtitle-2 text-start  text-blue-darken-4">Logo</div>
                            <v-file-input
                            density="compact"
                                prepend-icon="mdi-camera"
                                variant="outlined"
                                rounded
                                
                            >
                            </v-file-input>
                        </v-col>
                    </v-row>
                </v-container>
        </form>
</template>

<script setup>
import {ref} from 'vue'
import {useField, useForm} from 'vee-validate'

const name = useField('name') 


</script>