USE master
GO

--drop database if it exists
IF DB_ID('beer_scout_db') IS NOT NULL
BEGIN
	ALTER DATABASE beer_scout_db SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE beer_scout_db
END

CREATE DATABASE beer_scout_db
GO

USE beer_scout_db
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL,
)

CREATE TABLE user_brewery(
	user_id INT NOT NULL,
	brewery_id INT NOT NULL,
	CONSTRAINT [PK_user_brewery] PRIMARY KEY (user_id, brewery_id)
		)

CREATE TABLE breweries (
	brewery_id int IDENTITY(100,1) PRIMARY KEY NOT NULL,
	name varchar(50) NOT NULL,
	street_address varchar(50) NOT NULL,
	city varchar(50) NOT NULL,
	state varchar(2) NOT NULL,
	zip varchar(5) NOT NULL,
	phone varchar (20),
	email varchar (50),
	website varchar (50),
	map_link varchar(400),
	description varchar(700),
	category varchar (100),
	logo varchar(450),
	photo varchar(450),
)

CREATE TABLE beers (
	beer_id int IDENTITY(200,1) PRIMARY KEY NOT NULL,
	name varchar(50),
	description varchar(250), 
	type varchar(50),
	abv varchar(10),
	brewery_id int,
)

CREATE TABLE reviews (
	review_id int IDENTITY (300,1) PRIMARY KEY NOT NULL,
	title varchar(50),
	description varchar(200),
	rating int CHECK(rating <= 5),
	beer_id int,
)

--insert default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','KxId9rb7BxkaNcR+PEeZlKx55o8=','X7Uhyh19m5Y=','admin')
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Tm6C8MifMlPhPugjSxv2oq2m7+E=','GkZzngmK6r0=','user')
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('b1','RbpdLmlYVQzVoR5qyqeQTXE4yio=','xRHNfnQjDQE=','brewer')
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('b2','4bR+LDSp4lWJtXCNTUxHAsKcoCM=','aqCrl2q+QWk=','brewer')
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('b3','J3Ah+OJr10hz2VU4Gu1lp8NpMj8=','NCt7r7+CqMQ=','brewer')
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('b4','GoUoZZBgDXG9qQgP9Ixat+ndOfI=','V3QXURDWpAU=','brewer')
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('b5','Uy93ezz5mjqCJ1hBHq2Ux2i2BJA=','QbI0ZECUCmQ=','brewer')

INSERT INTO user_brewery (user_id, brewery_id) VALUES (3,100)
INSERT INTO user_brewery (user_id, brewery_id) VALUES (4,101)
INSERT INTO user_brewery (user_id, brewery_id) VALUES (5,102)
INSERT INTO user_brewery (user_id, brewery_id) VALUES (6,103)
INSERT INTO user_brewery (user_id, brewery_id) VALUES (7,104)

INSERT INTO breweries (name, street_address, city, state, zip, phone, email, website, map_link, description, photo, category, logo)
	VALUES(
		'Yellow Springs Brewery',
		'2855 Indianola Ave',
		'Clintonville',
		'OH',
		'43202',
		'(614)-261-7128',
		'brew@yellowspringsbrewery.com',
		'https://www.yellowspringsbrewery.com',
		'https://www.google.com/maps/place/Yellow+Springs+Brewery/@39.8097995,-83.8884173,15z/data=!4m2!3m1!1s0x0:0xe15a75a9a2c43d21?sa=X&ved=2ahUKEwjtw92T84yDAxWhMjQIHajdAf8Q_BJ6BAgTEAA',
		'At Yellow Springs Brewery, we brew exceptional beer every day in every batch. Founded in 2013, today we produce multiple core and packaged brands along with dozens of innovative seasonal beers. They can be found in restaurants and pubs in the Dayton and Columbus areas and in our tap room in Yellow Springs.',
		'https://breakfastwithnick.com/wp-content/uploads/yellow-springs-brewery-columbus-14.jpeg',
		'Brewpub',
		'https://images.squarespace-cdn.com/content/v1/65410d79866d2b6c0256f373/4ec291e9-a251-4413-8796-008bcdce9524/Yellow-Springs-Brewery-Logo-Full-Color.png'
)

INSERT INTO breweries(name, street_address, city, state, zip, phone,email, website, map_link, description, photo, category, logo)
	VALUES(
		'Crooked Can Brewing Company',
		'5354 Center St',
		'Hilliard',
		'OH',
		'43026',
		'(614)-219-1500',
		'info@crookedcanohio.com',
		'https://crookedcanohio.com/',
		 'https://www.google.com/maps/place/Crooked+Can+Brewing+Co./@34.250797,-88.2021414,6z/data=!4m10!1m2!2m1!1sCrooked+Can+Brewing+Company!3m6!1s0x883893f992aea19b:0xe1c8c9ece1f3a626!8m2!3d40.0347009!4d-83.1602832!15sChtDcm9va2VkIENhbiBCcmV3aW5nIENvbXBhbnlaHSIbY3Jvb2tlZCBjYW4gYnJld2luZyBjb21wYW55kgEHYnJld3B1YpoBJENoZERTVWhOTUc5blMwVkpRMEZuU1VSYU1IRjVURGxuUlJBQuABAA!16s%2Fg%2F11h3vc5lms?entry=ttu',
		'At Crooked Can Brewing Company, experienced craftsmanship and science come together to brew deliciously memorable results. Our brewmasters are adept at blending old world techniques with cutting edge brewing practices for full-bodied, tastefully crisp beer. To us, fermentation is more than just a science. It�s a way of life! We look after all of our brews, carefully creating naturally cultured, refreshing beer.',
		'https://i.ytimg.com/vi/UH9Kf5X3brE/maxresdefault.jpg',
		'Bewpub',
		'https://crookedcanohio.com/bc/wp-content/uploads/crooked-can-full-label-logo.png'
)

INSERT INTO breweries (name, street_address, city, state, zip, phone, email, website, map_link, description, photo, category, logo)
	VALUES (
	   'Revolution Brewing',
	   '2323 N Milwaukee Ave',
	   'Chicago',
	   'IL',
	   '60647',
	   '(773)-227-2739',
	   'info@revbrew.com',
	   'https://www.revbrew.com',
	    'https://www.google.com/maps/search/Revolution+Brewing/@41.9329202,-87.7132803,15z/data=!3m1!4b1?entry=ttu',
	   'Revolution Brewing is a craft brewery located in the heart of Chicago. Established in 2010, we are known for our diverse lineup of handcrafted beers, including our flagship Anti-Hero IPA and Deep Wood series of barrel-aged brews. Visit our taproom and experience the revolution!',
	   'https://revolution-brewing.myshopify.com/cdn/shop/files/RevBrew-Horizontal-Primary_360x.png',
	   'Brewpub',
	   'https://www.revbrew.com/assets/img/logo/revolution-logo-stacked.svg'
)

INSERT INTO breweries (name, street_address, city, state, zip, phone, email, website, map_link, description, photo, category, logo)
	VALUES (
	   'Ballast Point Brewing Company',
	   '9045 Carroll Way',
	   'San Diego',
	   'CA',
	   '92121',
	   '(858)-790-6901',
	   'info@ballastpoint.com',
	   'https://www.ballastpoint.com',
	    'https://www.google.com/maps/search/Ballast+Point+Brewing+Company/@41.9329202,-87.7132803,15z?entry=ttu',
	   'Ballast Point Brewing Company is a renowned brewery located in sunny San Diego, California. Since 1996, weve been crafting innovative and award-winning beers, including Sculpin IPA and Grapefruit Sculpin. Come visit our brewery and taste the flavors of the coast!',
	   'https://www.ballastpoint.com/wp-content/uploads/2018/07/home-hero.jpg',
	   'Microbrewery',
	   'https://www.ballastpoint.com/wp-content/uploads/2018/05/ballast-point-logo.png'
)

INSERT INTO breweries (name, street_address, city, state, zip, phone, email, website, map_link, description, photo, category, logo)
	VALUES (
	   'Great Divide Brewing Co.',
	   '2201 Arapahoe St',
	   'Denver',
	   'CO',
	   '80205',
	   '(303)-296-9460',
	   'info@greatdivide.com',
	   'https://www.greatdivide.com',
	   'https://www.google.com/maps/search/Great+Divide+Brewing+Co./@39.8084846,-104.9146632,12z/data=!3m1!4b1?entry=ttu',
	   'Great Divide Brewing Co. is a Denver-based brewery founded in 1994. We specialize in crafting exceptional beers that push the boundaries of flavor and style. Our diverse portfolio includes classics like Yeti Imperial Stout and innovative seasonals. Join us in our taproom for a taste adventure!',
	   'https://www.greatdivide.com/wp-content/uploads/2018/03/homepage-hero.jpg',
	   'Craft Brewery',
	   'https://www.greatdivide.com/wp-content/uploads/2018/03/great-divide-logo.png'
)
INSERT INTO breweries (name, street_address, city, state, zip, phone, email, website, map_link, description, photo, category, logo)
	VALUES (
	   'Seventh Son Brewing Co.',
	   '1101 N. 4TH ST.',
	   'Columbus',
	   'OH',
	   '43201',
	   '(614)-421-BEER',
	   'info@seventhsonbrewing.com',
	   'https://www.seventhsonbrewing.com/homepage',
	   'https://www.google.com/maps/place/Seventh+Son+Brewing+Co./@39.9853671,-83.0022697,17z/data=!3m1!4b1!4m6!3m5!1s0x88388ece1e570549:0x76d37b7748664e44!8m2!3d39.985363!4d-82.9996948!16s%2Fg%2F11r8kbv3_?entry=ttu',
	   'Since April of 2013 Seventh Son has brewed over 225 different beers and has been consistently voted Columbus best brewery by 614 Magazine, Columbus Alive, and Columbus Underground readers. In November 2018 our sister brewery Antiques on High, a sour/wild focused barrel project and taproom, came into being in the Brewery District. Seventh Son Brewing and Antiques on High represent the collective efforts of childhood friends Jen Burton, Travis Spencer, and Collin Castore.  With the support of our 50 + team members, Seventh Son Brewing and Antiques on High strive to provide great beer and a unique experience for the people and city we love.',
	   'https://images.squarespace-cdn.com/content/v1/51abeb0be4b08f6a770c06bf/1551747191286-Y25KJTYZ4GFWR3XW90SY/39864533_1766743806784506_7173694874472939520_o-min.jpg?format=2500w',
	   'Craft Brewery',
	   'https://images.squarespace-cdn.com/content/v1/51abeb0be4b08f6a770c06bf/1551064989285-U9OBP4WWNUUNE03SYVNJ/Asset%2B1-min.png?format=1500w'
)

INSERT INTO beers (description, name, type, abv, brewery_id)  VALUES ('Juicy tropical fruit and citrus notes blaze through this fresh and hoppy American IPA.', 'Boat Show', 'IPA' ,'7.0', 100)
INSERT INTO beers (description, name, type, abv, brewery_id)  VALUES ('Light-bodied Saison with American Comet hops for a rustic, juicy citrus profile and a spicy yeast character, making it highly drinkable.', 'Captain Stardust', 'Saison ' ,'6.5', 100)
INSERT INTO beers (description, name, type, abv, brewery_id)  VALUES ('An imperial stout brewed with crisp American 2-Row malt and plenty of chocolate and roasted barley.', 'Maxxdout Stout', 'Imperial Stout' ,'11.2', 100)
INSERT INTO beers (description, name, type, abv, brewery_id)  VALUES ('Dry stout with roasted barley imparts malty depth. Enjoy coffee and bittersweet chocolate notes, leading to a dry finish perfect for any Ohio season!', 'Lost Echoes', 'Dry Stout' ,'5.2', 100)
INSERT INTO beers (description, name, type, abv, brewery_id)  VALUES ('Moderate-bodied Ale with chocolate and molasses notes, balanced by American hops for a bold, citrusy profile.', 'Handsome', 'Brown Ale' ,'5.5', 100)

INSERT INTO beers (description, name, type, abv, brewery_id)  VALUES ('Easy drinking. Citrus fruit hop flavor and aroma.', '3rd Rail Hazy Pale Ale', 'Pale Ale' ,'5.3', 101)
INSERT INTO beers (description, name, type, abv, brewery_id)  VALUES ('Sessionable IPA with citrus undertones.', 'Sayonara Summer', 'IPA' ,'4.1', 101)
INSERT INTO beers (description, name, type, abv, brewery_id)  VALUES ('Blonde ale infused with Prickly Pear. Portion of sales going to local Cancer Charities.', 'Nettie Ros ', 'Blonde Ale' ,'4.2', 101)
INSERT INTO beers (description, name, type, abv, brewery_id)  VALUES ('Crisp summertime lager with a malty backbone and subtle rye spice.', 'Est 1852 Lager', 'Lager' ,'5.2', 101)
INSERT INTO beers (description, name, type, abv, brewery_id)  VALUES ('Malty lager brewed with pumpkin puree and spices.', 'Passive Pumpkin', 'Pumpkin' ,'5.4', 101)

INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('Juicy tropical fruit and citrus notes blaze through this fresh and hoppy American IPA.', 'Anti-Hero', 'IPA', '6.7', 102);
INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A complex and robust porter with hints of chocolate and coffee.', 'Eugene', 'Porter', '6.8', 102);
INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A crisp and refreshing pilsner with a balanced malt and hop profile.', 'Cross of Gold', 'Pilsner', '5.0', 102);
INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A barrel-aged imperial stout with rich flavors of dark chocolate and roasted coffee.', 'Deth''s Tar', 'Imperial Stout', '14.8', 102);
INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A sour ale aged in oak barrels with the addition of fresh blackberries.', 'Very Mad Cow', 'Sour Ale', '7.0', 102);

INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A well-balanced IPA with bright citrus and tropical fruit flavors.', 'Sculpin IPA', 'IPA', '7.0', 103);
INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A refreshing wheat beer with coriander and sea salt.', 'Sour Wench', 'Wheat Beer', '7.0', 103);
INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A tropical IPA with hints of guava and passion fruit.', 'Mango Even Keel', 'Session IPA', '3.8', 103);
INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A rich and smooth stout with coffee and chocolate flavors.', 'Victory at Sea', 'Imperial Stout', '10.0', 103);
INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A classic Kölsch-style ale with a crisp and clean finish.', 'Longfin Lager', 'Kölsch', '4.5', 103);

INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A bold and hoppy double IPA with citrus and pine notes.', 'Hercules Double IPA', 'Double IPA', '10.0', 104);
INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A barrel-aged barleywine with caramel and toffee flavors.', 'Old Ruffian', 'Barleywine', '12.7', 104);
INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A crisp and refreshing lager with a hint of honey sweetness.', 'Colette Farmhouse Ale', 'Lager', '7.3', 104);
INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A rich and velvety chocolate stout with roasted malt character.', 'Yeti Imperial Stout', 'Imperial Stout', '9.5', 104);
INSERT INTO beers (description, name, type, abv, brewery_id) VALUES ('A hoppy pale ale with tropical fruit and citrus aromas.', 'Heyday Modern IPA', 'Pale Ale', '5.8', 104);

INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Delightful Craft Beer', 'I absolutely loved the rich flavors of this craft beer. It had a perfect balance of hops and malt.', 5, 200);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Pleasant Surprise', 'This beer exceeded my expectations. The flavors were delightful, and it left a positive impression.', 4, 206);

INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Delightful Craft Beer', 'I absolutely loved the rich flavors of this craft beer. It had a perfect balance of hops and malt.', 5, 209);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Great Porter!', 'Eugene is a fantastic porter with deep chocolate and coffee notes. Highly recommended!', 4, 210);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Refreshing Pilsner', 'Cross of Gold is my go-to beer for a hot summer day. Crisp and refreshing!', 4, 211);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Bold and Dark', 'Deths Tar is not for the faint-hearted. Its a bold and dark imperial stout with intense flavors.', 4, 212);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Unique Sour Ale', 'Very Mad Cow surprised me with its unique sourness and blackberry notes. A must-try for sour beer enthusiasts!', 4, 213);

INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Sculpin Fan', 'Sculpin IPA has always been my favorite. Its the perfect blend of citrus and hops!', 5, 214);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Refreshing Wheat Beer', 'Sour Wench is a delightful wheat beer with a touch of sea salt. Perfect for summer!', 4, 215);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Fruity and Light', 'Mango Even Keel is my go-to session IPA. Its light and fruity with hints of guava and passion fruit.', 4, 216);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Coffee Lovers Dream', 'Victory at Sea is a dream come true for coffee lovers. Rich and smooth with strong coffee and chocolate flavors.', 5, 217);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Clean Kölsch', 'Longfin Lager is a clean and crisp Kölsch-style ale. Perfect for those who enjoy a light and refreshing beer.', 4, 218);

INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Hoppy Delight', 'Hercules Double IPA is a hoppy delight with citrus and pine notes. A great choice for IPA lovers!', 4, 219);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Barleywine Lover', 'Old Ruffian is a treat for barleywine lovers. Its rich and aged to perfection with caramel and toffee flavors.', 5, 220);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Farmhouse Refreshment', 'Colette Farmhouse Ale is a refreshing choice with a hint of honey sweetness. Perfect for a summer day.', 4, 221);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Velvety Stout', 'Yeti Imperial Stout is velvety and rich with roasted malt character. A great choice for stout enthusiasts!', 5, 222);
INSERT INTO reviews (title, description, rating, beer_id) VALUES ('Aromatic Pale Ale', 'Heyday Modern IPA has a wonderful aroma and a balanced profile. Great for those who enjoy pale ales!', 4, 223);

--create constraints
ALTER TABLE [beers] WITH CHECK ADD CONSTRAINT [FK_brewery_beer]
FOREIGN KEY (brewery_id) REFERENCES [breweries] (brewery_id),
FOREIGN KEY (beer_id) REFERENCES [beers] (beer_id)

ALTER TABLE [user_brewery] WITH CHECK ADD CONSTRAINT [FK_user_brewery_user]
FOREIGN KEY(user_id) REFERENCES [users] (user_id)

ALTER TABLE [user_brewery] CHECK CONSTRAINT [FK_user_brewery_user]

ALTER TABLE [user_brewery] WITH CHECK ADD CONSTRAINT [FK_user_brewery_brewery]
FOREIGN KEY(brewery_id) REFERENCES [breweries] (brewery_id)

ALTER TABLE [user_brewery] CHECK CONSTRAINT [FK_user_brewery_brewery]