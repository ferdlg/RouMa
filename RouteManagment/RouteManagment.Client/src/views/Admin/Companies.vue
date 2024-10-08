<template>
    <Menu>
            <div class="contain__tools-company">
                <ToolBar>
                    <AddForm></AddForm>
                </ToolBar>
            </div>
                <v-row>
                    <v-col>
                        <div class="contain__board-company">
                            <v-card title="Companies">
                                <BoardData :headers="headers_company" :desserts="desserts_company" ></BoardData>
                            </v-card>
                        </div>
                    </v-col>
                    <v-col>
                        <div class="contain__board-admin--company">
                            <v-card title="Administrator">
                                <BoardData :headers="headers_admin" :desserts="desserts_admin" ></BoardData>
                            </v-card>
                        </div>
                    </v-col>
                </v-row>
    </Menu>
</template>
<script setup>
import {ref} from 'vue'
import Menu from "../../components/dashboards/layout/Menu.vue";
import BoardData from "../../components/dashboards/layout/BoardData.vue";
import ToolBar from '../../components/dashboards/layout/ToolBar.vue';
import AddForm from '../../components/dashboards/companies/AddForm.vue';

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