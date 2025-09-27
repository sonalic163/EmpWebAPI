pipeline {
    agent any
    environment {
        // Ensures docker-compose is in PATH
        PATH = "/usr/local/bin:/usr/bin:${env.PATH}"
        // Optional: specify project directory if your docker-compose.yml is not in the root
        COMPOSE_PROJECT_DIR = "${WORKSPACE}/EmpWebAPI"
    }
    stages {
        stage('Build & Deploy') {
            steps {
                script {
                   sh 'docker-compose -f ${COMPOSE_PROJECT_DIR}/docker-compose.yml down || true'
                   sh 'docker-compose -f ${COMPOSE_PROJECT_DIR}/docker-compose.yml up -d --build'
                }
            }
        }
    }
}
