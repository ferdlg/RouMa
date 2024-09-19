import { createMemoryHistory, createRouter } from 'vue-router'

import LandingPage from '../pages/LandingPage/LandingPage.vue'
import AboutUs from '../components/LandingPage/AboutUs/Parallax.vue'
import Transport from '../components/LandingPage/Transports/Transport.vue'
import ContactUs from '../components/LandingPage/Contact Us/ContactUs.vue'

const routes = [   
  { path: '/', component: LandingPage },
  { path: '/AboutUs', component: AboutUs },
  { path: '/Transports', component: Transport },
  { path: '/ContactUs', component: ContactUs },
  
];

const router = createRouter({
  history: createMemoryHistory(),
  routes,
});

export default router