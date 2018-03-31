<template>
  <div id="app" class="container-fluid bg-light">
    <div class="row h-100">
      <div id="nav" class="col-sm-3 flex-column align-items-stretch navbar navbar-dark bg-dark">
          <div class="navbar-nav nav nav-pills nav-fill" role="tablist" aria-orientation="vertical">
            <router-link class="nav-item nav-link" to="/content" data-toggle="pill">Content</router-link>
            <router-link class="nav-item nav-link" to="/bar" data-toggle="pill">Lookups</router-link>
          </div>
      </div>
      <div class="col-sm-9 justify-content-center align-items-start">
          <router-view/>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'App',
};
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  height: 100vh;
}
</style>
