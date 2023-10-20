if "%1" == "Development" goto development
if "%1" == "Staging" goto staging
if "%1" == "Production" goto production
:development
PaaApi-Development.deploy.cmd /y /m:https://PAASERVER:8172/MSDeploy.axd "/u:Administrator" "/p:12345678x@X" /a:basic "-AllowUntrusted=True"
goto :EOF
:staging
PaaApi-Staging.deploy.cmd /y /m:https://PAASERVER:8172/MSDeploy.axd "/u:Administrator" "/p:12345678x@X" /a:basic "-AllowUntrusted=True"
goto :EOF
:production
PaaApi-Production.deploy.cmd /y /m:https://localhost:8172/MSDeploy.axd "/u:WDeployAdmin" "/p:12345678@X" /a:basic "-AllowUntrusted=True"
goto :EOF

