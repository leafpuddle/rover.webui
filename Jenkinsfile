node (label:'ubuntu-20.04') {
    stage ('Prepare environment') {
        git branch: 'master', credentialsId: '0c9158e7-0eca-4c36-b49d-728fec708a2a', url: 'git.leafpuddle.dev:misc/rover.webui.git'
        sh 'dotnet restore'
    }
    
    stage ('Build') {
        sh 'dotnet publish'
    }
    
    stage ('Prepare Deployment') {
        sh 'ssh rover@web01.leafpuddle.net rm -rf /var/www/rover-webui/dist'
        sh 'ssh rover@web01.leafpuddle.net mkdir -p /var/www/rover-webui/dist'
        sh 'ssh rover@web01.leafpuddle.net chown -R rover:rover /var/www/rover-webui/dist'
    }
    
    stage ('Deploy') {
        sh 'scp -r bin/Debug/net6.0/publish/* rover@web01.leafpuddle.net:/var/www/rover-webui/dist/'

        sh 'ssh rover@web01.leafpuddle.net sudo systemctl restart rover-webui.service'
    }
}
