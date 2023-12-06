import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PlanetExplorationsComponent } from './planet-explorations.component';

const routes: Routes = [
  { 
    path: '', 
    component: PlanetExplorationsComponent 
  },
  { 
    path: 'planet-explorations', 
    component: PlanetExplorationsComponent 
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})

export class PlanetExplorationsRoutingModule { }