import { Component, Inject, OnInit } from '@angular/core';
import { ITrip } from '../../../models/trip';
import { TripService } from 'src/app/services/trip-service';
import { Observable } from 'rxjs';
import { ISearchTrip } from 'src/app/models/search-trip';
import { MatDialog } from '@angular/material/dialog'

@Component({
  selector: 'app-trips-list',
  templateUrl: './trips-list.component.html',
  styleUrls: ['./trips-list.component.css']
})
export class TripsListComponent implements OnInit {
  trips!: Observable<ITrip[]>;
  selectedTripId: number = 0;

  columnsToDisplay: string[] = [
    'agency',
    'departureLocation',
    'destination',
    'departureTime',
    'duration',
    'price',
    'seats',
    'reserveButton',
    'deleteButton'
  ];

  constructor(private tripService: TripService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.trips = this.tripService.getTrips();
  }

  deleteTrip(): void {

  }

  reserveSeats(tripId: number): void {
    const chooseSeats = this.dialog.open(TripsListComponent, {
      width: '250px',
      data: {}
    })
  }

  reloadTrips(searchTrip?: ISearchTrip): void {
    this.trips = this.tripService.getTrips(searchTrip?.from, searchTrip?.to);
  }
}
