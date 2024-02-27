<template>
  <div class="page">
    <h1>My Beers</h1>
    <div class="buttons">
      <router-Link
        v-if="this.$store.state.user.role == 'brewer'"
        class="brewer-button"
        v-bind:to="{ name: 'addBeer', params: { breweryId: this.breweryId } }"
        >Add Beer
      </router-Link>
    </div>
    <section class="container">
      <Beer v-for="beer in beers" v-bind:key="beer.id" v-bind:item="beer" />
    </section>
  </div>
</template>

<script>
import Beer from "../components/Beer.vue";
import beerService from "../services/BeerService";

export default {
  components: { Beer },
  name: "ListBeers",
  data() {
    return {
      beers: [],
      breweryId: null,
      username: this.$store.state.user.username,
    };
  },
  methods: {
    loadBeers() {
      if (this.$store.state.user.role == "admin") {
        beerService
          .listAllBeers()
          .then((response) => {
            console.log("Reached listMyBeers in MyBeers");
            console.log(response);
            this.beers = response.data;
            this.breweryId = this.beers[0].breweryId;
          })
          .catch((error) => {
            if (error.response) {
              console.log("Error loading my beers: ", error.response.status);
            } else if (error.request) {
              console.log(
                "Error loading my beers: unable to communicate to server"
              );
            } else {
              console.log("Error loading my beers: make request");
            }
          });
      } else {
        beerService
          .listBeersByUser(this.username)
          .then((response) => {
            this.beers = response.data;
            this.breweryId = this.beers[0].breweryId;
          })
          .catch((error) => {
            if (error.response) {
              console.log("Error loading my beers: ", error.response.status);
            } else if (error.request) {
              console.log(
                "Error loading my beers: unable to communicate to server"
              );
            } else {
              console.log("Error loading my beers: make request");
            }
          });
      }
    },
  },
  created() {
    console.log("reached created in MyBeers");
    this.loadBeers();
    // this.breweryId = this.beers[0].breweryId;
  },
};
</script>

<style scoped>
.beer {
  padding: 20px;
  font-family: Arial, sans-serif;
}

h1 {
  text-align: center;
  margin: 10px;
}

.container {
  display: flex;
  flex-wrap: wrap;
  gap: 10px;
  justify-content: center;
}

.input {
  margin-bottom: 10px;
}

label {
  font-weight: bold;
  display: block;
  margin-bottom: 5px;
}

.addBtn {
  margin-bottom: 10px;
}
</style>
