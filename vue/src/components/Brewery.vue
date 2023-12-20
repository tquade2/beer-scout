<template>
  <div class="item">
    <h3 class="logo-name">
      <img
        class="logo"
        v-bind:src="item.logo"
        onerror="this.onerror=null; this.src='/icons/barrel.png'"
      />
      {{ item.name }}
    </h3>
    <hr />
    <p>{{ item.category }}</p>
    <p>
      {{ item.streetAddress }}, {{ item.city }}, {{ item.state }} {{ item.zip }}
    </p>
    <p>{{ item.phone }}</p>
    <p>{{ item.email }}</p>
    <div class="buttons">
      <router-Link
        class="button"
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
.item {
  width: 30%;
  min-width: 250px;
}

h3,
p {
  margin: 5px;
  text-align: center;
}

.logo-name {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: row;
  margin: 10px;
}

.buttons {
  display: flex;
  justify-content: center;
  margin: 10px;
}

.logo {
  height: 75px;
  margin: 10px;
}

hr {
  width: 95%;
}
</style>
