import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PlanetExplorations } from '../../models/planet-explorations.model';
import apiConfig from '../api.config.json';
import { Observable, switchMap } from 'rxjs';
import { PatchDocument } from '../../models/patch-document.model';
import { AuthService } from '@auth0/auth0-angular';
import auth0Config from '../../auth/auth0.config.json';

@Injectable({ 
  providedIn: 'root' 
})
export class PlanetExplorationsHttpClient {
  constructor(private readonly http: HttpClient, private readonly authService: AuthService) {}

  getPlanetExplorations() : Observable<PlanetExplorations> {
    return this.http.get<PlanetExplorations>(`${apiConfig.planetExplorationManagementApi.baseUrl}/planet-explorations`);
  }

  patchPlanetExploration(planetExplorationId: number, patchDoc: PatchDocument) {
    return this.authService.getAccessTokenSilently()
      .pipe(
        switchMap(token => {
          const headers = new HttpHeaders({
            Authorization: `Bearer ${token}`,
          });

          return this.http.patch(
            `${apiConfig.planetExplorationManagementApi.baseUrl}/planet-explorations/${planetExplorationId}`,
            patchDoc,
            { headers }
          );
        })
      );
  }
}
