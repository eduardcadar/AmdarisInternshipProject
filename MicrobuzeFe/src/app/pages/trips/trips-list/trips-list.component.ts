import { Component, OnInit } from '@angular/core';
import { ITrip } from '../../../models/trip';
import { TripService } from 'src/app/services/trip-service';
import { Observable } from 'rxjs';
import { ISearchTrip } from 'src/app/models/search-trip';

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
    'seats'
  ];

  constructor(private tripService: TripService) {}

  ngOnInit(): void {
    this.trips = this.tripService.getTrips();
  }

  selectTrip(tripId: number): void {
    this.selectedTripId = tripId;
    alert(this.selectedTripId);
  }

  reloadTrips(searchTrip?: ISearchTrip): void {
    this.trips = this.tripService.getTrips(searchTrip?.from, searchTrip?.to);
  }
}