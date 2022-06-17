import { Component, OnInit } from '@angular/core';
import { IRegisterData } from '../../models/account/registerData';
import { AccountService } from '../../services/account-service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerAsAgency: boolean = false;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {}

  switchRegister(): void {
    this.registerAsAgency = !this.registerAsAgency;
  }

  register(registerData: IRegisterData): void {
    this.accountService.register(registerData)
      .subscribe(
        data => alert('The account was created'),
        error => alert(error.error)
      );
  }
}