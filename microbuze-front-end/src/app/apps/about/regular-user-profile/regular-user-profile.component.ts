import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IRegularUser } from '../../models/entities/regular-user';
import { AccountService } from '../../services/account-service';

@Component({
  selector: 'app-regular-user-profile',
  templateUrl: './regular-user-profile.component.html',
  styleUrls: ['./regular-user-profile.component.css']
})
export class RegularUserProfileComponent implements OnInit {
  loggedRegularUser!: Observable<IRegularUser>;

  constructor(private _accountService: AccountService) {
    const userId: string = this._accountService.loggedUser.id;
    this.loggedRegularUser = this._accountService.getRegularUser(userId);
  }

  ngOnInit(): void {}

}
