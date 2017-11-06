# Create image based on the official nginx image from dockerhub
FROM nginx

# Change directory so that our commands run inside this new directory
WORKDIR /usr/share/nginx/html

# Copy dependency definitions
COPY package.json /usr/share/nginx/html

# Install dependecies and build (Already done?)
RUN apt-get update && \
	apt-get -y install build-essential curl && \
	curl -sL https://deb.nodesource.com/setup_8.x | bash - && \
	apt-get install -y nodejs
RUN npm install

COPY ./nginx.conf /etc/nginx/nginx.conf

# Get all the code needed to run the app
COPY ./App.Web/dist .