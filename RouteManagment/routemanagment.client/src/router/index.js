import { createMemoryHistory, createRouter } from 'vue-router'

import LandingPage from '../pages/LandingPage/LandingPage.vue'
import AboutUs from '../components/LandingPage/AboutUs/AboutUs.vue'
import Transport from '../components/LandingPage/Transports/Transport.vue'
import ContactUs from '../components/LandingPage/Contact Us/ContactUs.vue'
import SignIn from '../components/Forms/Authentication/SignIn.vue'

const routes = [   
  { path: '/', component: LandingPage },
  { path: '/AboutUs', component: AboutUs },
  { path: '/Transports', component: Transport },
  { path: '/ContactUs', component: ContactUs },

  { path: '/SignIn', name: 'SignIn',component: SignIn }
];

const router = createRouter({
  history: createMemoryHistory(),
  routes,
});

export default router;