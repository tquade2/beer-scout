<template>
  <body>
    <form v-on:submit.prevent="editBeer">
      <h1>Edit Beer</h1>
      <div class="input">
        <label for="name">Name </label>
        <input
          type="text"
          name="name"
          id="name"
          v-model="beerToUpdate.name"
          required
        />
      </div>
      <div class="input">
        <label for="type">Type</label>
        <input
        type="text"
        name="type"
        id="type"
        v-model="beerToUpdate.type"
        required
        />
      </div>
      <div class="input">
        <label for="abv">ABV %</label>
        <input type="text" name="abv" id="abv" v-model="beerToUpdate.abv" required />
      </div>
      <div class="input">
        <label for="description">Description</label>
        <textarea
          type="text"
          name="description"
          id="description"
          v-model="beerToUpdate.description"
          required
        />
      </div>
      
      <button type="submit">Save</button>
      <button type="button" v-on:click="cancelForm">Cancel</button>
    </form>
  </body>
</template>

<script>
import beerService from "../services/BeerService";
import axios from "axios";

export default {
  name: "editBeer",
  data() {
    return {
      beerId: this.$route.params.beerId,
      beerToUpdate: {},
    };
  },
  methods: {
    editBeer() {
      if (this.beerToUpdate.id) {
        beerService
          .updateBeer(this.beerToUpdate)
          .then(() => {
            this.$router.push({ name: "myBeers" });
          })
          .catch((error) => {
            if (error.response) {
              console.log("Error updating beer: ", error.response.status);
            } else if (error.request) {
              console.log(
                "Error updating beer: unable to communicate with the server"
              );
            } else {
              console.log("Error updating beer: request error");
            }
          });
      }
    },
    cancelForm() {
      this.beerToUpdate = {};
      this.showForm = false;
      this.$router.push({ name: "myBeers" });
    },
  },
  created() {
    axios
      .get(`/beer/${this.beerId}`)
      .then((response) => {
        const beer = response.data;

        this.beerToUpdate = {
          id: beer.id,
          name: beer.name,
          description: beer.description,
          type: beer.type,
          abv: beer.abv,
        };
      })
      .catch((error) => {
        console.error("Error fetching beer data:", error);
      });
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
body{
  display: flex;
  justify-content: center;
  max-width: 1000px; 
  width: 100%;
  margin: 0 auto;
  padding: 60px; 
}

form {
  max-width: 1000px; /* Set your desired maximum width */
  width: 100%;
  margin: 0 auto;
  /* padding: 60px; Adjust padding for better spacing */
  padding-left: 30px;
  padding-right: 30px;
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

.input {
  margin-bottom: 15px;
}

label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
  color: #555;
}

input,
textarea {
  width: 100%;
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
  margin-left: 8px;
  justify-content: center;
}

button[type="button"] {
  background-color: #4a2328;
  margin-left: 10px;
  justify-content: center;
}
</style>
