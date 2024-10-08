<template>
    <v-container>
        <v-stepper class="text-purple-darken-4" :items="items" min-width="200" edit-icon="mdi-map-marker-distance">
        <template v-slot:item.1  >
            <v-card flat>
                <v-form @submit.prevent>
                    <v-row>
                        <v-col>
                            <v-select v-slot:prepend 
                                color="amber-accent-4"
                                v-model="addressOrigin"
                                :rules="rules"
                                label="Address origin *"
                                > <v-icon icon="mdi-map-marker-outline" color="amber-accent-4"></v-icon>
                            </v-select>
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col>
                            <v-select v-slot:prepend  
                                color="amber-darken-4"                              
                                v-model="addressHeadQuarter"
                                :rules="rules"
                                label="Address destination *"
                            > <v-icon icon="mdi-map-marker" color="amber-darken-4"></v-icon></v-select>                            
                        </v-col>
                    </v-row>
                <v-row justify="center">
                    <v-col>
                        <v-btn
                        color="purple-darken-4"
                        @click="submit"
                        >
                        create
                        </v-btn>
                    </v-col>
                </v-row>
                </v-form>
                <small class="text-caption text-medium-emphasis">*indicates required field</small>
          </v-card>
        </template>
      
        <template v-slot:item.2>
            <v-container>

                <v-card flat>
                  <v-row>
                      <v-col>
                          <v-text-field v-slot:prepend 
                              color="amber-accent-4"
                              v-model="addressOrigin"
                              :rules="rules"
                              label="Address origin"
                              disabled
                          > <v-icon icon="mdi-map-marker-outline" color="amber-accent-4"></v-icon>
                          </v-text-field>
                      </v-col>
                  </v-row>
                  <v-row>
                      <v-col >
                          <v-select v-slot:prepend 
                          color="deep-orange-accent-4" 
                          label="Stop"
                          v-model="stop"
                          ><v-icon icon="mdi-radiobox-marked"  color="deep-orange-accent-4" ></v-icon></v-select>
                      </v-col>
                      <v-col cols="auto" align-self="center">
                          <v-btn density="compact" icon="mdi-plus"  color="green-darken-3"></v-btn>
                      </v-col>
                  </v-row>
                  <v-row>
                      <v-col>
                          <v-text-field v-slot:prepend 
                              color="amber-darken-4"                              
                              v-model="addressHeadQuarter"
                              :rules="rules"
                              label="Address destination *"
                              disabled
                          > <v-icon icon="mdi-map-marker-outline" color="amber-accent-4"></v-icon>
                          </v-text-field>
                      </v-col>
                  </v-row>            
                </v-card>
            </v-container>
        </template>
      
        <template v-slot:item.3>
          <v-card flat>
            <Detail :headers="headers" :desserts="desserts"></Detail>
          </v-card>
        </template>
      </v-stepper>
    </v-container>
</template>
<script setup>
    import {ref} from 'vue'
    import {useField, useForm} from 'vee-validate'
import Detail from './Detail.vue'

    const items = ref([
        {title:'Origin and Destination', completed: false, icon: 'mdi-map-marker-distance'},
        {title:'Add stops to route', completed: false, icon: 'mdi-map-marker-path'},
        {title:'Route detail', completed: false, icon: 'mdi-details'}
    ]);

    const addressOrigin = useField('addressOrigin')
    const addressHeadQuarter = useField('addressHeadQuarter')

    const headers = ref([
        {name: 'Origin'},
        {name: 'Destination'},
        {name: 'Stops'},
    ])
</script>
<style scoped>
.custom__stepper{
    color: var(--color-primary-background);
}
</style>