<template>
  <div class="container">
    <router-link class="nav-link" v-bind:to="{ name: 'home' }">
      <img class="beer-icon" src="../../icons/beer.png" />
      Home
    </router-link>
    <router-link class="nav-link" v-bind:to="{ name: 'brewery' }">
      <img class="beer-icon" src="../../icons/barrel.png" />
      Breweries
    </router-link>
    <router-link class="nav-link" v-bind:to="{ name: 'beer' }">
      <img class="beer-icon" id="bottle" src="../../icons/bottle.png" />
      Beers
    </router-link>
    <router-link class="nav-link" v-bind:to="{ name: 'about' }">
      <img class="beer-icon" id="grain" src="../../icons/grain.png" />
      About
    </router-link>
    <router-link
      class="nav-link"
      v-bind:to="{ name: 'myBreweries' }"
      v-if="
        this.$store.state.user.role == 'admin' ||
        this.$store.state.user.role == 'brewer'
      "
    >
      <img class="beer-icon" src="../../icons/hop.png" />
      My Breweries
    </router-link>

    <router-link
      class="nav-link"
      v-bind:to="{ name: 'myBeers' }"
      v-if="
        this.$store.state.user.role == 'admin' ||
        this.$store.state.user.role == 'brewer'
      "
    >
      <img class="beer-icon" src="../../icons/beers.png" />
      My Beers
    </router-link>
    <router-link
      v-bind:to="{ name: 'logout' }"
      v-if="$store.state.token != ''"
      class="nav-link"
    >
      <img class="beer-icon" src="../../icons/empty_beer.png" />
      Logout
    </router-link>
    <router-link
      v-bind:to="{ name: 'login' }"
      v-if="$store.state.token === ''"
      class="nav-link"
    >
      <img class="beer-icon" src="../../icons/cheers.png" />
      Login
    </router-link>
  </div>
</template>

<script>
export default { name: "Header" };
</script>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-wrap: wrap;
  flex-direction: row;
  height: 100%;
  width: 100%;
  gap: 5px;
  margin-bottom: 10px;
  border-bottom: 2px solid #4a2328;
  padding-bottom: 5px;
}

.nav-link {
  display: flex;
  justify-content: center;
  align-items: center;
  text-decoration: none;
  font-weight: bold;
  font-size: 20px;
  color: #4a2328;
  margin: 0 25px;
  margin-left: 0;
}

.beer-icon {
  width: 40px;
  margin-left: 0;
  margin-right: 5px;
}

.router-link-active {
  color: #f4a23f;
}

#grain,
#bottle {
  margin: 0;
}
</style>
