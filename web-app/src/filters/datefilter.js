import moment from 'moment'
import Vue from "vue";

Vue.filter('datefilter', (value) => {
  if (value) {
    return moment(String(value)).format('MM/DD/YYYY')
  }
})