<script setup>
import NavBar from '@/components/landingPage/NavBar.vue';
import auto from '@/assets/auto.svg';
import logo from '@/assets/logo.svg';
import road from '@/assets/road.svg';
import GetStarted from '@/components/landingPage/GetStarted.vue';
import Footer from '@/components/landingPage/Footer.vue';
</script>

<template>
    <header>
      <div class="navigation">
        <NavBar />
      </div>
    </header>
    <body>
      <section class="first-body">
        <div class="container-logosvg">
          <Img :src ="logo" alt = "Logo" />
        </div>
        <div class="btn-GetStarted">
          <GetStarted />
          <Img :src ="road" alt = "Road" />
        </div>
      </section>
      <section class="second-body">
        <div class="container-autosvg">
        <Img :src ="auto" alt = "Auto" />
      </div>
      </section>
    </body>
    <footer>
    </footer> 
</template>

<style scoped>

  .navigation{
    position: absolute;
  }
  .container-logosvg{
    margin-top:13%;
  }

  .first-body{
    background-color:violet;
  }
  .second-body{
    background-color:blue;
  }

</style>
