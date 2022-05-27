import { Component, OnInit } from '@angular/core';
import { IRegularUser } from '../../models/entities/regular-user';

@Component({
  selector: 'app-full',
  templateUrl: './full.component.html',
  styleUrls: ['./full.component.css']
})
export class FullComponent implements OnInit {
  loggedUser: IRegularUser = {
    regularUserId: 1,
    username: 'edi',
    firstname: 'firstname',
    lastname: 'lastname'
  };
  agencyId: number = 1;

  constructor() { }

  ngOnInit(): void {
  }

}
