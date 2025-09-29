pipeline {
    agent any
    environment {
        COMPOSE_PROJECT_DIR = "${WORKSPACE}/EmpWebAPI"
    }
    stages {
        stage('Build & Deploy') {
            steps {
                dir('EmpWebAPI') {
                    script {
                        // Stop and remove all containers for this compose project
                        sh 'docker compose down --remove-orphans --volumes || true'
                        sh 'docker compose up -d --build'
                    }
                }
            }
        }
    }
}
