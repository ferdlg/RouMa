<script setup> 
import NavBar from '../../components/LandingPage/NavBar.vue';
import ButtonGet from '../../components/LandingPage/ButtonGet.vue';
import Logo from '../../components/LandingPage/Logo.vue';
import Auto from '../../components/LandingPage/Auto.vue';
import RoadSvg from '../../components/LandingPage/RoadSvg.vue';

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
    <div class="container-svg-road">
      <RoadSvg/>
    </div>
    <div class="container-svg-auto">
      <Auto/>
    </div>
    
  </main>
</template>

<style scoped>
main{
  width: 100%;
  height: 92vh;
  margin-top: 80px;
  display: grid;
  grid-template-areas: "logo svgAuto" "btnGet svgAuto" "svgRoad svgAuto";
  grid-template-columns: 65% 35%;
}
main .container-logo{
  grid-area: logo;
  /* background-color: rgba(38, 45, 105, 0.322); */
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
  align-items: center;
}
main .container-btn-get{
  grid-area: btnGet;
  /* background-color: rgba(155, 243, 96, 0.322); */
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}
main .container-svg-road{
  grid-area: svgRoad;
    /* background-color: rgba(255, 0, 0, 0.418); */
    display: flex;
    flex-direction: column;
    justify-content: flex-end;
    align-items: flex-start;
  }
.container-svg-auto{
  grid-area: svgAuto;
  /* background-color: rgba(240, 248, 255, 0.322); */
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
  align-items: flex-start;
}
</style>