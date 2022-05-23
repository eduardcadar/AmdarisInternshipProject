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

@Component({
  selector: 'app-blog',
  templateUrl: './trips-list.component.html',
  styleUrls: ['./trips-list.component.css'],
})
export class TripsListComponent implements OnInit {
  // blogsDetail: Blog[] = [];
  trips!: Observable<ITrip[]>;
  searched: boolean = false;
  pipe = new DatePipe('en-GB');

  constructor(
    private _parent: FullComponent,
    public tripService: TripService,
    public reservationService: ReservationsService,
    public router: Router,
    public http: HttpClient
  ) {
    // this.service.showEdit = true;
  }

  ngOnInit(): void {
  }

  reloadTrips(searchTrip?: ISearchTrip): void {
    this.searched = true;
    this.trips = this.tripService.getTrips(searchTrip?.from, searchTrip?.to);
    // this.trips.forEach(t => t.map(t => t.arrivalTime = new Date(
    //   new Date(t.departureTime).getTime() + new Date(t.duration).getTime())));
  }

  reserveSeats(seatsNumber: number, tripId: number): void {
    let reservation: IReservationCreate = {
      tripId: tripId,
      regularUserId: this._parent.loggedUser.regularUserId,
      seats: seatsNumber
    }
    this.reservationService.saveReservation(reservation)
      .subscribe(
        data => {
          this.reloadTrips();
          alert("Rezervarea a fost creata");
        },
        error => alert(error.error)
      );
  }

  loginClick() {
    this.router.navigate(['/login']);
  }

  newPost() {
    this.router.navigate(['/post']);
  }
}
