import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/apps/services/account-service';
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
    private _accountService: AccountService,
    private _reservationService: ReservationsService
  ) { }

  ngOnInit(): void {
    this.reloadReservations();
  }

  reloadReservations(): void {
    this.reservations = this._reservationService
      .getReservationsForRegularUser(this._accountService.loggedUser.id);
  }

  deleteReservation(tripId: number): void {
    this._reservationService
      .deleteReservation(tripId, this._accountService.loggedUser.id)
      .subscribe(() => this.reloadReservations());
  }

  updateReservation(seatsNumber: number, tripId: number): void {
    this._reservationService
      .updateReservation(tripId, this._accountService.loggedUser.id, seatsNumber)
      .subscribe(
        data => {
          this.reloadReservations();
          alert("Rezervarea a fost actualizata");
        },
        error => alert(error.error)
      );
  }
}
