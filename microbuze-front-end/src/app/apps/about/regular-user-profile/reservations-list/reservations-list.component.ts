import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  regularUserObs!: Observable<IRegularUser>;
  regularUser!: IRegularUser;
  canUpdate: boolean = false;

  constructor(
    private _accountService: AccountService,
    private _reservationService: ReservationsService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this._route.queryParams.subscribe(params => {
      this.regularUserObs = this._accountService.getRegularUser(params['id']);
      this.regularUserObs.subscribe(reg => {
        this.regularUser = reg;
        this.canUpdate = (this._accountService.loggedUser && reg.id === this._accountService.loggedUser.id);
        this.reloadReservations();
      });
    });
  }

  reloadReservations(): void {
    this.reservations = this._reservationService
      .getReservationsForRegularUser(this.regularUser.id);
  }

  deleteReservation(tripId: number): void {
    this._reservationService
      .deleteReservation(tripId, this.regularUser.id)
      .subscribe(
        ok => this.reloadReservations(),
        error => alert(error.error)
      );
  }

  updateReservation(seatsNumber: number, tripId: number): void {
    this._reservationService
      .updateReservation(tripId, this.regularUser.id, seatsNumber)
      .subscribe(
        data => {
          this.reloadReservations();
          alert("The reservation was updated");
        },
        error => alert(error.error)
      );
  }
}
