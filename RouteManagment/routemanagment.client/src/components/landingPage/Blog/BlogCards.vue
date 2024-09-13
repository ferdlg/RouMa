<script setup>
</script>

<template>
  <v-item-group>
    <v-container>
      <v-row>
        <v-col
          v-for="(transport, index) in transports "
          :key="index">
          
          <v-card 
           color="#1F7087"
           >
             <div class="d-flex">
               <div>
                 <v-card-title class="text-h5">
                   {{transport.name}}
                 </v-card-title>
  
                 <v-img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRShtL6JTPSre7lfXrjOosU0zz8wpA_Jp44ZQ&s"></v-img>
                 <v-card-subtitle>{{transport.description}}</v-card-subtitle>
  
               </div>
  
               <v-avatar
                 class="ma-3"
                 rounded="0"
                 size="125"
               >
               </v-avatar>
             </div>
           </v-card>
        </v-col>
      </v-row>
       </v-container>
  </v-item-group>
</template>
<script>
  export default {
    data(){
      return{
        transports:[
          {name:'Transport', image:'', description:'Dato quemado de prueba'},
          {name:'Transport', image:'', description:'Dato quemado de prueba'},
          {name:'Transport', image:'', description:'Dato quemado de prueba'},
          {name:'Transport', image:'', description:'Dato quemado de prueba'},
          {name:'Transport', image:'', description:'Dato quemado de prueba'},
          {name:'Transport', image:'', description:'Dato quemado de prueba'},
          
        ]
      }
    }
  }
</script>
<style>
</style>