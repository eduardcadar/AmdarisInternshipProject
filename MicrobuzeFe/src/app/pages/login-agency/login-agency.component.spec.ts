import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginAgencyComponent } from './login-agency.component';

describe('LoginAgencyComponent', () => {
  let component: LoginAgencyComponent;
  let fixture: ComponentFixture<LoginAgencyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginAgencyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginAgencyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
