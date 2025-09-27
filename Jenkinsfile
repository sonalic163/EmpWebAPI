pipeline {
    agent any

    environment {
        DOCKER_COMPOSE_FILE = 'docker-compose.yml' // update path if needed
    }

    stages {
        stage('Checkout') {
            steps {
                // Clone the public repo without credentials
                git branch: 'main', url: 'https://github.com/Sonali163/EmpWebAPI.git'
            }
        }

        stage('Build & Deploy') {
            steps {
                script {
                    // Ensure docker access
                    sh "docker version"

                    // Stop any running containers safely
                    sh "docker-compose -f ${DOCKER_COMPOSE_FILE} down || true"

                    // Build & run services
                    sh "docker-compose -f ${DOCKER_COMPOSE_FILE} up -d --build"
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

