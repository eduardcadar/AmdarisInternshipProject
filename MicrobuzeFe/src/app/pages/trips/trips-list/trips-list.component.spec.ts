import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatIconModule } from '@angular/material/icon';
import { TripsListComponent } from './trips-list.component';

describe('TripsListComponent', () => {
  let component: TripsListComponent;
  let fixture: ComponentFixture<TripsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TripsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TripsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
