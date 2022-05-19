import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogChooseSeatsNumberComponent } from './dialog-choose-seats-number.component';

describe('DialogChooseSeatsNumberComponent', () => {
  let component: DialogChooseSeatsNumberComponent;
  let fixture: ComponentFixture<DialogChooseSeatsNumberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogChooseSeatsNumberComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogChooseSeatsNumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
