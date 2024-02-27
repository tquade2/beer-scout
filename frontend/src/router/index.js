import { createRouter as createRouter, createWebHistory } from "vue-router";
import { useStore } from "vuex";

// Import components
import HomeView from "../views/HomeView.vue";
import LoginView from "../views/LoginView.vue";
import LogoutView from "../views/LogoutView.vue";
import RegisterView from "../views/RegisterView.vue";

import MyBreweriesView from "../views/MyBreweriesView.vue"
import BreweryView from "../views/BreweryView.vue";
import BreweryInfoView from "../views/BreweryInfoView.vue";
import AddBreweryView from "../views/AddBreweryView.vue";
import EditBreweryView from "../views/EditBreweryView.vue";

import MyBeersView from "../views/MyBeersView.vue"
import Beer from "../components/Beer.vue";
import BeerView from "../views/BeerView.vue";
import BeerInfoView from "../views/BeerInfoView.vue";
import AddBeerView from "../views/AddBeerView.vue";
import EditBeerView from "../views/EditBeerView.vue";

import AddReviewView from "../views/addReviewView.vue";
import AboutView from "../views/AboutView.vue";

const routes = [
  {
    path: "/",
    name: "home",
    component: HomeView,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "/login",
    name: "login",
    component: LoginView,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "/logout",
    name: "logout",
    component: LogoutView,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "/register",
    name: "register",
    component: RegisterView,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "/brewery",
    name: "brewery",
    component: BreweryView,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "/brewery/:breweryId",
    name: "editBrewery",
    component: EditBreweryView,
    meta: {
      requiresAuth: true,
    },
  },
  {
    path: "/brewery/createBrewery",
    name: "addBrewery",
    component: AddBreweryView,
    meta: {
      requiresAuth: true,
    },
  },
  {
    path: "/brewery/breweryInfo/:breweryId",
    name: "breweryInfo",
    component: BreweryInfoView,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "/beer/byBrewery/:breweryId",
    name: "beerByBrewery",
    component: Beer,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "/beer/createBeer/:breweryId",
    name: "addBeer",
    component: AddBeerView,
    meta: {
      requiresAuth: true,
    },
  },
  {
    path: "/beer/beerInfo/:beerId",
    name: "beerInfo",
    component: BeerInfoView,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "/about",
    name: "about",
    component: AboutView,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "/beer",
    name: "beer",
    component: BeerView,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "/beer/:beerId",
    name: "editBeer",
    component: EditBeerView,
    meta: {
      requiresAuth: true,
    },
  },
  {
    path: "/review/createReview/:beerId",
    name: "addReview",
    component: AddReviewView,
    meta: {
      requiresAuth: true,
    },
  },
  {
    path: "/brewery/myBreweries",
    name: "myBreweries",
    component: MyBreweriesView,
    meta: {
      requiresAuth: true,
    },
  },
  {
    path: "/beer/myBeers",
    name: "myBeers",
    component: MyBeersView,
    meta: {
      requiresAuth: true,
    },
  },
];

// Create the router
const router = createRouter({
  history: createWebHistory(),
  routes: routes,
});

router.beforeEach((to) => {
  // Get the Vuex store
  const store = useStore();

  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some((x) => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === "") {
    return { name: "login" };
  }
  // Otherwise, do nothing and they'll go to their next destination
});

export default router;
