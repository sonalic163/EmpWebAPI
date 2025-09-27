pipeline {
    agent any
    environment {
        // Add /usr/local/bin to PATH for docker-compose
        PATH = "/usr/local/bin:/usr/bin:${env.PATH}"
        // Set project directory to where docker-compose.yml is
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
