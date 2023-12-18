<template>
  <div id="app">
    <div class="nav">
      <Header />
    </div>
    <main>
      <router-view />
    </main>
    <div id="foot">
      <Footer />
    </div>
  </div>
</template>

<script>
import Header from "./components/Header.vue";
import Footer from "./components/Footer.vue";

export default { components: { Header, Footer } };
</script>

<style>
#capstone-app {
  background-color: #fef9e1;
}

.title {
  background-color: #f4a23f;
  color: #fef9e1;
  box-shadow: 6px 12px 9px black;
  border-radius: 10px;
  height: fit-content;
  width: fit-content;
  padding: 5px;
  font-size: xx-large;
}
</style>
