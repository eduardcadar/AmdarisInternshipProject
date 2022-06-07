import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account-service';

@Component({
  selector: 'app-banner-navigation',
  templateUrl: './banner-navigation.component.html',
  styleUrls: ['./banner-navigation.component.css']
})
export class BannerNavigationComponent implements OnInit {
  isLogged: boolean = false;

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.accountService.currentUser
      .subscribe(x => {
        this.isLogged = x != null;
      })
  }

  logout(): void {
    localStorage.removeItem('user');
  }
}
