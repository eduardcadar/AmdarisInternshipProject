import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IRegularUser } from 'src/app/apps/models/entities/regular-user';
import { AccountService } from 'src/app/apps/services/account-service';
import { IReservation } from '../../../models/entities/reservation';
import { ReservationsService } from '../../../services/reservations-service';

@Component({
  selector: 'app-reservations-list',
  templateUrl: './reservations-list.component.html',
  styleUrls: ['./reservations-list.component.css']
})
export class ReservationsListComponent implements OnInit {
  reservations!: Observable<IReservation[]>;
  loggedRegularUser!: IRegularUser;

  constructor(
    private _accountService: AccountService,
    private _reservationService: ReservationsService
  ) {}

  ngOnInit(): void {
    let id: string = this._accountService.loggedUser.id;
    this._accountService.getRegularUser(id)
      .subscribe(u => {
        this.loggedRegularUser = u;
        this.reloadReservations();
      });
  }

  reloadReservations(): void {
    this.reservations = this._reservationService
      .getReservationsForRegularUser(this.loggedRegularUser.id);
  }

  deleteReservation(tripId: number): void {
    this._reservationService
      .deleteReservation(tripId, this.loggedRegularUser.id)
      .subscribe(
        ok => this.reloadReservations(),
        error => alert(error.error)
      );
  }

  updateReservation(seatsNumber: number, tripId: number): void {
    this._reservationService
      .updateReservation(tripId, this.loggedRegularUser.id, seatsNumber)
      .subscribe(
        data => {
          this.reloadReservations();
          alert("The reservation was updated");
        },
        error => alert(error.error)
      );
  }
}
