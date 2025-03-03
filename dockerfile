FROM openjdk:11-jre-slim
WORKDIR /app
COPY base-service/target/ktx-service.jar app.jar
EXPOSE 8080
ENTRYPOINT ["java", "-jar", "app.jar"]