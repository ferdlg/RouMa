<template>
    <v-row>
      <v-col cols="12">
        <v-card>
          <v-card-title>
            Mapa
            <v-spacer></v-spacer>
            <v-btn color="primary" @click="dialog = true">
              Ver Mapa
            </v-btn>
          </v-card-title>
          <v-card-text>
            Haga clic en el botón para ver el mapa
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
    <v-dialog v-model="dialog" max-width="800px">
      <v-card>
        <v-card-title>
          Mapa
          <v-spacer></v-spacer>
          <v-btn icon @click="dialog = false">
            <v-icon>mdi-close</v-icon>
          </v-btn>
        </v-card-title>
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
    </v-dialog>
</template>
<script setup>
    import{ref} from 'vue'
    
    const dialog = ref(false)
    const loadingMap = ref(false)

</script>
<style scoped>

</style>