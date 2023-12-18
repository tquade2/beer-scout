<template>
  <div id="info">
    <p class="name">BeerScout</p>
    <p>info@beerscout.com</p>
    <p>© 2023 BeerScout</p>
  </div>
</template>

<script>
export default {
  name: "footer",
};
</script>

<style scoped>
#info {
  display: flex;
  justify-content: center;
  text-align: center;
  flex-wrap: true;
  height: 25px;
  font-family: sans-serif;
  margin-top: 10px;
  color: #4a2328;
}

p {
  display: flex;
  flex-wrap: true;
  justify-content: center;
  align-items: center;
  margin-left: 30px;
  margin-right: 30px;
}

.name {
  font-weight: bold;
}
</style>
