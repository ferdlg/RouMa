<script setup>

</script>

<template>

<v-container class="container-title">
    <div class="d-flex flex-column fill-height justify-center align-center text-black">
      <h1 class="text-h4 font-weight-thin mb-4">
        Customers
      </h1>
    </div>
    </v-container>
  <v-item-group class="d-grid justify-center">
    <v-chip
      :title="customers"
      v-for="(customer, index) in customers"
      :key="index"
      class="ma-2 pa-2"
    >
      {{customer.name}}
    </v-chip>
  </v-item-group>
</template>

<script>
export default {
data(){
  return{
    customers : [
      {name:'Empresa1', src : ''},
      {name:'Empresa2', src: ''},
      {name:'Empresa3', src: ''},
      {name:'Empresa4', src: ''},
      {name:'Empresa5', src: ''},
      {name:'Empresa5', src: ''}
    ]
  }
}
}
</script>
<style>

</style>