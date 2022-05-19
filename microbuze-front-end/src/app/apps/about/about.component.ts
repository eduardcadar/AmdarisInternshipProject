import { Component } from '@angular/core';
import { ServiceblogService } from '../blog/blog-service.service';
import { IRegularUser } from '../models/regular-user'
import { ReservationsService } from '../services/reservations-service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent {
  loggedUser: IRegularUser = {
    regularUserId: 1,
    username: 'my username',
    firstname: 'firstname',
    lastname: 'lastname'
  };

  constructor(public service: ReservationsService) {
    // this.service.showEdit=false;
  }

}
