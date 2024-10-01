import { createMemoryHistory, createRouter } from 'vue-router'


const routes = [   
  { path: '/', component: ()=> import('../pages/LandingPage/LandingPage.vue') },
  { path: '/SignIn', name: 'SignIn',component: ()=> import('../components/forms/people/authentication/SignIn.vue')},
  { path: '/SignUp', name: 'SignUp',component:  ()=> import('../components/forms/people/register/SignUp.vue')},
  
  // Admin views 
  { path: '/admin/home', name: 'admin/home',component: ()=> import('../views/admin/Home.vue') },
  { path: '/admin/routes', name: 'admin/routes',component: ()=> import('../views/admin/Routes.vue') },
  { path: '/admin/companies', name: 'admin/companies',component: ()=> import('../views/admin/Companies.vue') },
  { path: '/admin/drivers', name: 'admin/drivers',component: ()=> import('../views/admin/Drivers.vue') },
  { path: '/admin/requestTransports', name: 'admin/requestTransports',component: ()=> import('../views/admin/RequestTransport.vue') },
  { path: '/admin/transports', name: 'admin/transports',component: ()=> import('../views/admin/Transports.vue') },
  { path: '/admin/passengers', name: 'admin/passengers',component: ()=> import('../views/admin/Passengers.vue') },
  

];

const router = createRouter({
  history: createMemoryHistory(),
  routes,
});

export default router;