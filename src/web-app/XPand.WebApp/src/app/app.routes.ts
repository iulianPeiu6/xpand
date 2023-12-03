import { Routes } from '@angular/router';
import { PlanetExplorationsComponent } from './pages/planet-explorations/planet-explorations.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';

export const routes: Routes = [
    { 
      path: '', 
      component: PlanetExplorationsComponent 
    },
    { 
      path: 'planet-explorations', 
      component: PlanetExplorationsComponent 
    },
    { 
      path: '**', 
      component: PageNotFoundComponent 
    }
  ];
