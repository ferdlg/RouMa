<template>
         <v-dialog v-model="dialog" max-width="500">
             <template v-slot:activator="{props: activatorProps}">
                 <v-btn
                    variant="elevated"
                    color="indigo-darken-3"
                    icon="mdi-lead-pencil"
                    size="small"
                ></v-btn>
                
             </template>
             <v-card prepend-icon="mdi-information-variant-circle" title="Edit information">
                 <v-card-text>
                     <v-form @submit="{handleSubmit}">
     
     
                     </v-form>
                 </v-card-text>
                 <v-divider></v-divider>
             <v-card-actions>
                 <v-spacer></v-spacer>
                 <v-btn
                 color="primary"
                 text="Save"
                 variant="tonal"
                 @click="dialog = false"
               ></v-btn>
             </v-card-actions>
             </v-card>
         </v-dialog>
</template>

<script setup>
    import {ref} from 'vue'

    const dialog = ref(false); 
</script>
