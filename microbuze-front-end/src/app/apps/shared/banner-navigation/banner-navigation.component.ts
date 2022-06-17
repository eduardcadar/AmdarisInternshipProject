import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ILoginResponse } from '../../models/account/loginResponse';
import { AccountService } from '../../services/account-service';

@Component({
  selector: 'app-banner-navigation',
  templateUrl: './banner-navigation.component.html',
  styleUrls: ['./banner-navigation.component.css']
})
export class BannerNavigationComponent implements OnInit {
  isLoggedIn!: Observable<boolean>;
  loginResponse!: ILoginResponse;

  constructor(private _accountService: AccountService) {
    this.isLoggedIn = _accountService.isLoggedInObs;
    this.isLoggedIn.subscribe(b => {
      if (b)
        this.loginResponse = _accountService.loggedUser;
    });
  }

  ngOnInit(): void { }

  logout(): void {
    localStorage.removeItem('user');
    this._accountService.logout();
  }
}
