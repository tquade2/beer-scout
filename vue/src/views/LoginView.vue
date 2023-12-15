<template>
  <body>
    <form @submit.prevent="login" class="login-form">
      <h1>Log In</h1>
      <div class="alert-message" v-if="invalidCredentials">
        <em id="alert" role="alert">Invalid username and password!</em>
      </div>
      <div class="alert-message" role="alert" v-if="$route.query.registration">
        Thank you for registering, please sign in.
      </div>
      <div class="input-container">
        <input
          placeholder="Username"
          type="text"
          id="username"
          v-model="user.username"
          required
          autofocus
        />
      </div>
      <div class="input-container">
        <input
          placeholder="Password"
          type="password"
          id="password"
          v-model="user.password"
          required
        />
      </div>
      <div class="btn-container">
        <button class="sign-in-btn" type="submit">Sign in</button>
      </div>
      <div>
        <p class="sign-up">
          Need an account?
          <router-link class="sign-up-btn" :to="{ name: 'register' }"
            >Sign up!</router-link
          >
        </p>
      </div>
    </form>
  </body>
</template>

<script>
import authService from "../services/AuthService";

export default {
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status === 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>

<style scoped>
body {
  background-image: url("/icons/breweryBackground4.jpg");
  background-size: cover;
  height: 800px;
  width: 2000px;
  margin: 0px;
}
.login-form {
  position: absolute;
  left: 35%;
  top: 35%;
  height: 35vh;
  width: 25vw;
  padding: 20px;
  background-color: #fcf8e9;
  border-radius: 10px;
  box-shadow: 6px 12px 9px black;
}

h1 {
  text-align: center;
}

.alert-message {
  margin-bottom: 15px;
  text-align: center;
  color: red;
}

.input-container {
  margin-bottom: 15px;
}

label {
  display: block;
  font-weight: bold;
}

input {
  width: 100%;
  padding: 8px;
  margin-top: 5px;
  box-sizing: border-box;
  border: 1px solid black;
  border-radius: 5px;
}
input:hover,
input:focus {
  outline-color: #a3cb6f;
}
.btn-container {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.sign-in-btn {
  background-color: #f4a23f;
  font-weight: bold;
  color: #fff;
  width: 100%;
  padding: 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}
.sign-in-btn:hover {
  background-color: #f3b05f;
}

.sign-up-btn {
  text-decoration: none;
  color: #7da54a;
  font-weight: bold;
}
.sign-up {
  text-align: center;
}
.sign-up-btn:hover {
  color: #bce685;
}

#username,
#password {
  background-color: #fdfcf3;
}
</style>
