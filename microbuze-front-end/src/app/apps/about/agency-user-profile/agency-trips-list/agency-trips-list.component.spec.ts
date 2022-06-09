import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgencyTripsListComponent } from './agency-trips-list.component';

describe('AgencyTripsListComponent', () => {
  let component: AgencyTripsListComponent;
  let fixture: ComponentFixture<AgencyTripsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgencyTripsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AgencyTripsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
