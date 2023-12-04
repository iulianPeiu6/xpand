import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanetExplorationsComponent } from './planet-explorations.component';

describe('PlanetExplorationsComponent', () => {
  let component: PlanetExplorationsComponent;
  let fixture: ComponentFixture<PlanetExplorationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlanetExplorationsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlanetExplorationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
