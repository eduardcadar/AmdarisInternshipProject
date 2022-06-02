import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { IRegularRegister } from 'src/app/apps/models/account/registerRegular';

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
  @Output() LoginClicked: EventEmitter<IRegularRegister> = new EventEmitter();

  constructor() { }

  ngOnInit(): void { }

  register(): void {

  }
}
