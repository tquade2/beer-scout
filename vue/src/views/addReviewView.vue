<template>
  <div id="everything">
    <div class="container">
      <form action="#" v-on:submit.prevent="CreateNewReview">
        <h1 class="text">Leave A Review</h1>
        <div class="form-row">
          <div class="kids">
            <label for="title">Title</label>
            <div class="input-data">
              <input
                type="text"
                name="title"
                id="title"
                v-model="newReview.title"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
          <div class="kids">
            <label for="rating">Rate (1-5)</label>
            <div class="input-data">
              <input
                type="text"
                name="rating"
                id="rating"
                v-model="newReview.rating"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
        </div>
        <div class="form-row">
          <div class="kids">
            <label for="description">Description</label>
            <div class="input-data">
              <input
                type="text"
                name="description"
                id="description"
                v-model="newReview.description"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
        </div>
        <div class="form-row button-container">
          <button type="submit">Add Review</button>
          <button type="button" v-on:click="cancelForm">Cancel</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import reviewService from "../services/ReviewService";

export default {
  name: "addReview",
  data() {
    return {
      beerId: this.$route.params.beerId,
      newReview: {},
    };
  },
  methods: {
    CreateNewReview() {
      this.newReview.beerId = this.beerId;
      reviewService
        .addReview(this.newReview)
        .then(() => {
          this.newReview = {};
          this.$router.push({
            name: "beerInfo",
            params: { beerId: this.newReview.beerId },
          });
        })
        .catch((error) => {
          console.log("reached catch");
          if (error.response) {
            console.log("Error adding review: ", error.response.status);
          } else if (error.request) {
            console.log("Error adding review: unable to communicate to server");
          } else {
            console.log("Error adding review: make request");
          }
        });
    },
    cancelForm() {
      this.newReview = {};
      this.$router.push({ name: "beerInfo", params: { beerId: this.beerId } });
    },
  },
};
</script>

<style scoped>
h1 {
  display: flex;
  justify-content: center;
  text-align: center;
  color: #333;
  font-size: 25px;
  font-family: sans-serif;
  margin-bottom: 20px;
}

form {
  width: 100%;
  padding-left: 30px;
  padding-bottom: 30px;
  border: 1px solid #ccc;
  border-radius: 25px;
  box-shadow: inset;
  box-shadow: 1px 20px 20px rgba(0, 0, 0, 0.1);
  background-color: white;
}

textarea {
  width: 100%;
  padding: 8px;
  box-sizing: border-box;
  border: 1px solid #ccc;
  border-radius: 4px;
}

label {
  display: flex;
  font-weight: bold;
  color: #555;
}

input,
textarea {
  padding: 8px;
  box-sizing: border-box;
  border: 1px solid #ccc;
  border-radius: 4px;
}

button {
  background-color: #cb6f6f;
  color: #fff;
  padding: 10px 15px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

button[type="button"] {
  background-color: #4a2328;
}

.container form .form-row {
  display: flex;
  margin: 32px 0;
}

.kids {
  display: flex;
  width: 70%;
}

.kids label {
  width: 70px;
}
button {
  margin-right: 10px;
  display: flex;
  justify-content: center;
}
form .form-row .input-data {
  width: 200px;
  height: 40px;
  margin: 0 20px;
  position: relative;
}

.desc {
  max-height: 70px;
}

#description-field {
  width: 70%;
}
</style>
