<template>
  <router-Link
    class="brewery"
    v-bind:to="{ name: 'breweryInfo', params: { breweryId: item.id } }"
  >
    <h3>{{ item.name }}</h3>
    <hr />
    <p>{{ item.category }}</p>
    <p>
      {{ item.streetAddress }}, {{ item.city }}, {{ item.state }}
      {{ item.zip }}
    </p>
    <p>{{ item.phone }}</p>
    <p>{{ item.email }}</p>
    <div class="buttons">
      <p v-if="$route.name == 'myBreweries'">
        <router-Link
          class="button"
          v-bind:to="{ name: 'editBrewery', params: { breweryId: item.id } }"
          >Edit Brewery</router-Link
        >
      </p>
    </div>
  </router-Link>
</template>

<script>
export default {
  name: "brewery",
  props: ["item"],
};
</script>

<style scoped>
hr {
  width: 90%;
  margin-top: 0;
}

.brewery {
  display: flex;
  justify-content: center;
  flex-direction: column;
  border-radius: 10px;
  background-color: #c570615c;
  height: 100%;
  width: 400px;
  text-decoration: none;
  color: #4a2328;
  font-family: sans-serif;
}

.brewery-name {
  text-decoration: underline;
}
.button {
  background-color: black;
  color: white;
  font-size: 12pt;
  padding: 10px;
  text-decoration: none;
  border-radius: 25px;
  white-space: nowrap;
}

.buttons {
  display: flex;
  justify-content: center;
  margin: 10px;
}

.updateBtn {
  padding: 5px 27px;
  color: #fff;
  border: none;
  margin-top: 10px;
  cursor: pointer;
}

h3,
p {
  margin: 7px;
  text-align: center;
  flex-wrap: wrap;
}
</style>
