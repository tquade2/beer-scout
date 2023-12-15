import axios from "axios";

const http = axios.create({ baseURL: "https://localhost:44315" });

export default {
  listAllBeers() {
    return http.get("/beer");
  },
  listBeers(brewerId) {
    return http.get(`/beer/byBrewery/${brewerId}`);
  },
  listBeersByUser(username){
    return http.get(`/beer/byUser/${username}`);
  },
  getBeer(beerId) {
    return http.get(`/beer/${beerId}`);
  },
  addBeer(newBeer) {
    return http.post(`/beer/createBeer`, newBeer);
  },
  deleteBeer(beerId) {
    return http.delete(`/beer/${beerId}`);
  },
  updateBeer(updatedBeer) {
    return http.put(`/beer/${updatedBeer.id}`, updatedBeer);
  },
};
