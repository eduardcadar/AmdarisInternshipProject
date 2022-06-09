import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IAgencyUser } from 'src/app/apps/models/entities/agency-user';
import { ITrip } from 'src/app/apps/models/entities/trip';
import { AccountService } from 'src/app/apps/services/account-service';
import { TripService } from 'src/app/apps/services/trip-service';

@Component({
  selector: 'app-agency-trips-list',
  templateUrl: './agency-trips-list.component.html',
  styleUrls: ['./agency-trips-list.component.css']
})
export class AgencyTripsListComponent implements OnInit {
  trips!: Observable<ITrip[]>;
  loggedAgencyUser!: IAgencyUser;

  constructor(
    private _accountService: AccountService,
    private _tripService: TripService
  ) {}

  ngOnInit(): void {
    let id: string = this._accountService.loggedUser.id;
    this._accountService.getAgencyUser(id)
      .subscribe(u => {
        this.loggedAgencyUser = u;
        this.reloadTrips();
      });
  }

  reloadTrips(): void {
    this.trips = this._tripService
      .getTrips(this.loggedAgencyUser.agency);
  }

  deleteTrip(tripId: number): void {
    this._tripService.deleteTrip(tripId)
      .subscribe(
        ok => this.reloadTrips(),
        error => alert(error.error)
      );
  }
}
