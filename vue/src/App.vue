<template>
  <div id="app">
    <Header />
    <router-view />
  </div>
</template>

<script>
import Header from "./components/Header.vue";

export default { components: { Header } };
</script>

<style>
html {
  background-color: #fef9e1;
}

.page {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}

h1 {
  background-color: #f4a23f;
  color: #fef9e1;
  box-shadow: 8px 8px 8px black;
  border-radius: 10px;
  padding: 10px;
  font-family: serif;
}

.item {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  border-radius: 10px;
  color: #4a2328;
  background-color: #c570615c;
  font-family: sans-serif;
  text-decoration: none;
  padding: 10px;
  margin: 10px;
  width: 50%;
}

.button {
  background-color: #4a2328;
  color: #fef9e1;
  font-size: 12pt;
  padding: 10px;
  text-decoration: none;
  border-radius: 25px;
  white-space: nowrap;
  text-decoration: none;
  font-weight: bold;
}

.brewer-button,
.admin-button {
  background-color: black;
  color: white;
  font-size: 12pt;
  padding: 10px;
  text-decoration: none;
  border-radius: 25px;
  white-space: nowrap;
}

hr {
  border-color: #4a2328;
  border-style: solid;
  margin-top: 0;
}
</style>
