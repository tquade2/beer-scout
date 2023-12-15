<template>
  <div class="everything">
    <h2 class="beer-title">
      {{ beer.name }} | {{ beer.abv }}% | {{ beer.type }}
    </h2>
    <section class="info">
      <h4>Description</h4>
      <div class="description">{{ beer.description }}</div>
    </section>
    <div class="addReview-container">
      <router-Link
        v-if="
          this.$store.state.user.role == 'admin' ||
          this.$store.state.user.role == 'user'
        "
        class="addReview"
        v-bind:to="{ name: 'addReview', params: { Id: breweryId } }"
        >Add a Review
      </router-Link>
    </div>
    <section class="reviews" v-if="reviews.length > 0">
      <h3 class="review-list-title">Reviews</h3>
      <review
        v-for="review in reviews"
        v-bind:key="review.id"
        v-bind:item="review"
      ></review>
    </section>
    <section v-if="reviews.length == 0">
      <p class="no-review">No reviews to display</p>
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
  min-width: 80%;
  background-color: #dcdcd9;
}

.review-list-title {
  text-align: center;
}

.everything {
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;
  background-color: #ffc1765c;
  border-radius: 10px;
  padding: 40px;
}
.no-review {
  font-weight: bolder;
}
.addReview {
  text-decoration: none;
  background-color: #a3cb6f;
  border-radius: 25px;
  color: white;
  padding: 5px;
}
.addReview:hover {
  background-color: #b5e17b;
}
.beer-title {
  margin: 10px;
}

h4 {
  margin: 10px;
}
.info {
  text-align: center;
  font-family: sans-serif;
  padding-bottom: 20px;
}
</style>
