# xpand

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=iulianPeiu6_xpand&metric=coverage)](https://sonarcloud.io/summary/new_code?id=iulianPeiu6_xpand) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=iulianPeiu6_xpand&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=iulianPeiu6_xpand) [![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=iulianPeiu6_xpand&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=iulianPeiu6_xpand)

## Requirements
[See requirements](https://github.com/iulianPeiu6/xpand/blob/master/docs/requirements.pdf)

### DONE:
- Init Repo. Init Solution.
- Configure CI. Add Quality Check github workflow action (Build, Test, SonarCloud Analysis).
- [DB Modeling](https://github.com/iulianPeiu6/xpand/blob/master/docs/db-diagram.png). [dbdiagram.io](https://dbdiagram.io/d/6568b9433be149578711d7fe)

### TODO: 
- Create PlanetExplorationManagement API:
  - GET /v1/planet-explorations
  - GET /v1/planet-explorations/{planetExplorationId}
  - POST /v1/planet-explorations
  - PATCH /v1/planet-explorations/{planetExplorationId}
  - Add Authorization
  - Add Unit/Integration Tests
- Create SPA UI:
  - Add auth0
  - List Planet Explorations
  - Create Planet Exploration
  - Update Planet Exploration
  - Progresive & Paralel Loading
