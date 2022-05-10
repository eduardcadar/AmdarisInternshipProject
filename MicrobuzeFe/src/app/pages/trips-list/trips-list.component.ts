import { Component, OnInit } from '@angular/core';
import { ITrip } from '../../models/trip';
import { TripService } from 'src/app/services/trip-service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-trips-list',
  templateUrl: './trips-list.component.html',
  styleUrls: ['./trips-list.component.css']
})
export class TripsListComponent implements OnInit {
  pageTitle: string = 'Trips list';
  trips!: Observable<ITrip[]>;

  constructor(private tripService: TripService) {}

  ngOnInit(): void {
    this.trips = this.tripService.getTrips();
  }
}
