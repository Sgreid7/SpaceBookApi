docker build -t spacebookapi-image .
docker tag spacebookapi-image registry.heroku.com/spacebookapi/web
docker push registry.heroku.com/spacebookapi/web
heroku container:release web -a spacebookapi