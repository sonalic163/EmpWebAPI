pipeline {
    agent any

    environment {
        PATH = "/usr/bin:${env.PATH}"        // Ensure docker-compose is in PATH
        COMPOSE_PROJECT_DIR = "${WORKSPACE}/EmpWebAPI"  // Path where docker-compose.yml is located
    }

    stages {
        stage('Checkout') {
            steps {
                // Checkout the repo properly
                git branch: 'main', 
                    url: 'https://github.com/sonalic163/EmpWebAPI.git', 
                    credentialsId: 'github-pat'
            }
        }

        stage('Build & Deploy') {
            steps {
                dir('EmpWebAPI') {  // Change directory to where docker-compose.yml is
                    script {
                        sh 'docker compose down || true'
                        sh 'docker compose up -d --build'
                    }
                }
            }
        }
    }
}
