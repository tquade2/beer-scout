<template>
  <div class="content">
    <router-link class="nav" v-bind:to="{ name: 'home' }">
      <img class="icon" src="../../icons/beer.png" />
      Home
    </router-link>
    <router-link class="nav" v-bind:to="{ name: 'brewery' }">
      <img class="icon" src="../../icons/barrel.png" />
      Breweries
    </router-link>
    <router-link class="nav" v-bind:to="{ name: 'beer' }">
      <img class="icon" id="bottle-icon" src="../../icons/bottle.png" />
      Beers
    </router-link>
    <router-link class="nav" v-bind:to="{ name: 'about' }">
      <img class="icon" id="grain-icon" src="../../icons/grain.png" />
      About
    </router-link>
    <router-link
      class="nav"
      v-bind:to="{ name: 'myBreweries' }"
      v-if="
        this.$store.state.user.role == 'admin' ||
        this.$store.state.user.role == 'brewer'
      "
    >
      <img class="icon" src="../../icons/hop.png" />
      My Breweries
    </router-link>
    <router-link
      class="nav"
      v-bind:to="{ name: 'myBeers' }"
      v-if="
        this.$store.state.user.role == 'admin' ||
        this.$store.state.user.role == 'brewer'
      "
    >
      <img class="icon" src="../../icons/beers.png" />
      My Beers
    </router-link>
    <router-link
      class="nav"
      v-bind:to="{ name: 'logout' }"
      v-if="$store.state.token != ''"
    >
      <img class="icon" src="../../icons/empty_beer.png" />
      Logout
    </router-link>
    <router-link
      class="nav"
      v-bind:to="{ name: 'login' }"
      v-if="$store.state.token === ''"
    >
      <img class="icon" src="../../icons/cheers.png" />
      Login
    </router-link>
  </div>
  <hr />
</template>

<script>
export default { name: "Header" };
</script>

<style scoped>
.content {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
  margin-bottom: 10px;
}

.nav {
  display: flex;
  align-items: center;
  text-decoration: none;
  font-weight: bold;
  font-size: 20px;
  color: #4a2328;
  margin: 0 25px;
  margin-left: 0;
  margin-top: 10px;
}

.icon {
  width: 45px;
  margin-left: 0;
  margin-right: 5px;
}

.router-link-active {
  color: #f4a23f;
}

#grain-icon,
#bottle-icon {
  margin: 0;
}
</style>
