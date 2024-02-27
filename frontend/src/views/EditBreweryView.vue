<template>
  <div id="everything">
    <div class="container">
      <form action="#" v-on:submit.prevent="editBrewery">
        <h1 class="text">Editing ~{{ breweryToUpdate.name }}~</h1>
        <div class="form-row">
          <div class="kids">
          <label for="name">Name</label>
          <div class="input-data">
            <input
              type="text"
              name="name"
              id="name"
              v-model="breweryToUpdate.name"
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
              v-model="breweryToUpdate.streetAddress"
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
              v-model="breweryToUpdate.city"
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
              v-model="breweryToUpdate.state"
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
                v-model="breweryToUpdate.zip"
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
                v-model="breweryToUpdate.phone"
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
                v-model="breweryToUpdate.email"
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
                v-model="breweryToUpdate.website"
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
                v-model="breweryToUpdate.mapLink"
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
                v-model="breweryToUpdate.category"
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
                v-model="breweryToUpdate.logo"
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
                v-model="breweryToUpdate.photo"
                required
              />
              <div class="underline"></div>
            </div>
          </div>
        </div>
        <div class="form-row">
         
            <label for="description">Description</label>
            <div class="input-data" id="description-field">
              <textarea class="desc"
                rows="10"
                cols="200"
                v-model="breweryToUpdate.description"
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
  name: "editBrewery",
  data() {
    return {
      breweryId: this.$route.params.breweryId,
      breweryToUpdate: {},
    };
  },
  methods: {
    editBrewery() {
      console.log("Reached updateBrewery in EditBreweryView");
      if (this.breweryToUpdate.id) {
        breweryService
          .updateBrewery(this.breweryToUpdate)
          .then(() => {
            console.log("Reached updateBrewery in EditBreweryView");
            this.$router.push({ name: "brewery" });
          })
          .catch((error) => {
            if (error.response) {
              console.log("Error updating brewery: ", error.response.status);
            } else if (error.request) {
              console.log(
                "Error updating brewery: unable to communicate with the server"
              );
            } else {
              console.log("Error updating brewery: request error");
            }
          });
      } else {
        console.log("No breweryToUpdate.id provided.");
      }
    },
    cancelForm() {
      this.breweryToUpdate = {};
      this.$router.push({ name: "myBreweries" });
    },
  },
  created() {
    breweryService
      .getBrewery(this.breweryId)
      .then((response) => {
        const brewery = response.data;

        this.breweryToUpdate = {
          id: brewery.id,
          name: brewery.name,
          streetAddress: brewery.streetAddress,
          city: brewery.city,
          state: brewery.state,
          zip: brewery.zip,
          phone: brewery.phone,
          email: brewery.email,
          website: brewery.website,
          mapLink: brewery.mapLink,
          description: brewery.description,
          category: brewery.category,
          logo: brewery.logo,
          photo: brewery.photo,
        };
      })
      .catch((error) => {
        console.error("Error fetching brewery data:", error);
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
body {
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
  /* padding-right: 30px; */
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

/* .input {
  margin-bottom: 15px;
} */

label {
  display: flex;
  margin-bottom: 5px;
  font-weight: bold;
  width: 10%;
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
input {
  display: flex;
  align-items: flex-start;
}

.button-container{
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
.container form .form-row {
  display: flex;
  margin: 25px 0;
  max-width: 2000px;
  width: 100%;
  padding-left: 50px;
}
.kids{
  display: flex;
  width: 100%;

}

.kids label{
  width: 70px;
}
form .form-row .input-data {
  width: 200px;
  height: 40px;
  margin: 0 20px;
  position: relative;
}
.desc{
  max-height:70px;
  /* height:20%; */
}
#description-field{
  width: 70%;

  
}

/* form .form-row .textarea {
  height: 20%;
} */
</style>
