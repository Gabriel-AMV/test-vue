import Vue from 'vue'
import App from './App.vue'
import './filters/datefilter'
// Bootstrap Vue
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

// Axios
import axios from 'axios'
import VueAxios from 'vue-axios'
Vue.use(VueAxios, axios)

import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';

import VueRouter from 'vue-router'
import router from './router'
Vue.use(VueRouter)

Vue.use(VueSweetalert2);

Vue.config.productionTip = false
new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
