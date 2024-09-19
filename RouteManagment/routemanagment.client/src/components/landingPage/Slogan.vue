<script setup>
</script>

<template>
    <div class="container">
        <h1 class="container__slogan-primary">Mobility tailored to your Company</h1>
        <p class="container__slogan-secundary">We transform the journey to work into a moment of comfort</p>
    </div>
</template>

<style>

@font-face {
  font-family: "Ubuntu";
  src:   url(../../../public/fonts/Ubuntu-vf.ttf) format("truetype"),

}
    .container{
        padding: 15px;
    }
    .container__slogan-primary{
        color: var(--color-primary-background) ;
        padding: 10px;
        font-family: "Ubuntu";
        font-size: 2em;
        text-align: center;
   
    }
    .container__slogan-secundary{
        color: var(--color-primary-background);
        padding: 20px;
        font-size: 1em;
    }
</style>