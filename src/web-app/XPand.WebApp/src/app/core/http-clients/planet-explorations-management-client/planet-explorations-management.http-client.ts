import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PlanetExplorations } from '../../models/planet-explorations.model';
import apiConfig from '../api.config.json';
import { Observable } from 'rxjs';
import { PatchDocument } from '../../models/patch-document.model';

@Injectable({ 
  providedIn: 'root' 
})
export class PlanetExplorationsHttpClient {
  constructor(private readonly http: HttpClient) {}

  getPlanetExplorations() : Observable<PlanetExplorations> {
    return this.http.get<PlanetExplorations>(`${apiConfig.planetExplorationManagementApi.baseUrl}/planet-explorations`);
  }

  patchPlanetExploration(planetExplorationId: number, pathchDoc: PatchDocument) {
    return this.http.patch(`${apiConfig.planetExplorationManagementApi.baseUrl}/planet-explorations/${planetExplorationId}`, pathchDoc);
  }
}
