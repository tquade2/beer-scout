<template>
  <div id="everything">
    <div class="container">
      <form action="#" v-on:submit.prevent="editBrewery">
        <h1 class="text">Add New Brewery</h1>
        <div class="form-row">
          <div class="kids">
            <label for="name">Name</label>
            <div class="input-data">
              <input
                type="text"
                name="name"
                id="name"
                v-model="newBrewery.name"
                required
              />

              <div class="underline"></div>
              <div class="underline"></div>
            </div>
          </div>
          <!-- closing kids -->
          <div class="kids">
            <label for="streetAddress">Street Address</label>
            <div class="input-data">
              <input
                type="text"
                name="streetAddress"
                id="streetAddress"
                v-model="newBrewery.streetAddress"
                required
              />
            </div>
          </div>
        </div>
        <div class="form-row">
          <div class="kids">
            <label for="city">City</label>
            <div class="input-data">
              <input
                type="text"
                name="city"
                id="city"
                v-model="newBrewery.city"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
          <div class="kids">
            <label for="state">State</label>
            <div class="input-data">
              <input
                type="text"
                name="state"
                id="state"
                v-model="newBrewery.state"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
        </div>
        <div class="form-row">
          <div class="kids">
            <label for="zip">Zip</label>
            <div class="input-data">
              <input
                type="text"
                name="zip"
                id="zip"
                v-model="newBrewery.zip"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
          <div class="kids">
            <label for="phone">Phone</label>
            <div class="input-data">
              <input
                type="text"
                name="phone"
                id="phone"
                v-model="newBrewery.phone"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
        </div>
        <div class="form-row">
          <div class="kids">
            <label for="email">Email</label>
            <div class="input-data">
              <input
                type="text"
                name="email"
                id="email"
                v-model="newBrewery.email"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
          <div class="kids">
            <label for="website">Website URL</label>
            <div class="input-data">
              <input
                type="text"
                name="website"
                id="website"
                v-model="newBrewery.website"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
        </div>
        <div class="form-row">
          <div class="kids">
            <label for="map-link">Map Link</label>
            <div class="input-data">
              <input
                type="text"
                name="mapLink"
                id="map-link"
                v-model="newBrewery.mapLink"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
          <div class="kids">
            <label for="category">Category</label>
            <div class="input-data">
              <input
                type="text"
                name="category"
                id="category"
                v-model="newBrewery.category"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
        </div>

        <div class="form-row">
          <div class="kids">
            <label for="logo">Logo</label>
            <div class="input-data">
              <input
                type="text"
                name="logo"
                id="logo"
                v-model="newBrewery.logo"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
          <div class="kids">
            <label for="photo">Photo</label>
            <div class="input-data">
              <input
                type="text"
                name="photo"
                id="photo"
                v-model="newBrewery.photo"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
        </div>
        <div class="form-row">
          <label for="description">Description</label>
          <div class="input-data" id="description-field">
            <textarea
              class="desc"
              rows="10"
              cols="200"
              v-model="newBrewery.description"
              required
            ></textarea>
            <div class="underline"></div>
          </div>
        </div>
        <br />
        <div class="button-container">
          <button type="submit">Save</button>
          <button type="button" v-on:click="cancelForm">Cancel</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import breweryService from "../services/BreweryService";

export default {
  name: "addBrewery",
  data() {
    return {
      newBrewery: {},
      // showMessage: false,
    };
  },
  methods: {
    createNewBrewery() {
      console.log("Reached METHOD in BreweryView");
      breweryService
        .addBrewery(this.newBrewery)
        .then(() => {
          console.log("Reached createNewBrewery in BreweryView");
          this.newBrewery = {};
          // this.showMessage = false;
          this.$router.push({ name: "brewery" });
        })
        .catch((error) => {
          console.log("reached catch");
          if (error.response) {
            console.log("Error adding brewery: ", error.response.status);
          } else if (error.request) {
            console.log(
              "Error adding brewery: unable to communicate to server"
            );
          } else {
            console.log("Error adding brewery: make request");
          }
        });
    },
    cancelForm() {
      this.newBrewery = {};
      this.showMessage = false;
      this.$router.push({ name: "brewery" });
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
  max-width: 1000px;
  width: 100%;
  margin: 0 auto;
  padding: 60px;
}

form {
  max-width: 1000px;
  width: 100%;
  margin: 0 auto;
  padding: 20px;
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
  margin-bottom: 5px;
  font-weight: bold;
  color: #555;
  width: 50px;
}

input,
textarea {
  width: 100%;
  padding: 8px;
  box-sizing: border-box;
  border: 1px solid #ccc;
  border-radius: 4px;
}
input {
  display: flex;
  align-items: flex-start;
}

.button-container {
  display: flex;
  justify-content: center;
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
.form-row {
  display: flex;
  justify-content: center;
  align-items: center;
  margin: 20px 0;
  max-width: 2000px;
  width: 100%;
}
.kids {
  display: flex;
}

/* .kids label {
  width: 70px;
} */
form .form-row .input-data {
  width: 200px;
  height: 40px;
  margin: 0 20px;
  position: relative;
}
.desc {
  max-height: 70px;
  margin-left: 10px;
}

#description-field {
  width: 70%;
}
</style>
