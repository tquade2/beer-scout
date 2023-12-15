<template>
  <div class="review">
    <h4 class="info">{{ item.title }}</h4>
    <div class="info" v-html="createStarRating()"></div>
    <p>{{ item.description }}</p>
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

.review h4 {
  font-size: 18px;
  margin-bottom: 10px;
  color: #333;
}

.review p {
  font-size: 16px;
  margin-bottom: 8px;
  color: #555;
}

.beer-rating-icon {
  width: 20px;
  height: 20px;
  margin-right: 5px;
}
.info{
  text-align: center;
}




/* .beer-icon{
 align-items: center;
  height: 40px;
} */

</style>
