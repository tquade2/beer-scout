<template>
  <div class="page">
    <h1>{{ beer.name }} | {{ beer.abv }}% | {{ beer.type }}</h1>
    <div class="description">{{ beer.description }}</div>
    <router-Link
      v-if="
        this.$store.state.user.role == 'admin' ||
        this.$store.state.user.role == 'user'
      "
      class="button"
      v-bind:to="{ name: 'addReview', params: { Id: breweryId } }"
      >Add a Review
    </router-Link>
    <section class="reviews" v-if="reviews.length > 0">
      <h3 class="reviews-title">Reviews</h3>
      <review
        v-for="review in reviews"
        v-bind:key="review.id"
        v-bind:item="review"
      ></review>
    </section>
    <section v-if="reviews.length == 0">
      <h2>No reviews yet</h2>
    </section>
  </div>
</template>

<script>
import Beer from "../components/Beer.vue";
import Review from "../components/Review.vue";
import beerService from "../services/BeerService";
import reviewService from "../services/ReviewService";

export default {
  components: { Review },
  name: "BeerInfoView",
  data() {
    return {
      id: this.$route.params.beerId,
      beer: {},
      reviews: [],
    };
  },
  methods: {
    loadBeer(id) {
      beerService
        .getBeer(id)
        .then((response) => {
          console.log("Reached loadBeers in BeerInfo");
          console.log(response);
          this.beer = response.data;
        })
        .catch((error) => {
          if (error.response) {
            console.log("Error loading brewery: ", error.response.status);
          } else if (error.request) {
            console.log(
              "Error loading brewery: unable to communicate to server"
            );
          } else {
            console.log("Error loading brewery: make request");
          }
        });
    },
    loadReviews(id) {
      console.log("Reached loadReviews in BeerInfo");
      reviewService
        .ListReviewsForBeer(id)
        .then((response) => {
          console.log(response);
          console.log("Reached then in LoadReviews in BeerInfo");
          this.reviews = response.data;
        })
        .catch((error) => {
          if (error.response) {
            console.log("Error loading reviews: ", error.response.status);
          } else if (error.request) {
            console.log(
              "Error loading reviews: unable to communicate to server"
            );
          } else {
            console.log("Error loading reviews: make request");
          }
        });
    },
  },

  created() {
    console.log("Reached created in BeerInfo");
    this.loadBeer(this.id);
    this.loadReviews(this.id);
  },
};
</script>

<style scoped>
.reviews {
  font-family: sans-serif;
  padding: 20px;
  padding-top: 10px;
  margin: 10px;
  border-radius: 10px;
  min-width: 50%;
  background-color: #dcdcd9;
}

.reviews-title {
  text-align: center;
  margin: 10px;
}

.description {
  text-align: center;
  font-family: sans-serif;
  margin: 10px;
}
</style>
