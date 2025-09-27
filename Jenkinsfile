pipeline {
    agent any
    environment {
      checkout([$class: 'GitSCM', 
                    branches: [[name: '*/main']], 
                    userRemoteConfigs: [[url: 'https://github.com/sonalic163/EmpWebAPI.git', credentialsId: 'github-pat']]
                ])
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
