
<template>
 <form @submit.prevent="submit">
  <v-row>
    <v-col>
      <v-text-field
      v-model="name.value.value"
        :counter="10"
        :error-messages="name.errorMessage.value"
        label="Fisrt Name"
        ></v-text-field>
    </v-col>
    <v-col>
      <v-text-field
      v-model="name.value.value"
        :counter="10"
        :error-messages="name.errorMessage.value"
        label="Last Name"
        ></v-text-field>
    </v-col>
  </v-row>
  <v-row>
    <v-col>
      <v-text-field
      v-model="email.value.value"
      :error-messages="email.errorMessage.value"
        label="Corporate E-mail"
        ></v-text-field>
    </v-col>
    <v-col>
      <v-text-field
      v-model="phone.value.value"
      :counter="10"
      :error-messages="phone.errorMessage.value"
      label="Phone Number"
      ></v-text-field>
    </v-col>
  </v-row>
    <v-text-field
    v-model="name.value.value"
      :counter="10"
      :error-messages="name.errorMessage.value"
      label="Company Name"
      ></v-text-field>



    <v-textarea 
    variant="solo-filled"
    label="Message"
    :v-model="description.value.value"
    :error-messages="description.errorMessage.value"
    ></v-textarea>

    <v-checkbox
    v-model="checkbox.value.value"
    :error-messages="checkbox.errorMessage.value"
    label="Terms and conditions"
    type="checkbox"
    value="1"
    ></v-checkbox>

    <v-btn
    class="me-4"
    type="submit"
    color="green"
    >
      submit
    </v-btn>

    <v-btn 
    color="grey"
    @click="handleReset">
      clear
    </v-btn>
  </form>
</template>

<script setup>
    import {ref} from 'vue';
    import {useField, useForm} from  'vee-validate';
    
    const { handleSubmit, handleReset } = useForm({
        validationSchema:{
            name(value){
                if (value?.length >=2) return true

                return 'Name needs to be at least 2 characters.'
            },
            phone(value){
                if(/^[0-9-]{10,}$/.test(value)) return true

                return 'Phone number needs to be at least 10 digits.'
             },
             email(value){
                if (/^[a-z.-]+@[a-z.-]+\.[a-z]+$/i.test(value)) return true

                return 'Must be a valid e-mail.'
             },
             description (value) {
                if (value) return true

                return 'Must add a description'
            },
            checkbox (value) {
                if (value === '1') return true

                return 'Must be checked.'
            },
        },
    }) 

    const name = useField('name')
    const phone = useField('phone')
    const email = useField('email')
    const description = useField('description')
    const checkbox = useField('checkbox')


    const submit = handleSubmit(values =>{
        alert(JSON.stringify(values, null, 2))
    })
</script>
<style scoped>
</style>