<template>
    <v-card flat>
        <v-form @submit.prevent>
            <v-row >
                <v-col>
                    <v-file-input
                    density="compact"
                        prepend-icon="mdi-camera"
                        variant="outlined"
                        rounded
                        
                    >
                    </v-file-input>
                </v-col>
            </v-row>
            <v-row>
                <v-col>
                    <v-text-field
                        density="compact"
                        placeholder="Plate"
                        variant="outlined"
                        rounded
                    >
                    </v-text-field>
                </v-col>
                <v-col>
                    <v-text-field
                        density="compact"
                        placeholder="Capacity"
                        variant="outlined"
                        rounded
                    >
                    </v-text-field>
                </v-col>
            </v-row>
            <v-row>
                <v-col>
                    <v-select
                        density="compact"
                        placeholder="Status"
                        variant="outlined"
                        rounded
                    >
                    </v-select>
                </v-col>
                <v-col>
                    <v-select
                        density="compact"
                        placeholder="Route"
                        variant="outlined"
                        rounded
                    >
                    </v-select>
                </v-col>
                <v-col>
                    <v-select
                        density="compact"
                        placeholder="Type transport"
                        variant="outlined"
                        rounded
                    >
                    </v-select>
                </v-col>
            </v-row>
        </v-form>
        <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
                text="cancel"
                color="red"
                variant="tonal"
                >
            </v-btn>
            <v-btn
                text="Create"
                color="green"
                variant="flat"
            >
            </v-btn>
        </v-card-actions>
    </v-card>
</template>

<script setup>
</script>

