pipeline {
    agent any
    environment {
        // Ensures docker-compose is in PATH
        PATH = "/usr/bin:${env.PATH}"
        // Optional: specify project directory if your docker-compose.yml is not in the root
        COMPOSE_PROJECT_DIR = "${WORKSPACE}"
    }
    stages {
        stage('Build & Deploy') {
            steps {
                script {
                    // Stop existing containers if any
                    sh 'docker-compose -f ${COMPOSE_PROJECT_DIR}/docker-compose.yml down || true'
                    
                    // Build and start containers
                    sh 'docker-compose -f ${COMPOSE_PROJECT_DIR}/docker-compose.yml up -d --build'
                }
            }
        }
    }
}
