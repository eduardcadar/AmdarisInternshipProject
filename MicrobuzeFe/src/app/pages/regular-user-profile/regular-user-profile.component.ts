import { Component, OnInit } from '@angular/core';
import { IRegularUser } from '../../models/regular-user';

@Component({
  selector: 'app-regular-user-profile',
  templateUrl: './regular-user-profile.component.html',
  styleUrls: ['./regular-user-profile.component.css']
})
export class RegularUserProfileComponent implements OnInit {
  pageTitle: string = 'Regular user profile';
  loggedUser: IRegularUser = {
    regularUserId: 1,
    username: 'edicadar', 
    firstname: 'eduard',
    lastname: 'cadar'
  }
  constructor() { }

  ngOnInit(): void {
  }

}
