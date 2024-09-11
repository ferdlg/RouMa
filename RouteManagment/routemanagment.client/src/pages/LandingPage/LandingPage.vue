<script setup> 
import NavBar from '../../components/LandingPage/NavBar.vue';
import ButtonGet from '../../components/LandingPage/ButtonGet.vue';
import Logo from '../../components/LandingPage/Logo.vue';
import Auto from '../../components/LandingPage/Auto.vue';
import RoadSvg from '../../components/LandingPage/RoadSvg.vue';
import Header from '../../components/LandingPage/Slogan.vue';
import Slogan from '../../components/LandingPage/Slogan.vue';

</script>

<template>
  <header>
      <NavBar />
  </header>
  <main>
    <div class="container-logo">
      <Logo/>
    </div>
    <div class="container-slogan">
      <Slogan/>
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
  grid-template-areas: "logo slogan" "btnGet slogan" "svgRoad svgAuto";
  grid-template-columns: 65% 35%;
  grid-template-rows: 1fr 1fr 0.5fr;
}
main .container-logo{
  grid-area: logo;
  /* background-color: rgba(38, 45, 105, 0.322); */
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
  align-items: center;

}

main .container-slogan{
  grid-area: slogan;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
main .container-btn-get{
  grid-area: btnGet;
  /* background-color: rgba(155, 243, 96, 0.322); */
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  align-content: center;
}
main .container-svg-road{
  grid-area: svgRoad;
    /* background-color: rgba(255, 0, 0, 0.418);  */
    display: flex;
    width: 100%;
    max-height: 100%;
    display: flex;
    flex-wrap: wrap;
    flex-direction: column;
    justify-content: center;
  }
.container-svg-auto{
  grid-area: svgAuto;
  /* background-color: rgba(240, 248, 255, 0.322); */
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;
}
</style>