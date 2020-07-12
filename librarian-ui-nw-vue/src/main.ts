import Vue from 'vue';
import App from './App.vue';
import mitt from "mitt";

Vue.config.productionTip = false;

/** Mitt event bus */
export const mitter = mitt();

new Vue({
  render: h => h(App)
}).$mount('#app');
