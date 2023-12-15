<template>
  <body>
    <form class="login-form" v-on:submit.prevent="register">
      <h1>Create Account</h1>
      <div class="alert-message" v-if="registrationErrors">
        <em id="alert" role="alert">{{ registrationErrorMsg }}</em>
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
      <div class="input-container">
        <input
          placeholder="Confirm Password"
          type="password"
          id="confirmPassword"
          v-model="user.confirmPassword"
          required
        />
      </div>
      <div class="btn-container">
        <button class="create-btn" type="submit">Create Account</button>
      </div>
      <div>
        <p class="log-in">
          Already have an account?
          <router-link class="login-in-btn" v-bind:to="{ name: 'login' }"
            >Log in.</router-link
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
        confirmPassword: "",
        role: "user",
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/login",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
  },
};
</script>

<style scoped>
body {
  background-image: url("/icons/breweryBackground4.jpg");
  background-size: cover;
  height: 800px;
  width: 1900px;
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
  box-shadow: 6px 12px 9px grey;
}

h1 {
  text-align: center;
}

.alert-message {
  margin-bottom: 15px;
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

.create-btn {
  background-color: #7da54a;
  color: #fff;
  padding: 10px 15px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  width: 100%;
  font-weight: bold;
}
.create-btn:hover {
  background-color: #7da54a;
}

.login-in-btn {
  text-decoration: none;
  color: #7da54a;
  font-weight: bold;
}
.login-in-btn:hover {
  color: #bce685;
}

.log-in {
  text-align: center;
}

#username,
#password, #confirmPassword {
  background-color: #fdfcf3;
}
</style>
