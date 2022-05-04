import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginRegularComponent } from './login-regular.component';

describe('LoginRegularComponent', () => {
  let component: LoginRegularComponent;
  let fixture: ComponentFixture<LoginRegularComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginRegularComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginRegularComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
