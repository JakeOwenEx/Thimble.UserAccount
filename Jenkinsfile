#!groovy

pipeline {
    agent {
        label 'dotnet'
  }
    stages {
        stage('Build') {
            steps {
                sh "bash ./tools/jenkins/add-secrets.sh"
                sh "docker build  -t useraccount ./src/Thimble.UserAccount/"
                sh "docker tag useraccount:latest 700802665432.dkr.ecr.eu-west-1.amazonaws.com/thimble-useraccount:latest"
            }
        }
        stage('Push to ECR'){
            steps{
                script { 
                    docker.withRegistry("https://700802665432.dkr.ecr.eu-west-1.amazonaws.com", "ecr:eu-west-1:thimbleaws") {
                    docker.image("700802665432.dkr.ecr.eu-west-1.amazonaws.com/thimble-useraccount:latest").push()}
                } 
            }
        }
        stage('Deploy to ECS'){
            steps{
                sh "aws ecs update-service --region eu-west-1 --cluster useraccount-cluster --service useraccount-service --force-new-deployment" 
            }
        }
    }
}