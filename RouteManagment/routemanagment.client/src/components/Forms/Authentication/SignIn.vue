<template>
    <div>
        <v-card
        class="mx-auto pa-12 pb-8"
        elevation="8"
        max-width="448"
        rounded="lg"
        >
        <div class="d-flex justify-center text-purple-darken-4">
            <h1>Log in</h1>
        </div>
        <div class="text-subtitle-1 text-medium-emphasis ">Account</div>
     
      <v-text-field
      density="compact"
      placeholder="Email address"
      prepend-inner-icon="mdi-email-outline"
      variant="outlined"
      ></v-text-field>

      <div class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between">
        Password
      </div>

      <v-text-field
      :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
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
      >
        Log In
      </v-btn>
    </v-card>
  </div>
</template>
<script setup>
    import {ref} from 'vue';
    const data = ref({
        visible:false,
    })
</script>
<style>
</style>