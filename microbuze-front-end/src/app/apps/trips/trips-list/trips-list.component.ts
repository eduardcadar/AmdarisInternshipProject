import { Component, OnInit, ViewChild } from '@angular/core';
import { Blog } from '../../blog/blog-type';
import { ServiceblogService } from '../../blog/blog-service.service';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { TripService } from '../../services/trip-service';
import { ITrip } from '../../models/entities/trip';
import { ISearchTrip } from '../../models/search-trip';
import { Observable } from 'rxjs';
import { DatePipe } from '@angular/common';
import { ReservationsService } from '../../services/reservations-service';
import { IReservationCreate } from '../../models/create/reservationCreate';
import { FullComponent } from '../../layout/full/full.component';
import { AccountService } from '../../services/account-service';

@Component({
  selector: 'app-blog',
  templateUrl: './trips-list.component.html',
  styleUrls: ['./trips-list.component.css'],
})
export class TripsListComponent implements OnInit {
  isLoggedIn!: Observable<boolean>;
  isAgency!: Observable<boolean>;
  // blogsDetail: Blog[] = [];
  trips!: Observable<ITrip[]>;
  searched: boolean = false;
  pipe = new DatePipe('en-GB');

  constructor(
    private _accountService: AccountService,
    private _tripService: TripService,
    private _reservationService: ReservationsService,
    private _router: Router
  ) {
    this.isLoggedIn = _accountService.isLoggedIn;
    this.isAgency = _accountService.isAgencyObs;
    // this.service.showEdit = true;
  }

  ngOnInit(): void {}

  reloadTrips(searchTrip?: ISearchTrip): void {
    this.searched = true;
    this.trips = this._tripService.getTrips(searchTrip?.from, searchTrip?.to, searchTrip?.date);
    // this.trips.forEach(t => t.map(t => t.arrivalTime = new Date(
    //   new Date(t.departureTime).getTime() + new Date(t.duration).getTime())));
  }

  reserveSeats(seatsNumber: number, tripId: number): void {
    let reservation: IReservationCreate = {
      tripId: tripId,
      regularUserId: this._accountService.loggedUser.id,
      seats: seatsNumber
    }
    this._reservationService.saveReservation(reservation)
      .subscribe(
        data => {
          this.reloadTrips();
          alert("Rezervarea a fost creata");
        },
        error => alert(error.error)
      );
  }

  loginClick() {
    this._router.navigate(['/login']);
  }

  newPost() {
    this._router.navigate(['/post']);
  }
}
