import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { IAgencyRegister } from 'src/app/apps/models/account/registerAgency';

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
  @Output() LoginClicked: EventEmitter<IAgencyRegister> = new EventEmitter();

  constructor() { }

  ngOnInit(): void { }

  register(): void {

  }
}
