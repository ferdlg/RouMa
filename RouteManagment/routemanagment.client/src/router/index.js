import { createMemoryHistory, createRouter } from 'vue-router'


const routes = [   
  { path: '/', component: ()=> import('../pages/LandingPage/LandingPage.vue') },
  { path: '/SignIn', name: 'SignIn',component: ()=> import('../components/Forms/Authentication/SignIn.vue')},
  { path: '/SignUp', name: 'SignUp',component:  ()=> import('../components/Forms/Register/SignUp.vue')},
  
  // Admin views 
  { path: '/admin/home', name: 'admin/home',component: ()=> import('../views/Admin/Home.vue') },
  { path: '/admin/routes', name: 'admin/routes',component: ()=> import('../views/Admin/Routes.vue') },
  { path: '/admin/companies', name: 'admin/companies',component: ()=> import('../views/Admin/Companies.vue') },
  { path: '/admin/drivers', name: 'admin/drivers',component: ()=> import('../views/Admin/Drivers.vue') },
  { path: '/admin/requestTransports', name: 'admin/requestTransports',component: ()=> import('../views/Admin/RequestTransport.vue') },
  { path: '/admin/transports', name: 'admin/transports',component: ()=> import('../views/Admin/Transports.vue') },
  { path: '/admin/passengers', name: 'admin/passengers',component: ()=> import('../views/Admin/Passengers.vue') },
  

];

const router = createRouter({
  history: createMemoryHistory(),
  routes,
});

export default router;