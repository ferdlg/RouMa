import { createMemoryHistory, createRouter } from 'vue-router'

import LandingPage from '../pages/LandingPage/LandingPage.vue'
import AboutUs from '../components/LandingPage/AboutUs/Parallax.vue'
import Blog from '../components/LandingPage/Blog/Blog.vue'
import HowToUse from '../components/LandingPage/HowToUse/HowToUse.vue'

const routes = [   
  { path: '/', component: LandingPage },
  { path: '/AboutUs', component: AboutUs },
  { path: '/Blog', component: Blog },
  { path: '/How', component: HowToUse },
  
];

const router = createRouter({
  history: createMemoryHistory(),
  routes,
});

export default router