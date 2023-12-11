# xpand

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=iulianPeiu6_xpand&metric=coverage)](https://sonarcloud.io/summary/new_code?id=iulianPeiu6_xpand) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=iulianPeiu6_xpand&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=iulianPeiu6_xpand) [![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=iulianPeiu6_xpand&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=iulianPeiu6_xpand)

## Requirements
[See requirements](https://github.com/iulianPeiu6/xpand/blob/master/docs/requirements.pdf)

## Keywords

Minimal API .NET, API Guidelines, Async Programing, Error Handling, Clean Architecture, Unit Tests 

Angular, Angular Material

Auth0, Github Actions - CI/CD, SonarCloud, 

### DONE:
- Init Repo. Init Solution.
- Configure CI. Add Quality Check github workflow action (Build, Test, SonarCloud Analysis).
- [DB Modeling](https://github.com/iulianPeiu6/xpand/blob/master/docs/db-diagram.png). [dbdiagram.io](https://dbdiagram.io/d/6568b9433be149578711d7fe)
- Create PlanetExplorationManagement API:
  - Add health check
  - GET /v1/planet-explorations
  - PATCH /v1/planet-explorations/{planetExplorationId}
  - Add Authorization
  - Add Unit/Integration Tests
-  Create SPA UI:
  - Integrate auth0
  - List Planet Explorations
  - Update Planet Exploration

### TODO: 
- Add skeleton loaders on SPA
- Improve Style
- Add Login popup warning when user clicks on planet exploration card and tries to edit when is not logged in
- Disable Save button on planet exploration when user is not logged in or does not have the necesary permissions
- Add Swagger Doc on API
- Add more Unit Tests
- Inovations: Async communication between robots and captain (SignalR, Service Bus, Queues, etc)
