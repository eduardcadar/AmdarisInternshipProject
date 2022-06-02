import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterAgencyuserFormComponent } from './register-agencyuser-form.component';

describe('RegisterAgencyuserFormComponent', () => {
  let component: RegisterAgencyuserFormComponent;
  let fixture: ComponentFixture<RegisterAgencyuserFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterAgencyuserFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterAgencyuserFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
