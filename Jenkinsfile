pipeline {
    agent any
    environment {
        PATH = "/usr/bin:${env.PATH}"
    }
    stages {
        stage('Build & Deploy') {
            steps {
               sh '/usr/bin/docker-compose down || true'
               sh '/usr/bin/docker-compose up -d --build'
            }
        }
    }
}
