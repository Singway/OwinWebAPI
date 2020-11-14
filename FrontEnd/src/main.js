import Vue from 'vue'

import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import VueRouter from 'vue-router'
import axios from 'axios'
Vue.prototype.$axios=axios;

import App from './App.vue'
import Value from './components/Value.vue'
import Hello from './components/HelloWorld.vue'
import socketTest from './components/socketTest.vue'
import PickList from './components/TestPickList.vue'

Vue.use(ElementUI);


Vue.use(VueRouter);

const routes=[
  {path:'/',redirect:'/helloworld'},
  {path:'/helloworld',name:"heollo",component:Hello},
  {path:'/value',name:"value",component:Value},
  {path:'/socket',name:"socket",component:socketTest},
  {path:'/pickList',name:"picklist",component:PickList},
]
const router = new VueRouter({
  routes
})

Vue.config.productionTip = false;

new Vue({
  render: h => h(App),
  router
}).$mount('#app')
