# Create image based on the official nginx image from dockerhub
FROM nginx

# Change directory so that our commands run inside this new directory
WORKDIR /usr/share/nginx/html

COPY ./nginx.conf /etc/nginx/conf.d/default.conf

# Get all the code needed to run the app
ADD ./dist .