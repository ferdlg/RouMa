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
main{
  display: grid;
  width: 100%;
  height: 100hv;
}
.container-btn-get{
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
  align-items: flex-start;
}
.container-svg-roadauto{
  display: grid;
  grid-template-columns: 75% 25%;
}
</style>