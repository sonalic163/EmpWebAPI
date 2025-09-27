pipeline {
    agent any

    environment {
        DOCKER_COMPOSE_FILE = 'docker-compose.yml'
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/Sonali163/EmpWebAPI.git'
            }
        }

        stage('Build & Deploy') {
            steps {
                script {
                    // Stop running containers safely
                    sh 'docker-compose down || true'

                    // Build & run all services again
                    sh 'docker-compose up -d --build'
                }
            }
        }
    }

    post {
        success {
            echo '✅ Deployment successful!'
        }
        failure {
            echo '❌ Deployment failed. Check logs.'
        }
    }
}
