import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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

  reloadTrips(searchTrip: ISearchTrip): void {
    this.trips = this.tripService.getTrips(searchTrip.from, searchTrip.to);
  }
}