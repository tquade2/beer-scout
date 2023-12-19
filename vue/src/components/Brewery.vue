<template>
  <div class="item">
    <h3>{{ item.name }}</h3>
    <p>{{ item.category }}</p>
    <p>
      {{ item.streetAddress }}, {{ item.city }}, {{ item.state }} {{ item.zip }}
    </p>
    <p>{{ item.phone }}</p>
    <p>{{ item.email }}</p>
    <div class="buttons">
      <router-Link class="button"
        v-bind:to="{ name: 'breweryInfo', params: { breweryId: item.id } }"
        >More Info
      </router-Link>
      <p v-if="$route.name == 'myBreweries'">
        <router-Link
          class="brewer-button"
          v-bind:to="{ name: 'editBrewery', params: { breweryId: item.id } }"
          >Edit Brewery
        </router-Link>
      </p>
    </div>
  </div>
</template>

<script>
export default {
  name: "brewery",
  props: ["item"],
};
</script>

<style scoped>
h3,
p {
  margin: 5px;
  text-align: center;
  flex-wrap: wrap;
}

h3 {
  border-bottom: 2px solid #4a2328;
}

.buttons {
  display: flex;
  justify-content: center;
  margin: 10px;
}
</style>
