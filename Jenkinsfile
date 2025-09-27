pipeline {
    agent any
    environment {
        PATH = "/usr/bin:${env.PATH}"
        COMPOSE_PROJECT_DIR = "${WORKSPACE}/EmpWebAPI"
    }
    stages {
        stage('Build & Deploy') {
            steps {
                script {
                    sh '/usr/bin/docker-compose -f ${COMPOSE_PROJECT_DIR}/docker-compose.yml down || true'
                    sh '/usr/bin/docker-compose -f ${COMPOSE_PROJECT_DIR}/docker-compose.yml up -d --build'
                }
            }
        }
    }
}
