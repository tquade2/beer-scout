<template>
  <router-Link v-bind:to="{ name: 'beerInfo', params: { beerId: item.id } }">
    <div class="beers">
      <h4 class="name">{{ item.name }} | {{ item.abv }}% | {{ item.type }}</h4>
      <div class="buttons">
        <button
          v-if="$route.name == 'myBeers'"
          class="button"
          v-on:click="DeleteABeer(item.id)"
        >
          Delete
        </button>
        <router-Link
          class="button"
          v-if="$route.name == 'myBeers'"
          v-bind:to="{ name: 'editBeer', params: { beerId: item.id } }"
          >Edit
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
.type-abv {
  text-align: center;
  margin: 10px;
  color: black;
  margin-top: 0;
}
.name {
  text-align: center;
  margin-bottom: 0px;
  color: black;

  margin-top: 0;
}
.description {
  text-align: center;
  margin: 10px;
  color: black;
}

a {
  text-decoration: none;
}

.beers {
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #f4a33f5c;
  border-radius: 10px;
  padding: 15px;
  margin: 5px;
  text-align: justify;
  max-width: 400px;
  min-width: 400px;
}

.button {
  background-color: black;
  color: white;
  cursor: pointer;
  font-weight: bold;
  border-radius: 25px;
  border: none;
  text-decoration: none;
  font-family: sans-serif;
  font-size: small;
  margin: 5px;
  padding: 2px;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 5px 10px;
}

.buttons {
  display: flex;
  justify-content: center;
  margin-top: 5px;
}
</style>
