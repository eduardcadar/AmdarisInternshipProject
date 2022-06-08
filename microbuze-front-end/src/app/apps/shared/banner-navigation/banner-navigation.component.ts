import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from '../../services/account-service';

@Component({
  selector: 'app-banner-navigation',
  templateUrl: './banner-navigation.component.html',
  styleUrls: ['./banner-navigation.component.css']
})
export class BannerNavigationComponent implements OnInit {
  isLoggedIn!: Observable<boolean>;

  constructor(private accountService: AccountService) {
    this.isLoggedIn = accountService.isLoggedIn;
  }

  ngOnInit(): void { }

  logout(): void {
    localStorage.removeItem('user');
    this.accountService.logout();
  }
}
