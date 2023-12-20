<template>
  <div class="page">
    <h1>Breweries</h1>
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
    };
  },
  methods: {
    loadBreweries() {
      breweryService
        .listBreweries()
        .then((response) => {
          console.log("Reached listBreweries in BreweryView");
          console.log(response);
          this.breweries = response.data;
        })
        .catch((error) => {
          if (error.response) {
            console.log("Error loading breweries: ", error.response.status);
          } else if (error.request) {
            console.log(
              "Error loading breweries: unable to communicate to server"
            );
          } else {
            console.log("Error loading breweries: make request");
          }
        });
    },
  },
  created() {
    console.log("reached created in BreweryView");
    this.loadBreweries();
  },
};
</script>
