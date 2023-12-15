<template>
    <div class="brewery">
      <h1>Brewery List</h1>
      <div class="buttons">
        <router-Link
          v-if="this.$store.state.user.role == 'admin'"
          class="button"
          v-bind:to="{ name: 'addBrewery' }"
          >Add Brewery
        </router-Link>
      </div>
      <section class="container">
        <brewery
          v-for="brewery in breweries"
          v-bind:key="brewery.id"
          v-bind:item="brewery"
        />
      </section>
    </div>
  </template>
  
  <script>
  import Brewery from "../components/Brewery.vue";
  import breweryService from "../services/BreweryService";
  
  export default {
    components: { Brewery },
    name: "listBreweries",
    data() {
      return {
        breweries: [],
        newBrewery: {},
        username: this.$store.state.user.username,
      };
    },
    methods: {
      loadBreweries() {
        if(this.$store.state.user.role == 'admin'){
            breweryService
          .listBreweries()
          .then((response) => {
            console.log("Reached listMyBreweries in MyBrewery");
            console.log(response);
            this.breweries = response.data;
          })
          .catch((error) => {
            if (error.response) {
              console.log("Error loading my breweries: ", error.response.status);
            } else if (error.request) {
              console.log(
                "Error loading my breweries: unable to communicate to server"
              );
            } else {
              console.log("Error loading my breweries: make request");
            }
          });
        }
        else{
        breweryService
          .listBreweriesByUser(this.username)
          .then((response) => {
            console.log(response);
            this.breweries = response.data;
          })
          .catch((error) => {
            if (error.response) {
              console.log("Error loading my breweries: ", error.response.status);
            } else if (error.request) {
              console.log(
                "Error loading my breweries: unable to communicate to server"
              );
            } else {
              console.log("Error loading my breweries: make request");
            }
          });
        }
      },
    },
    created() {
      console.log("reached created in MyBreweries");
      this.loadBreweries();
    },
  };
  </script>
  
  <style scoped>
  .button {
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: black;
    color: white;
    font-size: 12pt;
    padding: 10px;
    text-decoration: none;
    border-radius: 25px;
    margin: 10px;
    width: 100px;
  }
  .buttons {
    display: flex;
    justify-content: center;
    margin: 10px;
  }
  .brewery {
    /* max-width: 800px; */
    /* height: 100%;
    width: 100%; */
    padding: 20px;
    font-family: Arial, sans-serif;
  }
  
  h1 {
    text-align: center;
    margin: 10px;
  }
  
  .container {
    display: flex;
    flex-direction: column;
    /* flex-wrap: wrap; */
    width: 100%;
    height: 100%;
    gap: 10px;
    justify-content: center;
  }
  
  .input {
    margin-bottom: 10px;
  }
  
  label {
    font-weight: bold;
    display: block;
    margin-bottom: 5px;
  }
  
  button {
    padding: 10px 20px;
    background-color: black;
    color: #fff;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    margin-right: 10px;
  }
  
  button[type="submit"] {
    background-color: black;
  }
  
  button[type="submit"]:hover,
  button[type="button"]:hover {
    background-color: #0056b3;
  }
  
  .addBtn {
    margin-bottom: 10px;
  }
  </style>
  