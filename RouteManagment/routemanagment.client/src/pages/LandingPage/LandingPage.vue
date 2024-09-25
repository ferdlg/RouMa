<template>
  <header class="header">
    <v-layout>
      <nav class="nav">
        <NavBar/>
      </nav>
    </v-layout>
  </header>
    <main  id="/" class="main">
      <div id="logo" class="main__logo">
        <Logo/>
      </div>
      <div id="slogan" class="main__slogan">
        <Slogan/>
      </div>
      <div id="btn-get" class="main__btn-get">
        <ButtonGet/>
      </div>
      <div id="svg-road" class="main__svg-road">
        <RoadSvg/>
      </div>
      <div id="svg-auto" class="main__svg-auto">
        <Auto/>
      </div>
  
      <div id="about-us" class="main__about-us">
        <AboutUs/>
        <SignUp/>
      </div>

      <div id="contact-us" class="main__contact-us">
        <ContactUs/>
      </div>

      <div id="transports" class="main__transports">
        <Transport/>
      </div>
    </main>
    <!-- <footer>
      <FooterLanding/>
    </footer> -->
</template>
<script setup> 
import NavBar from '../../components/LandingPage/NavBar.vue';
import ButtonGet from '../../components/LandingPage/ButtonGet.vue';
import Logo from '../../components/LandingPage/Logo.vue';
import Auto from '../../components/LandingPage/Auto.vue';
import RoadSvg from '../../components/LandingPage/RoadSvg.vue';
import Header from '../../components/LandingPage/Slogan.vue';
import Slogan from '../../components/LandingPage/Slogan.vue';
import AboutUs from '../../components/LandingPage/AboutUs/AboutUs.vue';
import FooterLanding from '../../components/LandingPage/FooterLanding.vue';
import ContactUs from '../../components/LandingPage/Contact Us/ContactUs.vue';
import Transport from '../../components/LandingPage/Transports/Transport.vue';
import SignUp from '../../components/Forms/Register/SignUp.vue';
</script>
<style scoped>
.header{
  width: 100%;
  height: 5vh;
  display: flex;
  align-items: center;
}
.main{
  width: 100%;
  margin-top: 2vh;
  display: grid;
  /* background-color: rgba(240, 248, 255, 0.623); */
  grid-template-areas: "logo slogan" "btnGet slogan" "svgRoad svgAuto" "aboutUs aboutUs" "howToUse howToUse" "blog blog";
  grid-template-columns: 65% 35%;

}
.main__logo, .main__slogan, .main__btn-get, .main__svg-road, .main__svg-auto, .main__contact-us, .main__transports{
  display: flex;
}
.main__logo{
  grid-area: logo;
  /* background-color: rgba(38, 45, 105, 0.322);  */
  flex-direction: column;
  justify-content: flex-end;
  align-items: center;
}

.main__slogan{
  grid-area: slogan;
  flex-direction: column;
  align-items: flex-start;
}
.main__btn-get{
  grid-area: btnGet;
  /* background-color: rgba(155, 243, 96, 0.322); */
  flex-direction: column;
  align-items: center;
  justify-content: center;
  align-content: center;
}
.main__svg-road{
  grid-area: svgRoad;
    /* background-color: rgba(255, 0, 0, 0.418);  */
      width: 100%;
    max-height: 100%;
      flex-wrap: wrap;
    flex-direction: column;
    justify-content: center;
  }
.main__svg-auto{
  grid-area: svgAuto;
  /* background-color: rgba(240, 248, 255, 0.322); */
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;

}
.main__about-us{
  grid-area: aboutUs;
  background-color: rgb(255, 255, 255);
}
.main__contact-us{
  grid-area: howToUse;
  padding: 10px;
  background-color: rgb(255, 255, 255);
}
.main__transports{
  grid-area: blog;
  background-color: rgb(253, 253, 253);
}
</style>