<template>
    <v-dialog  max-width="500">
        <template v-slot:activator="{props: activatorProps}">
            <v-btn
                variant="elevated"
                color="red"
                icon="mdi-delete-outline"
                size="small"
            ></v-btn>
        </template>
        <template v-slot:default="{isActive}">
            <v-card title="Edit information">
                <v-card-text>
                    <v-form @submit="{handleSubmit}">


                    </v-form>
                </v-card-text>
            </v-card>
        </template>
    </v-dialog>
</template>

<script setup></script>
