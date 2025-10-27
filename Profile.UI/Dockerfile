# ---- Build Angular app ----
FROM node:20 AS build
WORKDIR /app

# Copy package files and install dependencies
COPY package*.json ./
RUN npm ci

# Copy the rest of the source code and build for production
COPY . .
RUN npm run build -- --configuration production

# ---- Run with Nginx ----
FROM nginx:alpine AS final
# Copy built files from the Angular dist folder
COPY --from=build /app/dist/profile.ui/browser/ /usr/share/nginx/html/

# Replace default nginx config with our own
COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
