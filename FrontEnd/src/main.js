import Vue from 'vue'

import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import VueRouter from 'vue-router'
import axios from 'axios'
Vue.prototype.$axios=axios;

import App from './App.vue'
import Value from './components/Value.vue'
import Hello from './components/HelloWorld.vue'

Vue.use(ElementUI);


Vue.use(VueRouter);

const routes=[
  {path:'/helloworld',name:"heollo",component:Hello},
  {path:'/value',name:"value",component:Value},
]
const router = new VueRouter({
  routes
})

Vue.config.productionTip = false;

new Vue({
  render: h => h(App),
  router
}).$mount('#app')
