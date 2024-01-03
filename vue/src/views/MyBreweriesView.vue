<template>
  <div class="page">
    <h1>Brewery List</h1>
    <router-Link
      v-if="this.$store.state.user.role == 'admin'"
      class="admin-button"
      v-bind:to="{ name: 'addBrewery' }"
      >Add Brewery
    </router-Link>
    <Brewery
      v-for="brewery in breweries"
      v-bind:key="brewery.id"
      v-bind:item="brewery"
    />
  </div>
</template>

<script>
import Brewery from "../components/Brewery.vue";
import breweryService from "../services/BreweryService";

export default {
  components: { Brewery },
  name: "listBreweries",
  data() {
    return {
      breweries: [],
      newBrewery: {},
      username: this.$store.state.user.username,
    };
  },
  methods: {
    loadBreweries() {
      if (this.$store.state.user.role == "admin") {
        breweryService
          .listBreweries()
          .then((response) => {
            console.log("Reached listMyBreweries in MyBrewery");
            console.log(response);
            this.breweries = response.data;
          })
          .catch((error) => {
            if (error.response) {
              console.log(
                "Error loading my breweries: ",
                error.response.status
              );
            } else if (error.request) {
              console.log(
                "Error loading my breweries: unable to communicate to server"
              );
            } else {
              console.log("Error loading my breweries: make request");
            }
          });
      } else {
        breweryService
          .listBreweriesByUser(this.username)
          .then((response) => {
            console.log(response);
            this.breweries = response.data;
          })
          .catch((error) => {
            if (error.response) {
              console.log(
                "Error loading my breweries: ",
                error.response.status
              );
            } else if (error.request) {
              console.log(
                "Error loading my breweries: unable to communicate to server"
              );
            } else {
              console.log("Error loading my breweries: make request");
            }
          });
      }
    },
  },
  created() {
    console.log("reached created in MyBreweries");
    this.loadBreweries();
  },
};
</script>
