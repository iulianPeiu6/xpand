import { Injectable } from '@angular/core';
import { PlanetExplorationsHttpClient } from '../../http-clients/planet-explorations-management-client/planet-explorations-management.http-client';
import { PlanetExplorations } from '../../models/planet-explorations.model';
import { Observable, catchError, of, tap, throwError } from 'rxjs';
import { PatchDocument } from '../../models/patch-document.model';

@Injectable({
  providedIn: 'root'
})
export class PlanetExplorationsService {
  storedPlanetExplorations: PlanetExplorations|null = null;

  constructor(private readonly planetExplorationManagementHttpClient: PlanetExplorationsHttpClient) {}

  get planetExplorations(): Observable<PlanetExplorations> {
    if (this.storedPlanetExplorations === null) {
      return this.planetExplorationManagementHttpClient.getPlanetExplorations().pipe(
        tap((data) => {
          this.storedPlanetExplorations = data;
        })
      );
    }

    return of(this.storedPlanetExplorations);
  }

  patchPlanetExploration(planetExplorationId: number, patchDoc: PatchDocument) : Observable<any> {
    return this.planetExplorationManagementHttpClient.patchPlanetExploration(planetExplorationId, patchDoc).pipe(
      tap((data) => {
        let updatedPlanetExplorationIndex = this.storedPlanetExplorations?.planetExplorations.findIndex((planetExploration) => planetExploration.planetExplorationId === planetExplorationId);
        let updatedPlanetExploration = this.storedPlanetExplorations?.planetExplorations[updatedPlanetExplorationIndex!];
        updatedPlanetExploration!.planetExplorationStatusId = patchDoc.find((patch) => patch.path === '/planetExplorationStatusId')!.value;
        updatedPlanetExploration!.observations = patchDoc.find((patch) => patch.path === '/observations')!.value;
        return data;
      }),
      catchError((error) => {
        return throwError(() => error.error);
      })
    );
  }
}
