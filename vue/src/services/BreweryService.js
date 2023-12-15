import axios from "axios";

const http = axios.create({ baseURL: "https://localhost:44315" });

export default {
  listBreweries() {
    return http.get("/brewery");
  },
  addBrewery(newBrewery) {
    return http.post("/brewery/createBrewery", newBrewery);
  },
  updateBrewery(updatedBrewery) {
    return http.put(`/brewery/${updatedBrewery.id}`, updatedBrewery);
  },
  getBrewery(id) {
    return http.get(`/brewery/${id}`);
  },
  listBreweriesByUser(username){
    return http.get(`/brewery/byUser/${username}`);
  }
};
