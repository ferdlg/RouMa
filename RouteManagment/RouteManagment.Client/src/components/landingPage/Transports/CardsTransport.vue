<script setup>
import {ref} from 'vue';
      const  transports = ref([
          {name:'Transport1', image:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHYd8nZKOSZ-NfFAW2VsBm06t6XVTl5l6zow46f1Kk5qCWtR8w4De4KGkit27PNIrNSZ0&usqp=CAU', description:'Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500', capacity:46},
          {name:'Transport', image:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHYd8nZKOSZ-NfFAW2VsBm06t6XVTl5l6zow46f1Kk5qCWtR8w4De4KGkit27PNIrNSZ0&usqp=CAU', description:'Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500', capacity:45},
          {name:'Transport', image:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHYd8nZKOSZ-NfFAW2VsBm06t6XVTl5l6zow46f1Kk5qCWtR8w4De4KGkit27PNIrNSZ0&usqp=CAU', description:'Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500', capacity:45},
          {name:'Transport', image:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHYd8nZKOSZ-NfFAW2VsBm06t6XVTl5l6zow46f1Kk5qCWtR8w4De4KGkit27PNIrNSZ0&usqp=CAU', description:'Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500', capacity:45},
          {name:'Transport', image:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHYd8nZKOSZ-NfFAW2VsBm06t6XVTl5l6zow46f1Kk5qCWtR8w4De4KGkit27PNIrNSZ0&usqp=CAU', description:'Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500', capacity:45},
          {name:'Transport', image:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHYd8nZKOSZ-NfFAW2VsBm06t6XVTl5l6zow46f1Kk5qCWtR8w4De4KGkit27PNIrNSZ0&usqp=CAU', description:'Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500', capacity:45},
          
        ]
      )
      const show = ref(false)
      const expand = ref(null)
</script>

<template>
  <v-item-group>
    <v-container>
      <v-row>
        <v-col
          v-for="(transport, index) in transports "
          :key="index">
          
          <v-card
    class="mx-auto"
    max-width="344"
  >
    <v-img
      height="200px"
      :src="transport.image"
      cover
    ></v-img>

    <v-card-title>
      {{transport.name}}
    </v-card-title>

    <v-card-subtitle>
      Capacity: {{transport.capacity}}
    </v-card-subtitle>

    <v-card-actions>
      <v-btn
        color="orange-lighten-2"
        text="Explore"
      ></v-btn>

      <v-spacer></v-spacer>

      <v-btn
        :icon="show ? 'mdi-chevron-up' : 'mdi-chevron-down'"
        @click="show = !show"
      ></v-btn>
    </v-card-actions>
    <v-expand-transition>
      <div v-show="show">
        <v-divider></v-divider>

        <v-card-text>
         {{transport.description}}
        </v-card-text>
      </div>
    </v-expand-transition>

  </v-card>
        </v-col>
      </v-row>
       </v-container>
  </v-item-group>
</template>

<style>
</style>