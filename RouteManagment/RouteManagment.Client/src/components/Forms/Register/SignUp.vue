<template>
    <form @submit.prevent="submit">
    <v-text-field
    v-model="firstName.value.value"
    :counter="10"
    label="First Name"
    ></v-text-field>
    <v-text-field
      v-model="lastName.value.value"
      :counter="10"
      label="Last Name"
    ></v-text-field>

    <v-text-field
      v-model="phone.value.value"
      :counter="7"
      label="Phone Number"
      ></v-text-field>

    <v-text-field
      v-model="email.value.value"
      label="E-mail"
      ></v-text-field>

    <v-select
      v-model="documentType.value.value"
      :items="typesD"
      label="Select"
    ></v-select>
    <v-text-field
      v-model="documentNumber.value.value"
      :counter="7"
      label="Phone Number"
      ></v-text-field>
</form>
<form @submit.prevent="submit">
        <v-select
        v-model="streetTypeId.value.value"
        :items="typesS"
        label="Select"
        ></v-select>
        <v-text-field
        v-model="streetNumber.value.value"
        label="Number"
        ></v-text-field>
        <v-text-field
        v-model="streetName.value.value"
        label="streetName"
        ></v-text-field>
        <v-text-field
        v-model="streetNumber.value.value"
        label="streetNumber"
        ></v-text-field>
        <v-text-field
        v-model="quadrant.value.value"
        label="quadrant"
        ></v-text-field>
        <v-text-field
        v-model="plate.value.value"
        label="plate"
        ></v-text-field>
        <v-text-field
        v-model="prefix.value.value"
        label="prefix"
        ></v-text-field> 
</form>
    <!-- <v-btn
      class="me-4"
      type="submit"
    >
    submit
    </v-btn>
    
    <v-btn @click="handleReset">
      clear
    </v-btn> -->
</template>

<script setup>
import {ref} from 'vue'
import {useField, useForm} from 'vee-validate'

const {handleSubmit, handleReset}= useForm({
    validationSchema:{
        firstName(value){
        },
        lastName(value){
        },
        email(value){
        },
        phone(value){
        },
        documentType(value){
        },
        documentNumber(value){
        },
//Files address form

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
})

const firstName = useField('firstName')
const lastName = useField('lastName')
const email = useField('email')
const phone = useField('phone')
const documentType = useField('documentType')
const documentNumber = useField('documentNumber')
const address = useForm('address')

const streetTypeId = useField('streetTypeId')
const streetName = useField('streetName')
const streetNumber = useField('streetNumber')
const quadrant = useField('quadrant')
const plate = useField('plate')
const prefix = useField('prefix')



const typesD= ref([
    'Passport',
    'Id Card'
]);

const typesS = ref([
    'Av',
    'Cra'
])

</script>
<style src="../../../assets/css/components/forms/register/sign-up.css"></style>