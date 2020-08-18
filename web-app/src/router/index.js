import Vue from 'vue'
import VueRouter from 'vue-router'
import TypePermits from '../views/TypePermits'
Vue.use(VueRouter)

const routes = [

    {
        path: '/',
        name: 'permitstype',
        component: TypePermits
    },
    {
        path: '/permitstype',
        name: 'permitstype',
        component: TypePermits
    },

]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})

export default router
