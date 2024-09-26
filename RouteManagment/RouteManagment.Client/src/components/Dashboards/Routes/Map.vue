<template>
    <v-row>
      <v-col>
          <v-card-title>
            Map
          </v-card-title>
            <v-card>
              <v-card-text>
                <v-skeleton-loader
                  v-if="loadingMap"
                  type="image"
                  height="400"
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
    const loadingMap = ref(false)

</script>
<style scoped>

</style>