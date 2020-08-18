<template>
  <div id="app">
    <Header />
    <TypePermits/>
  </div>
</template>

<script>
import Header from './components/Header'
import TypePermits from './components/TypePermits'


export default {
  name: 'App',
  components: {
    Header,
    TypePermits
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
</style>
