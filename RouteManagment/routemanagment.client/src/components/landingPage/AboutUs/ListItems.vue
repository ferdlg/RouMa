<script setup>

</script>

<template>

<v-container class="container-title">
    <div class="d-flex flex-column fill-height justify-center align-center text-purple-darken-4">
      <h2>
        Customers
      </h2>
    </div>

    <v-row>
      <v-col
        v-for="customer in customers"
        :key="customer"
        class="group-img"
      >
      <v-img
      :width="50"
      :src="customer.src"
      cover
      >
      <template v-slot:placeholder>
        <v-row
        class="fill-height ma-0"
        justify="center"
        >
        <v-progress-circular
              color="grey-lighten-5"
              indeterminate
            ></v-progress-circular>
        </v-row>

      </template>
      </v-img>
      </v-col>
    </v-row>
</v-container>
</template>

<script>
export default {
data(){
  return{
    customers : [
      {name:'Empresa1', src : 'https://static-cse.canva.com/blob/951786/1750logotiposqueteinspiraran.jpg'},
      {name:'Empresa3', src: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSo9KtcDoyR1J47I-QnJqzN2ZQDGJKUCSBXEA&s'},
      {name:'Empresa2', src: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRDxYwshCz4XvXDZazVG4LAQL8lamAG6Y2p6g&s'},
      {name:'Empresa4', src: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZ8lXvukcJaOWDSoWyabhE8Vo4Iuq3iolMkA&s'},
    ]
  }
}
}
</script>
<style scoped>
.d-flex{
  padding-bottom: 15px;
}
</style>