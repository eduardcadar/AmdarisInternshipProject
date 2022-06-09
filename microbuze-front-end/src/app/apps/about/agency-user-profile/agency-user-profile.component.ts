import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IAgencyUser } from '../../models/entities/agency-user';
import { AccountService } from '../../services/account-service';

@Component({
  selector: 'app-agency-user-profile',
  templateUrl: './agency-user-profile.component.html',
  styleUrls: ['./agency-user-profile.component.css']
})
export class AgencyUserProfileComponent implements OnInit {
  loggedAgencyUser!: Observable<IAgencyUser>;

  constructor(private _accountService: AccountService) {
    const userId: string = this._accountService.loggedUser.id;
    this.loggedAgencyUser = this._accountService.getAgencyUser(userId);
  }

  ngOnInit(): void {}
}
