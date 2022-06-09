import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceblogService } from '../blog/blog-service.service';
import { IAgencyUser } from '../models/entities/agency-user';
import { IRegularUser } from '../models/entities/regular-user';
import { AccountService } from '../services/account-service';
import { ReservationsService } from '../services/reservations-service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {
  loggedRegularUser!: Observable<IRegularUser>;
  loggedAgencyUser!: Observable<IAgencyUser>;

  constructor(
    private _accountService: AccountService,
    private _reservationsService: ReservationsService
  ) {
    // this.service.showEdit=false;
    const userId: string = this._accountService.loggedUser.id;
    const isAgency: boolean = this._accountService.loggedUser.isAgency;
    if (isAgency)
      this.loggedAgencyUser = this._accountService.getAgencyUser(userId);
    else
      this.loggedRegularUser = this._accountService.getRegularUser(userId);
  }

  ngOnInit(): void {}
}
