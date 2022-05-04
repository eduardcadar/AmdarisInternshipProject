import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegularUserProfileComponent } from './regular-user-profile.component';

describe('RegularUserProfileComponent', () => {
  let component: RegularUserProfileComponent;
  let fixture: ComponentFixture<RegularUserProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegularUserProfileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegularUserProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
