<template>
    <v-container>
        <v-card 
        min-width="100"
        max-width="300" 
        prepend-icon=" mdi-map-marker-path"
        title="Stops">
            <v-card-text >
                <v-timeline align="start" density="compact">
                    <v-timeline-item
                    v-for="stop, index in stops"
                    :key="index"
                    dot-color="amber-darken-1"
                    size="x-small"
                    >
                        <div class="mb-4">
                            <div>
                                <strong>{{stop.address}}</strong>
                            </div>
                        </div>
                    </v-timeline-item>

                </v-timeline>
            </v-card-text>
        </v-card>
    </v-container>
</template>

<script setup>
import {ref} from 'vue'

const stops = ref([
    {address:'Stop 1'},
    {address:'Stop 2'},
    {address:'Stop 3'},
    {address:'Stop 4'}
    ])
</script>

<style scoped>
</style>