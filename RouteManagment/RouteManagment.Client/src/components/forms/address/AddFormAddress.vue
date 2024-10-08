<template>
            <form @submit.prevent="submit">
                <v-container>
                    <v-row>
                        <v-col>
                            <div class="text-subtitle-2 text-start  text-blue-darken-4">Select</div>
                            <v-select
                            density="compact"
                            v-model="streetTypeId.value.value"
                            :items="typesS"
                            placeholder="Select"
                            variant="solo"
                            rounded
                            width="92"
                            ></v-select>
                        </v-col>
                        <v-col>
                            <div class="text-subtitle-2 text-start  text-blue-darken-4">Street name</div>
                            <v-text-field
                            v-model="streetName.value.value"
                            placeholder="Street "
                            density="compact"
                            variant="outlined"
                            rounded
                            ></v-text-field>
                        </v-col>
                        <v-col>
                            <div class="text-subtitle-2 text-start  text-blue-darken-4">Street number</div>
                            <v-text-field
                            v-model="streetNumber.value.value"
                            placeholder="Street"
                            density="compact"
                            variant="outlined"
                            rounded
                            ></v-text-field>
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col>
                            <div class="text-subtitle-2 text-start  text-blue-darken-4">Quadrant</div>
                            <v-text-field
                            v-model="quadrant.value.value"
                            placeholder="Quadrant"
                            density="compact"
                            variant="outlined"
                            rounded
                            ></v-text-field>
                        </v-col>
                        
                        <v-col>
                            <div class="text-subtitle-2 text-start  text-blue-darken-4">Plate</div>
                            <v-text-field
                            v-model="plate.value.value"
                            placeholder="Plate"
                            density="compact"
                            variant="outlined"
                            rounded
                            ></v-text-field>
                        </v-col>
                        <v-col>
                            <div class="text-subtitle-2 text-start  text-blue-darken-4">Prefix</div>
                            <v-text-field
                            v-model="prefix.value.value"
                            placeholder="Prefix"
                            density="compact"
                            variant="outlined"
                            rounded
                            ></v-text-field> 
                        </v-col>
                    </v-row>
                </v-container>
            </form>

</template>
<script setup>
import {ref} from 'vue'
import {useField, useForm} from 'vee-validate'

const {handleSubmit, handleReset} = useForm({
    validationSchema:{
        
        streetTypeId(value){
        },
        streetName(value){
        },
        streetNumber(value){
        },
        quadrant(value){
        },
        plate(value){
        },
        prefix(value){
        },
    },
});

const address = useForm('address')

const streetTypeId = useField('streetTypeId')
const streetName = useField('streetName')
const streetNumber = useField('streetNumber')
const quadrant = useField('quadrant')
const plate = useField('plate')
const prefix = useField('prefix')

const typesS = ref([
    'Av',
    'Cra'
])
</script>
