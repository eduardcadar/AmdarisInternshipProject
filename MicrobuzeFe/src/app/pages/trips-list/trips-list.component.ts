import { Component, OnInit } from '@angular/core';
import { ITrip } from '../../models/trip';
import { Time } from '@angular/common';
import { IAgency } from 'src/app/models/agency';

@Component({
  selector: 'app-trips-list',
  templateUrl: './trips-list.component.html',
  styleUrls: ['./trips-list.component.css']
})
export class TripsListComponent implements OnInit {
  pageTitle: string = 'Trips list';
  agency: IAgency = {
    agencyId: 1,
    agencyName: 'agentie',
    phoneNumber: '0728192372'
  }
  trips: ITrip[] = [
    {
      tripId: 1,
      agency: this.agency,
      departurePlace: 'timisoara',
      destination: 'arad',
      departureTime: new Date(),
      duration: { hours: 0, minutes: 40 },
      price: 25,
      seats: 22,
    },
    {
      tripId: 2,
      agency: this.agency,
      departurePlace: 'cluj-napoca',
      destination: 'hunedoara',
      departureTime: new Date(),
      duration: { hours: 3, minutes:45 },
      price: 25,
      seats: 22
    }
  ];

  constructor() {}

  ngOnInit(): void {}

}
