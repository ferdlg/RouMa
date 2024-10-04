<template>
  <v-card color="white">
      <form @submit.prevent="submit">
        <v-container>
          <v-row>
            <v-col>
              <div class="text-subtitle-1 text-start text-blue-darken-4">First Name *</div>
              <v-text-field
              density="compact"
              placeholder="First Name"
              variant="outlined"
              v-model="firstName.value.value"
              :counter="10"
              rounded
              ></v-text-field>
            </v-col>
            <v-col>
              <div class="text-subtitle-1 text-start text-blue-darken-4">Last Name *</div>
              <v-text-field
                density="compact"
                placeholder="Last Name"
                v-model="lastName.value.value"
                :counter="10"
                variant="outlined"
                rounded
              ></v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col>
              <div class="text-subtitle-1 text-start text-blue-darken-4">Phone Number  <v-icon icon="mdi-phone"></v-icon> *</div>
              <v-text-field
                density="compact"
                placeholder="Phone Number"
                v-model="phone.value.value"
                :counter="7"
                variant="outlined"
                rounded
                ></v-text-field>
            </v-col>
            <v-col>
              <div class="text-subtitle-1 text-start text-blue-darken-4">E-mail <v-icon icon="mdi-at" ></v-icon>*</div>
              <v-text-field
                density="compact"
                v-model="email.value.value"
                placeholder="E-mail"
                variant="outlined"
                rounded
                compact
              ></v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col>
              <div class="text-subtitle-1 text-start text-blue-darken-4">Document type *</div>
              <v-select
                density="compact"
                v-model="documentType.value.value"
                :items="typesD"
                placeholder="Select"
                variant="outlined"
                rounded
                compact
              ></v-select>
            </v-col>
            <v-col>
              <div class="text-subtitle-1 text-start text-blue-darken-4">Document Number *</div>

              <v-text-field
                density="compact"
                v-model="documentNumber.value.value"
                :counter="7"
                placeholder="Document Number"
                variant="outlined"
                rounded
                ></v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col>
              <div class="text-subtitle-1 text-center  text-blue-darken-4">Address<v-icon icon="mdi-map-marker-multiple-outline"></v-icon></div>
              <add-form-address></add-form-address>
              <slot></slot>
              
            </v-col>
          </v-row>
        </v-container>
    </form>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn
        text="Cancel"
        color="red"
        variant="tonal"
        rounded
      >
      </v-btn>
      <v-btn
        text="Create"
        color="blue"
        variant="flat"
        rounded
        width="200"
      >
      </v-btn>
    </v-card-actions>
  </v-card>

  
</template>

<script setup>
import {ref} from 'vue'
import {useField, useForm} from 'vee-validate'
import AddFormAddress from '../../address/AddFormAddress.vue'

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

    },
})

const firstName = useField('firstName')
const lastName = useField('lastName')
const email = useField('email')
const phone = useField('phone')
const documentType = useField('documentType')
const documentNumber = useField('documentNumber')



const typesD= ref([
    'Passport',
    'Id Card'
]);

</script>
<style src="../../../../assets/css/components/forms/register/sign-up.css"></style>