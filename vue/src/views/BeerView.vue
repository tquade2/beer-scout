<template>
  <div class="beer">
    <div class="title-container">
      <h1 class="title">Beer List</h1>
    </div>
    <div class="beers">
      <beer
        v-for="beer in beers"
        v-bind:key="beer.id"
        v-bind:item="beer"
      ></beer>
    </div>
  </div>
</template>

<script>
import beer from "../components/Beer.vue";
import BeerService from "../services/BeerService";

export default {
  components: { beer },
  name: "BeerView",
  data() {
    return {
      beers: [],
    };
  },
  methods: {
    loadAllBeers() {
      BeerService.listAllBeers()
        .then((response) => {
          console.log(response);
          console.log("Reached loadAllBeers in BeerView");
          this.beers = response.data;
        })
        .catch((error) => {
          if (error.response) {
            console.log("Error loading beers: ", error.response.status);
          } else if (error.request) {
            console.log("Error loading beers: unable to communicate to server");
          } else {
            console.log("Error loading beers: make request");
          }
        });
    },
  },
  created() {
    this.loadAllBeers();
  },
};
</script>

<style>
.title-container {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}

.beer {
  display: flex;
  justify-content: center;
  flex-direction: column;
  font-family: sans-serif;
}

.beers {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  /* gap: 10px; */
}
</style>
