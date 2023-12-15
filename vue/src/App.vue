<template>
  <div id="capstone-app">
    <div id="nav">
      <Header class="header" />
      <div class="content">
        <router-view />
      </div>
      <Footer class="footer" />
    </div>
  </div>
</template>

<script>
import Header from "./components/Header.vue";
import Footer from "./components/Footer.vue";

export default { components: { Header, Footer } };
</script>

<style scoped>
#capstone-app {
  display: flex;
  flex-direction: column;
  background-color: #fef9e1;
  min-height: 97vh;
}

#nav {
  flex: 1;
  display: flex;
  flex-direction: column;
}

.content {
  display: flex;
  justify-content: center;
  align-items: center;
  flex: 1;
}

.footer {
  flex-shrink: 0;
}
</style>
