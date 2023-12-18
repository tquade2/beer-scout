<template>
  <div class="container">
    <div class="title-container">
      <h1 class="title">Brewery List</h1>
    </div>
    <div class="brewery-container">
      <brewery
        v-for="brewery in breweries"
        v-bind:key="brewery.id"
        v-bind:item="brewery"
      />
    </div>
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

<style scoped>
.container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 50vw;
}

.title-container {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}

.brewery-container {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
  gap: 10px;
}
</style>
