<template>
  <body>
    <form v-on:submit.prevent="createNewBeer">
      <h1>Add New Beer</h1>
      <div class="input">
        <label for="name">Name </label>
        <input
          type="text"
          name="name"
          id="name"
          v-model="newBeer.name"
          required
        />
      </div>
      <div class="input">
        <label for="type">Type</label>
        <input
          type="text"
          name="type"
          id="type"
          v-model="newBeer.type"
          required
        />
      </div>
      <div class="input">
        <label for="abv">ABV %</label>
        <input type="text" name="abv" id="abv" v-model="newBeer.abv" required />
      </div>
      <div class="input">
        <label for="description">Description</label>
        <textarea
          type="text"
          name="description"
          id="description"
          v-model="newBeer.description"
          required
        />
      </div>

      <button type="submit">Add Beer</button>
      <button type="button" v-on:click="cancelForm">Cancel</button>
    </form>
  </body>
</template>

<script>
import beerService from "../services/BeerService";
import BreweryService from "../services/BreweryService";

export default {
  name: "addBeer",
  data() {
    return {
      breweryId: this.$route.params.breweryId,
      newBeer: {},
      showMessage: false,
    };
  },
  methods: {
    createNewBeer() {
      this.newBeer.breweryId = this.breweryId;
      beerService
        .addBeer(this.newBeer)
        .then(() => {
          console.log("Reached createNewBeer in AddBeerView");
          this.newBeer = {};
          this.showMessage = false;
          this.$router.push({ name: "breweryInfo" });
        })
        .catch((error) => {
          console.log("reached catch");
          if (error.response) {
            console.log("Error adding beer: ", error.response.status);
          } else if (error.request) {
            console.log("Error adding beer: unable to communicate to server");
          } else {
            console.log("Error adding beer: make request");
          }
        });
    },
    //   getBreweryId(id){
    //     BreweryService
    //     .getBrewery(id)
    //     .then((response) => {
    //       console.log("Reached loadBrewery in BreweryInfoView");
    //       console.log(response);
    //       this.brewery = response.data;
    //     })
    //     .catch((error) => {
    //       if (error.response) {
    //         console.log("Error loading brewery: ", error.response.status);
    //       } else if (error.request) {
    //         console.log(
    //           "Error loading brewery: unable to communicate to server"
    //         );
    //       } else {
    //         console.log("Error loading brewery: make request");
    //       }
    //     });
    //   },
    cancelForm() {
      this.newBeer = {};
      this.showMessage = false;
      this.$router.push({ name: "breweryInfo" });
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

body {
  display: flex;
  justify-content: center;
  max-width: 1000px; /* Set your desired maximum width */
  width: 100%;
  margin: 0 auto;
  padding: 60px; /* Adjust padding for better spacing */
  /* border: 1px solid #ccc;
  border-radius: 25px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  background-color: #fff; */
}

form {
  max-width: 600px; /* Set your desired maximum width */
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
