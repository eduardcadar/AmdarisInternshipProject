import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterRegularuserFormComponent } from './register-regularuser-form.component';

describe('RegisterRegularuserFormComponent', () => {
  let component: RegisterRegularuserFormComponent;
  let fixture: ComponentFixture<RegisterRegularuserFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterRegularuserFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterRegularuserFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
