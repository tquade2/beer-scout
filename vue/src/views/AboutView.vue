<template>
  <div class="about">
    <section>
      <h2>Our Story</h2>
      <p>
        BrewScout was born out of a shared love for great beer and a desire to
        make the craft beer experience more accessible to everyone. Taylor,
        Garrett, and Daniel discovered their mutual passion for craft beer
        during their time at Tech Elevator, where they decided to combine their
        skills in web development and their appreciation for the rich tapestry
        of flavors that craft breweries offer.
      </p>
    </section>
    <section>
      <h2>What is BrewScout?</h2>
      <p>
        BrewScout is your go-to destination for discovering and exploring the
        wonderful world of craft beer. Our platform was designed with one goal
        in mind: to connect beer enthusiasts like you with the best breweries
        and brews near you. Whether you're a seasoned beer connoisseur or just
        dipping your toes into the craft beer scene, BrewScout is your trusted
        companion for finding the perfect pint.
      </p>
    </section>
    <section>
      <h2>What We Offer</h2>
      <h3>Beer & Brewery Finder</h3>
      <p>
        Our intuitive beer finder tool helps you locate breweries in your area.
        Just enter your location, and we'll show you a list of nearby breweries
        with their specialties, opening hours, and directions.
      </p>

      <h3>Community and Reviews</h3>
      <p>
        Join a community of fellow beer enthusiasts to share your experiences,
        reviews, and recommendations. Connect with like-minded individuals who
        share your passion for craft beer.
      </p>
    </section>
    <section>
      <h2>Our Commitment</h2>
      <p>
        At BrewScout, we are committed to promoting responsible drinking and
        supporting local craft breweries. We believe that great beer brings
        people together and fosters a sense of community. By using BrewScout,
        you're not just discovering amazing beers; you're also supporting the
        talented brewers and businesses that make them possible.
      </p>
    </section>
    <section>
      <h2>Get in Touch</h2>
      <p>
        We love hearing from our users! Whether you have feedback, suggestions,
        or just want to chat about your latest beer adventure, feel free to
        reach out to us. You can contact Taylor, Garrett, and Daniel directly
        through our
        <a href="mailto:info@brewscout.com">email</a>.
      </p>
    </section>
    <footer>
      <p>
        Thank you for choosing BrewScout as your beer companion. Cheers to great
        beer, new friendships, and unforgettable experiences!
      </p>
    </footer>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.about {
  max-width: 800px;
  margin: 50px auto;
  padding: 20px;
  background-color: #ffc1765c;
  box-shadow: inset;
  box-shadow: 6px 12px 9px grey;
  border-radius: 10px;
}

section {
  margin-bottom: 30px;
  color: #4a2328;
}

h2 {
  color: #4a2328;
  text-align: center;
  border-bottom: 2px solid #4a2328;
  padding-bottom: 5px;
  margin-bottom: 20px;
}

h3 {
  color: #4a2328;
  margin-bottom: 10px;
}

p {
  line-height: 1.6;
}

a {
  color: #007bff;
  text-decoration: none;
  font-weight: bold;
}

a:hover {
  text-decoration: underline;
}

footer {
  margin-top: 30px;
  text-align: center;
  color: #555;
}

footer p {
  font-style: italic;
  font-weight: bold;
}
</style>
