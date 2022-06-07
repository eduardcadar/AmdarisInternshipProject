import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { ILoginData } from 'src/app/apps/models/account/loginData';
import { ILoginResponse } from 'src/app/apps/models/account/loginResponse';
import { AccountService } from 'src/app/apps/services/account-service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  loginForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  });
  @Output() LoginClicked: EventEmitter<ILoginData> = new EventEmitter();

  constructor(private accountService: AccountService) { }

  ngOnInit(): void { }

  login(): void {
    let loginData: ILoginData = {
      username: this.loginForm.value.username,
      password: this.loginForm.value.password
    };
    let response: Observable<ILoginResponse> = this.accountService.login(loginData);
    response.subscribe(
      x => this.setLoggedUser(x),
      error => alert(error.error)
    );
  }

  setLoggedUser(loginResponse: ILoginResponse): void {
    
  }
}
