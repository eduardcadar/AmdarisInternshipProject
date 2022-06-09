import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account-service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {
  isAgency!: boolean;

  constructor(private _accountService: AccountService) {
    this.isAgency = this._accountService.loggedUser.isAgency;
  }

  ngOnInit(): void {}
}
