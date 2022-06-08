import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceblogService } from '../blog/blog-service.service';
import { IRegularUser } from '../models/entities/regular-user';
import { AccountService } from '../services/account-service';
import { ReservationsService } from '../services/reservations-service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {
  loggedUser!: Observable<IRegularUser>;

  constructor(
    private _accountService: AccountService,
    private reservationsService: ReservationsService
  ) {
    // this.service.showEdit=false;
    const userId = this._accountService.loggedUser.id;
    this.loggedUser = this._accountService.getRegularUser(userId);
  }

  ngOnInit(): void {}
}
