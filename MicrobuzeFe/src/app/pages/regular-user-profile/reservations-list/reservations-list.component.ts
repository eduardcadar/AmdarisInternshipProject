import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IReservation } from 'src/app/models/reservation';
import { ReservationsService } from 'src/app/services/reservations-service';
import { RegularUserProfileComponent } from '../regular-user-profile.component';

@Component({
  selector: 'app-reservations-list',
  templateUrl: './reservations-list.component.html',
  styleUrls: ['./reservations-list.component.css']
})
export class ReservationsListComponent implements OnInit {
  reservations!: Observable<IReservation[]>;

  columnsToDisplay: string[] = [
    'trip',
    'regularUser'
  ];

  constructor(private _parent: RegularUserProfileComponent, private reservationService: ReservationsService) { }

  ngOnInit(): void {
    this.reservations = this.reservationService.getReservationsForRegularUser(this._parent.loggedUser.regularUserId);
  }

}
