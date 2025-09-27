pipeline {
    agent any
    environment {
        PATH = "/usr/bin:${env.PATH}"
    }
    stages {
        stage('Build & Deploy') {
            steps {
                sh 'docker-compose down || true'
                sh 'docker-compose up -d --build'
            }
        }
    }
}
