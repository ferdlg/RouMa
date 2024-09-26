<template>
    <div class="add__new--route">
                    <div class="pa-4 text-center">
                    <v-dialog
                    v-model="dialog"
                    max-width="600"
                    >
                    <template v-slot:activator="{ props: activatorProps }">
                        <v-btn
                        class="text-none font-weight-regular"
                        prepend-icon="mdi-routes"
                        text="New route"
                        variant="tonal"
                        color="green-darken-3"
                        v-bind="activatorProps"
                        ></v-btn>
                    </template>

                    <v-card
                        prepend-icon="mdi-routes"
                        title="Add new route"
                    >
                        <v-card-text>
                        <v-row dense>
                            <v-col
                            cols="12"
                            md="4"
                            sm="6"
                            >
                            <v-select
                                label="Origin address*"
                                required
                            ></v-select>
                            </v-col>

                            <v-col
                            cols="12"
                            md="4"
                            sm="6"
                            >
                            <v-select
                                label="Destination address*"
                                required
                            ></v-select>
                            
                            </v-col>   
                        </v-row>
                        <v-row>
                            <v-col>
                                <v-btn
                                    prepend-icon="mdi-map-marker-plus-outline"
                                    class="primary"
                                    text="Add stops"
                                    @click="dialog2 = true"
                                ></v-btn>
                            </v-col>
                        </v-row>
                        <v-spacer></v-spacer>
                        <small class="text-caption text-medium-emphasis">*indicates required field</small>
                        </v-card-text>
                        
                        <v-divider></v-divider>
                        <v-card-actions>
                        <v-spacer></v-spacer>

                        <v-btn
                            text="Cancel"
                            variant="plain"
                            @click="dialog = false"
                            color="red"
                        ></v-btn>

                        <v-btn
                            color="primary"
                            text="Save"
                            variant="tonal"
                            @click="dialog = false"
                        ></v-btn>
                        </v-card-actions>
                        
                    </v-card>
                    </v-dialog>
                </div>
                </div>
                <v-spacer></v-spacer>
                <v-btn variant="outline"
                icon="mdi-table-filter"
                ></v-btn>
                <v-dialog
                    v-model="dialog2"
                    max-width="240"
                    >
                    <v-card title="Stops">
                        <v-row>
                            <v-col>

                            </v-col>
                        </v-row>
                        <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn
                            text="Close"
                            variant="text"
                            @click="dialog2 = false"
                        ></v-btn>
                        </v-card-actions>
                    </v-card>
                </v-dialog>
</template>

<script setup>
    import {ref} from 'vue'
    
    const dialog = ref(false)
    const dialog2 = ref(false)
</script>

<style scoped>
</style>