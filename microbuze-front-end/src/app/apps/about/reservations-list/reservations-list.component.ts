import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IReservation } from '../../models/reservation';
import { ReservationsService } from '../../services/reservations-service';
import { AboutComponent } from '../about.component';

@Component({
  selector: 'app-reservations-list',
  templateUrl: './reservations-list.component.html',
  styleUrls: ['./reservations-list.component.css']
})
export class ReservationsListComponent implements OnInit {
  reservations!: Observable<IReservation[]>;

  constructor(private _parent: AboutComponent, private reservationService: ReservationsService) { }

  ngOnInit(): void {
    this.reservations = this.reloadReservations();
  }

  reloadReservations(): Observable<any> {
    return this.reservationService.getReservationsForRegularUser(this._parent.loggedUser.regularUserId);
  }

  deleteReservation(tripId: number) {
    
  }
}
