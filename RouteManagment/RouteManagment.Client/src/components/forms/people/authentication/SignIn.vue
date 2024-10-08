<template>
    <div class="container__singIn">
      <v-card
      class="mx-auto pa-12 pb-8"
      elevation="8"
      max-width="448"
      rounded="lg"
      >
      <div class="d-flex justify-center text-purple-darken-4">
          <h1>Log in</h1>
      </div>

      <v-form @submit.prevent="submitForm">

          <div class="text-subtitle-1 text-medium-emphasis ">Account</div>
    
          <v-text-field v-model="email.value.value"
          density="compact"
          placeholder="Email address"
          prepend-inner-icon="mdi-email-outline"
          variant="outlined"
          ></v-text-field>
    
          <div class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between">
            Password
          </div>
    
        <v-text-field v-model="password.value.value"
        :append-inner-icon="visible ? 'mdi-eye' : 'mdi-eye-off'"
        :type="visible ? 'text' : 'password'"
        density="compact"
        placeholder="Enter your password"
        prepend-inner-icon="mdi-lock-outline"
        variant="outlined"
        @click:append-inner="visible = !visible"
        ></v-text-field>
    
        <v-card
        class="mb-12"
        color="surface-variant"
        variant="tonal"
        >
    
        </v-card>
    
        <v-btn
        class="mb-8"
        color="purple-lighten-2"
        size="large"
        variant="tonal"
        block
        type="submit"
        
        >
          Log In
        </v-btn>
      </v-form>
  </v-card>
</div>
</template>
<script setup>
import {ref} from 'vue';
import {useRouter} from 'vue-router';
import {useField, useForm} from 'vee-validate';

    const visible = ref(false)
    const router = useRouter();

    const{handleSubmit} = useForm({
      validationSchema:{
        email(value){
          if(value === 'admin@example.com') return true
        },
        password(value){
          if(value === '12345') return true
        }
      }
    })

    const email = useField('email')
    const password = useField('password')

    const submitForm = handleSubmit(()=>{
      router.push('/admin/home');
    })

</script>

<style src="../../../../assets/css/components/forms/authentication/sign-in.css"></style>