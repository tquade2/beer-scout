<template>
  <div id="app">
    <Header />
    <main>
      <router-view />
    </main>
  </div>
</template>

<script>
import Header from "./components/Header.vue";

export default { components: { Header } };
</script>

<style>
#app {
  background-color: #fef9e1;
}

main {
  display: flex;
  justify-content: center;
  align-items: center;
}

h1 {
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
  background-color: #f4a23f;
  color: #fef9e1;
  box-shadow: 8px 8px 8px black;
  border-radius: 10px;
  padding: 10px;
  font-family: serif;
}

.content {
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
  flex-direction: column;
  width: 50vw;
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
  min-width: 300px;
}

.nav {
  display: flex;
  align-items: center;
  text-decoration: none;
  font-weight: bold;
  font-size: 20px;
  color: #4a2328;
  margin: 0 25px;
  margin-left: 0;
  margin-top: 10px;
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
  width: 95%;
  border-color: #4a2328;
  border-style: solid;
  margin-top: 0;
}
</style>
