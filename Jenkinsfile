pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                git(
                    branch: 'main',
                    url: 'https://github.com/Sonalic163/EmpWebAPI.git',
                    credentialsId: 'github-pat'
                )
            }
        }
        stage('Build & Deploy') {
            steps {
                sh 'docker-compose down || true'
                sh 'docker-compose up -d --build'
            }
        }
    }
}
