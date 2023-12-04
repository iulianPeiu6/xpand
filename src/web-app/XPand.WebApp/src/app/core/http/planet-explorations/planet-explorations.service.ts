import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PlanetExplorations } from '../../models/planet-explorations.model';
import apiConfig from './../api.config.json';

@Injectable()
export class PlanetExplorationsService {
  constructor(private readonly http: HttpClient) {}

  getPlanetExplorations() {
    return this.http.get<PlanetExplorations>(`${apiConfig.baseUrl}/planet-explorations`);
  }
}
