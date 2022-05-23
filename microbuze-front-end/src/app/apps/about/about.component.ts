import { Component, OnInit } from '@angular/core';
import { ServiceblogService } from '../blog/blog-service.service';
import { FullComponent } from '../layout/full/full.component';
import { IRegularUser } from '../models/entities/regular-user';
import { ReservationsService } from '../services/reservations-service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {
  loggedUser!: IRegularUser;

  constructor(
    public _parent: FullComponent,
    public service: ReservationsService
  ) {
    // this.service.showEdit=false;
  }

  ngOnInit(): void {
    this.loggedUser = this._parent.loggedUser;
  }
}
