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
import NavBar from '../../components/landingPage/NavBar.vue';
import Logo from '../../components/landingPage/Logo.vue';
import Slogan from '../../components/landingPage/Slogan.vue';
import ButtonGet from '../../components/landingPage/ButtonGet.vue';
import RoadSvg from '../../components/landingPage/RoadSvg.vue';
import Auto from '../../components/landingPage/Auto.vue';
import AboutUs from '../../components/landingPage/aboutUs/AboutUs.vue';
import SignUp from '../../components/forms/register/SignUp.vue';
import ContactUs from '../../components/landingPage/contactUs/ContactUs.vue';
import Transport from '../../components/landingPage/transports/Transport.vue';
</script>
<style src="../../assets/css/pages/landingPage/landing-page.css"></style>