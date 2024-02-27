<template>
  <div class="review">
    <h4 class="review-title">{{ item.title }}</h4>
    <p class="description">{{ item.description }}</p>
    <div class="rating" v-html="createStarRating()"></div>
  </div>
</template>

<script>
export default {
  name: "review",
  props: ["item"],
  methods: {
    createStarRating() {
      const rating = parseInt(this.item.rating);
      let starRating = "";
      for (let i = 0; i < rating; i++) {
        starRating += `<img class="beer-rating-icon" src="/icons/beer.png">`;
      }
      return starRating;
    },
  },
};
</script>

<style>
.review {
  border: 1px solid #ccc;
  border-radius: 8px;
  padding: 15px;
  margin-bottom: 20px;
  background-color: #fff;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  min-width: 60%;
}

.review-title {
  font-size: 18px;
  margin: 10px;
  color: #333;
}

.description {
  font-size: 16px;
  margin: 10px;
  color: #555;
}

.rating {
  margin: 10px;
}

.beer-rating-icon {
  width: 20px;
  height: 20px;
  margin-right: 5px;
}
</style>
