<template>
    <v-row>
      <v-col>
            <v-card
            height="350"
            title="Map"
            >
              <v-card-text>
                <v-skeleton-loader
                  v-if="loadingMap"
                  type="image"
                  height="350"
                ></v-skeleton-loader>
                <div v-else class="grey lighten-2 d-flex align-center justify-center" style="height: 400px;">
                  <span class="text-h6">Mapa cargado (simulación)</span>
                </div>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>

</template>
<script setup>
    import{ref} from 'vue'
    import {defineProps} from 'vue'

    const loadingMap = ref(false)
    // const props = defineProps({
    //   image:{
    //     type: string, 
    //     default : '/images/image.jpg',
    //     validator: propValue => {
    //       const hasImagesDirectory = propValue.indexOf('/images/')>=1
    //       const isPNG = propValue.endsWith('.png')
    //       const isJPG = propValue.endsWith('.jpg') || propValue.endsWith('.jpg')
    //       const hasValidExtension = isPNG || isJPG

    //       return hasImagesDirectory && hasValidExtension
    //     }
    //   }
    // })


</script>
<style scoped>

</style>