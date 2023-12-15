import axios from "axios";

const http = axios.create({ baseURL: "https://localhost:44315" });

export default {
  listReviews(reviewId) {
    return http.get(`/review/${reviewId}`);
  },
  addReview(newReview) {
    return http.post(`/review/createReview`, newReview);
  },
  deleteReview(reviewId) {
    return http.delete(`/review/${reviewId}`);
  },
  ListReviewsForBeer(beerId) {
    return http.get(`/review/byBeer/${beerId}`);
  },
};
