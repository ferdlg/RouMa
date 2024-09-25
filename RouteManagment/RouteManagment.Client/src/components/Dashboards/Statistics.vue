<template>
    <v-container fluid>
        <h1>Estadisticas</h1>
        <BarChart :chart-data="chartData" :chart-options="chartOptions" />
    </v-container>
</template>
<script setup>
import BarChart from './BarChart.vue'; 
import { ref } from 'vue';

const chartData = ref({
  labels: ['Enero', 'Febrero', 'Marzo'],
  datasets: [
    {
      label: 'Ventas',
      backgroundColor: '#42A5F5',
      data: [40, 20, 30],
    },
  ],
});

const chartOptions = ref({
  responsive: true,
});

</script>
<style scoped>
     .v-sheet--offset {
    top: -24px;
    position: relative;
  }
</style>