import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';
import { PlanetExplorationsComponent } from './features/planet-exploration/pages/planet-explorations/planet-explorations.component';

const routes: Routes = [
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

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
