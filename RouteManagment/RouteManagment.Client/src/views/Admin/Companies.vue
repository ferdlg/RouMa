<template>
    <Menu>
        <div class="contain">
            <div class="contain__board-company">
                <v-card title="Companies">
                    <BoardData :headers="headers_company" :desserts="desserts_company" ></BoardData>
                </v-card>
            </div>
            <div class="contain__board-admin--company">
                <v-card title="Administrator">
                    <BoardData :headers="headers_admin" :desserts="desserts_admin" ></BoardData>
                </v-card>
            </div>
            <div class="div">
                <h1>div</h1>
            </div>
        </div>
    </Menu>
</template>
<script setup>
import {ref} from 'vue'
import Menu from "../../components/dashboards/layout/Menu.vue";
import BoardData from "../../components/dashboards/layout/BoardData.vue";

const headers_company = ref ([
      {name: "Company"},
      {name: "logo"}
    ]);
const desserts_company = ref ([
      {name:'babaria'},
      {name:'ayuda'},
      {name:'vamo pa la playa'},
    ]);

const headers_admin = ref([
    {name:'avatar'},
    {name:"Name"},
    {name:"Last Name"},
    {name:"Email"}
]);
const desserts_admin = ref ([
      {name:'babaria'},
      {name:'ayuda'},
      {name:'vamo pa la playa'},
    ]);

</script>
<style src="../../assets/css/views/companies.css"></style>