import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { PlanetExplorationsComponent } from './pages/planet-explorations/planet-explorations.component';
import { ViewEditPlanetExplorationDialogComponent } from './components/view-edit-planet-exploration-dialog/view-edit-planet-exploration-dialog.component';
import { MatDialogClose } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [
    PlanetExplorationsComponent,
    ViewEditPlanetExplorationDialogComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatDialogClose,
    FlexLayoutModule,
    MatFormFieldModule,
    MatSelectModule,
    FormsModule,
    MatInputModule,
    SharedModule
  ],
})
export class PlanetExplorationModule { }