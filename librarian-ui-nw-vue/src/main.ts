import Vue from 'vue';
import App from './App.vue';
import mitt from "mitt";
import store from './store'

Vue.config.productionTip = false;

/** Mitt event bus */
export const mitter = mitt();

new Vue({
  store,
  render: h => h(App)
}).$mount('#app');
