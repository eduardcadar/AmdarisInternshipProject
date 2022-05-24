import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FullComponent } from '../../../layout/full/full.component';
import { IReservation } from '../../../models/entities/reservation';
import { ReservationsService } from '../../../services/reservations-service';

@Component({
  selector: 'app-reservations-list',
  templateUrl: './reservations-list.component.html',
  styleUrls: ['./reservations-list.component.css']
})
export class ReservationsListComponent implements OnInit {
  reservations!: Observable<IReservation[]>;

  constructor(
    private _parent: FullComponent,
    private reservationService: ReservationsService
  ) { }

  ngOnInit(): void {
    this.reloadReservations();
  }

  reloadReservations(): void {
    this.reservations = this.reservationService
      .getReservationsForRegularUser(this._parent.loggedUser.regularUserId);
  }

  deleteReservation(tripId: number): void {
    this.reservationService
      .deleteReservation(tripId, this._parent.loggedUser.regularUserId)
      .subscribe(() => this.reloadReservations());
  }

  updateReservation(seatsNumber: number, tripId: number): void {
    this.reservationService
      .updateReservation(tripId, this._parent.loggedUser.regularUserId, seatsNumber)
      .subscribe(
        data => {
          this.reloadReservations();
          alert("Rezervarea a fost actualizata");
        },
        error => alert(error.error)
      );
  }
}
