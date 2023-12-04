import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlanetExplorationsRoutingModule } from './planet-explorations-routing.module';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { PlanetExplorationsComponent } from './planet-explorations.component';
import { MatToolbarModule } from '@angular/material/toolbar';


@NgModule({
  declarations: [
    PlanetExplorationsComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    FlexLayoutModule,
    MatToolbarModule,
    PlanetExplorationsRoutingModule,
  ],
})
export class PlanetExplorationsModule { }