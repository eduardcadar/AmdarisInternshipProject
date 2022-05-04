import { Component, OnInit } from '@angular/core';
import { ITrip } from './models/trip';

@Component({
  selector: 'app-trips-list',
  templateUrl: './trips-list.component.html',
  styleUrls: ['./trips-list.component.css']
})
export class TripsListComponent implements OnInit {
  pageTitle: string = 'Trips list';
  trips: ITrip[] = [
    {
      tripId: 1,
      departurePlace: 'timisoara',
      destination: 'arad',
      duration: '0:40'
    },
    {
      tripId: 2,
      departurePlace: 'cluj-napoca',
      destination: 'hunedoara',
      duration: '3:45'
    }
  ];

  constructor() {}

  ngOnInit(): void {}

}
