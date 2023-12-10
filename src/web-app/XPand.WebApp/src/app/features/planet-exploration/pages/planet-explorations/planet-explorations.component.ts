import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { MatDialog } from '@angular/material/dialog';
import { ViewEditPlanetExplorationDialogComponent } from '../../components/view-edit-planet-exploration-dialog/view-edit-planet-exploration-dialog.component';
import { PlanetExplorationsService } from '../../../../core/services/planet-explorations/planet-explorations.service';

@Component({
  selector: 'planet-explorations',
  templateUrl: './planet-explorations.component.html',
  styleUrl: './planet-explorations.component.css'
})
export class PlanetExplorationsComponent implements OnInit {
  planetExplorations: any[] = [];
  cardsPerRow: number = 1;
  selectedCard: any;

  constructor(private planetExplorationsService: PlanetExplorationsService, private breakpointObserver: BreakpointObserver, private dialog: MatDialog) { }

  ngOnInit() {
    this.breakpointObserver.observe([Breakpoints.XSmall, Breakpoints.Small, Breakpoints.Medium, Breakpoints.Large, Breakpoints.XLarge ])
      .subscribe(() => {
        this.setCardsPerRow();
      });

    this.planetExplorationsService.planetExplorations.subscribe((data) => {
      this.planetExplorations = data.planetExplorations;
    });
  }
  setCardsPerRow() {
    if (this.breakpointObserver.isMatched(Breakpoints.XSmall)) {
      this.cardsPerRow = 1;
    } else if (this.breakpointObserver.isMatched(Breakpoints.Small)) {
      this.cardsPerRow = 2;
    } else if (this.breakpointObserver.isMatched(Breakpoints.Medium)) {
      this.cardsPerRow = 3;
    } else if (this.breakpointObserver.isMatched(Breakpoints.Large)) {
      this.cardsPerRow = 4;
    } else {
      this.cardsPerRow = 5;
    }
  }
  getFlexBasis(): string {
    return `calc(${100 / this.cardsPerRow}% - 2rem)`;
  }
  getPlanetImageSrc(planetImage: string) {
    return `data:image/jpeg;base64,${planetImage}`;
  }
  getPlanetExplorationStatusLabel(statusId: number) {
    switch (statusId) {
      case 1:
        return 'Ok';
      case 2:
        return '!Ok';
      case 3:
        return 'To Do';
      case 4:
        return 'En Route';
      default:
        return 'Unknown';
    }
  }
  getStatusStyleClass(statusId: number): string {
    switch (statusId) {
      case 1:
        return 'status-ok';
      case 2:
        return 'status-not-ok';
      case 3:
        return 'status-todo';
      case 4:
        return 'status-en-route';
      default:
        return '';
    }
  }
  getRobots(robots: any[]) {
    return `${robots.slice(0, 3).map(robot => 'T' + robot.userId).join(', ')}${robots.length > 3 ? ' ..' : ''}`;
  }
  onCardClick(exploration: any): void {
    this.selectedCard = exploration;
    const viewEditPlanetExplorationDialog = this.dialog.open(ViewEditPlanetExplorationDialogComponent, {
      data: JSON.parse(JSON.stringify(exploration)),
    });

    viewEditPlanetExplorationDialog.afterClosed().subscribe(() => {
      this.selectedCard = null;
    });
  }
}
