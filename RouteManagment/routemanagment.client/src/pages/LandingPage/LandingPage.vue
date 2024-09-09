<script setup> 
import NavBar from '../../components/LandingPage/NavBar.vue';
import ButtonGet from '../../components/LandingPage/ButtonGet.vue';
import RoadAuto from '../../components/LandingPage/RoadAuto.vue';
import Logo from '../../components/LandingPage/Logo.vue';
import Footer from '../../components/LandingPage/Footer.vue';
</script>

<template>
  <header>
    <div>
      <NavBar />
    </div>
  </header>
  <main>
    <div class="container-logo">
      <Logo/>
    </div>
    <div class="container-btn-get">
      <ButtonGet/>
    </div>
    <div class="container-svg-roadauto">
      <RoadAuto/>
    </div>
    
  </main>
</template>

<style scoped>

</style>