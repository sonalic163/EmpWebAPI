pipeline {
    agent any
    environment {
        COMPOSE_PROJECT_DIR = "${WORKSPACE}/EmpWebAPI"  // Path to docker-compose.yml
    }
    stages {
        stage('Build & Deploy') {
            steps {
                dir('EmpWebAPI') {
                    script {
                        sh 'docker compose down || true'
                        sh 'docker compose up -d --build'
                    }
                }
            }
        }
    }
}
