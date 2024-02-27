<template>
  <router-Link v-bind:to="{ name: 'beerInfo', params: { beerId: item.id } }">
    <div class="beerbox">
      <div class="name">
        {{ item.name }} | {{ item.abv }}% | {{ item.type }}
      </div>
      <div class="buttons">
        <button
          v-if="$route.name == 'myBeers'"
          class="brewer-button"
          v-on:click="DeleteABeer(item.id)"
        >
          Delete Beer
        </button>
        <router-Link
          class="brewer-button"
          v-if="$route.name == 'myBeers'"
          v-bind:to="{ name: 'editBeer', params: { beerId: item.id } }"
          >Edit Beer
        </router-Link>
      </div>
      <div>
        <Review
          v-for="review in reviews"
          v-bind:key="review.id"
          v-bind:item="review"
        />
      </div>
    </div>
  </router-Link>
</template>

<script>
import beerService from "../services/BeerService";
import Review from "../components/Review.vue";

export default {
  name: "beer",
  props: ["item"],
  components: { Review },
  data() {
    return {
      authorized: false,
    };
  },
  methods: {
    DeleteABeer(id) {
      beerService
        .deleteBeer(id)
        .then((response) => {
          console.log("Reached DELETE in BeerComponent");
          console.log(response);
          this.$router.push({ name: "myBeers" });
        })
        .catch((error) => {
          if (error.response) {
            console.log("Error deleting beer: ", error.response.status);
          } else if (error.request) {
            console.log("Error deleting beer: unable to communicate to server");
          } else {
            console.log("Error deleting beer: make request");
          }
        });
    },
    SendToInfo() {
      this.$router.push({ name: "beerInfo" });
    },
  },
  created() {
    if (
      this.$store.state.user.role == "admin" ||
      this.$store.state.user.role == "brewer"
    ) {
      this.authorized = true;
    } else {
      this.authorized = false;
    }
  },
};
</script>

<style scoped>
.beerbox {
  display: flex;
  flex-direction: column;
  background-color: #f59e3476;
  border-radius: 10px;
  padding: 10px;
  margin: 5px;
  max-width: 400px;
  min-width: 400px;
  align-items: center;
  justify-content: center;
}

.name {
  text-align: center;
  margin-bottom: 5px;
  color: black;
  margin-top: 0;
  font-size: large;
}

a {
  text-decoration: none;
}
</style>
