<template>
  <b-navbar class="margin-navbar" variant="dark" type="dark">
    <b-navbar-brand>
      <b-icon style="margin-right:5px" icon="card-list"></b-icon>Permisos
    </b-navbar-brand>

    <b-collapse id="nav-text-collapse" is-nav>
      <b-navbar-nav>
        <b-nav-text>
          <router-link class="margin-link" to="/">Permisos</router-link>
        </b-nav-text>
        <b-nav-text>
          <router-link class="margin-link" to="/permitstype">Tipos de permisos</router-link>
        </b-nav-text>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</template>

<script>
export default {
  name: "Header",
};
</script>

<style scoped>
.margin-navbar {
  margin-bottom: 20px;
}

.margin-link {
  margin-left: 10px;
  margin-right: 10px; 
}
</style>
