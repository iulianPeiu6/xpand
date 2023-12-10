export interface PlanetExplorations {
  planetExplorations: PlanetExploration[]
}

export interface PlanetExploration {
  planetExplorationId: number;
  planetId: number;
  planetImage?: Uint8Array | null;
  planetName: string;
  observations: string;
  planetExplorationStatusId: PlanetExplorationStatus;
  captain: User;
  robots: User[];
}

export enum PlanetExplorationStatus {
  Ok = 1,
  NotOk = 2,
  ToDo = 3,
  EnRoute = 4
}

export interface User {
  userId: number;
  fullName: string;
}
  