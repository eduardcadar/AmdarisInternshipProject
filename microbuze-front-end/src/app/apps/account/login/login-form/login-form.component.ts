import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ILoginData } from 'src/app/apps/models/account/loginData';

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

  constructor() { }

  ngOnInit(): void {
  }

  login(): void {
    
  }
}
