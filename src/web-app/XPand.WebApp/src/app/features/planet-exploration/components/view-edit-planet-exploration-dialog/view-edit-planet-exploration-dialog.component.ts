import { Component, Inject } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
} from '@angular/material/dialog';
import { PlanetExploration } from '../../../../core/models/planet-explorations.model';
import { PlanetExplorationStatus } from '../../../../core/models/planet-explorations.model';
import { PlanetExplorationsService } from '../../../../core/services/planet-explorations/planet-explorations.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'view-edit-planet-exploration-dialog',
  templateUrl: './view-edit-planet-exploration-dialog.component.html',
  styleUrl: './view-edit-planet-exploration-dialog.component.css'
})
export class ViewEditPlanetExplorationDialogComponent {
  statuses: any[] = [
    { id: PlanetExplorationStatus.Ok, label: 'Ok' },
    { id: PlanetExplorationStatus.NotOk, label: '!Ok' },
    { id: PlanetExplorationStatus.ToDo, label: 'To Do' },
    { id: PlanetExplorationStatus.EnRoute, label: 'En Route' },
  ];
  
  constructor(public dialogRef: MatDialogRef<ViewEditPlanetExplorationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: PlanetExploration, 
    private readonly planetExplorationsService: PlanetExplorationsService,
    private snackBar: MatSnackBar) {
    
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }
  onSaveClick(): void {
    let pathchDoc = [
      {
        op: 'replace',
        path: '/planetExplorationStatusId',
        value: this.data.planetExplorationStatusId
      },
      {
        op: 'replace',
        path: '/observations',
        value: this.data.observations
      }
    ];
    this.planetExplorationsService.patchPlanetExploration(this.data.planetExplorationId, pathchDoc).subscribe({
      next: (data) => {
        this.snackBar.open('Planet exploration updated successfully!', 'Close', {
          panelClass: ['success-snackbar']
        });
      },
      error: (error) => {
        this.snackBar.open('Failed to update planet exploration. Please try again.', 'Close', {
          panelClass: ['error-snackbar']
        });
  
        console.error(error);
      }
    });
    this.dialogRef.close(this.data);
  }
}
