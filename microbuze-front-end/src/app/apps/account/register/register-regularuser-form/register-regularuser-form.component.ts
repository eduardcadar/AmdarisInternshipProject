import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { IRegisterData } from 'src/app/apps/models/account/registerData';

@Component({
  selector: 'app-register-regularuser-form',
  templateUrl: './register-regularuser-form.component.html',
  styleUrls: ['./register-regularuser-form.component.css']
})
export class RegisterRegularuserFormComponent implements OnInit {
  registerForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
    firstname: new FormControl(''),
    lastname: new FormControl(''),
    phonenumber: new FormControl('')
  });
  @Output() RegisterClicked: EventEmitter<IRegisterData> = new EventEmitter();

  constructor() { }

  ngOnInit(): void { }

  register(): void {
    let registerData: IRegisterData = {
      username: this.registerForm.value.username,
      password: this.registerForm.value.password,
      isAgency: false,
      firstname: this.registerForm.value.firstname,
      lastname: this.registerForm.value.lastname,
      phonenumber: this.registerForm.value.phonenumber
    };
    this.RegisterClicked.emit(registerData);
  }
}