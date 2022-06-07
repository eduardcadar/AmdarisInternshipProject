import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { IRegisterData } from 'src/app/apps/models/account/registerData';

@Component({
  selector: 'app-register-agencyuser-form',
  templateUrl: './register-agencyuser-form.component.html',
  styleUrls: ['./register-agencyuser-form.component.css']
})
export class RegisterAgencyuserFormComponent implements OnInit {
  registerForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
    agency: new FormControl(''),
    phonenumber: new FormControl('')
  });
  @Output() RegisterClicked: EventEmitter<IRegisterData> = new EventEmitter();

  constructor() { }

  ngOnInit(): void { }

  register(): void {
    let registerData: IRegisterData = {
      username: this.registerForm.value.username,
      password: this.registerForm.value.password,
      isAgency: true,
      agency: this.registerForm.value.agency,
      phonenumber: this.registerForm.value.phonenumber
    };
    this.RegisterClicked.emit(registerData);
  }
}
