<template>
    <v-card>
      <v-layout>
        <v-navigation-drawer
          class="navigation__drawer"
          v-model="drawer"
          :rail="rail"
          permanent
          @click="rail = false"
          elevation="2"
        >
          <v-list-item 
            prepend-avatar="https://randomuser.me/api/portraits/women/8.jpg" 
            title="John Done"
            nav
            class="list__item-nav"
          >
            <template v-slot:append>
              <v-btn height="55"
                icon="mdi-chevron-left"
                variant="text"
                @click.stop="rail = !rail"
              ></v-btn>
            </template>
          </v-list-item>
          <v-list density="compact" 
          class="list"
          nav>
          <v-list-item 
            v-for="(homeItem, index) in homeList"
            :key="index"
            :prepend-icon="homeItem.icon"
            :value="homeItem.value"
            class="list__item-icon"
          >
          <router-link :to="homeItem.path" class="router__link">
            <v-list-item-title class="list__item-title"
            >{{homeItem.title}}
          </v-list-item-title>
          </router-link>
          </v-list-item>
          </v-list>
        </v-navigation-drawer>
        <v-app-bar 
        :order="order" 
        flat
        elevation="1"
        class="app__bar"
        >
          <img src="../../../assets/svg/logo-dark.svg" width="150">
          <v-spacer></v-spacer>
          <v-text-field max-width="300" min-width="100"
              :loading="loading"
              append-inner-icon="mdi-magnify"
              density="compact"
              label="Search templates"
              variant="solo"
              hide-details
              single-line
              @click:append-inner="onClick"
              class="text__file-search"
          ></v-text-field>
          <v-spacer></v-spacer>
          <v-btn icon="mdi-bell" size="small"></v-btn>
          <v-btn icon="mdi-archive" size="small"></v-btn>
          
    </v-app-bar>
      <v-main class="d-grid" style="margin: 1em; min-height: 100vh; min-width: 300px;,position: relative; z-index: 1;">
        <slot></slot>
      </v-main>
      </v-layout>
    </v-card>
  </template>

  <script setup>
   import {ref} from 'vue'
    const order = ref(0)
    const drawer = ref(true)
    const rail = ref(true)

    const homeList = ref([
      {icon: 'mdi-home-city', title:'Home', value:'home', path:'/admin/home'},
      {icon: 'mdi-map', title:'Routes', value:'routes', path:'/admin/routes'},
      {icon: 'mdi-city', title:'Companies', value:'companies', path:'/admin/companies'},
      {icon: 'mdi-card-account-details', title:'Drivers', value:'drivers', path:'/admin/drivers'},
      {icon: 'mdi-file', title:'Request Transports', value:'requestTransports', path:'/admin/requestTransports'},
      {icon: 'mdi-van-passenger', title:'transports', value:'transports', path:'/admin/transports'},
      {icon: 'mdi-seat-passenger', title:'Passengers', value:'passengers', path:'/admin/passengers'}
    ])
  </script>
<style scoped>

.navigation__drawer{
  border-radius: 0px 0px 20px 0px;
  /* background-color: var(--color-dashboard-group1); */
}
.app__bar{
  border: none;
  padding: 0.5em;
  /* background-color: var(--color-dashboard-group1); */
}
.list{
  padding-top: 2em;
}
.list__item-icon{
  color:var(--color-icons-dasboard-group1);
}
.list__item-title{
  color: var(--color-icons-dasboard-group1);
}
.router__link{
  text-decoration: none;
  
}
</style>