import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  agencyUserObs!: Observable<IAgencyUser>;
  agencyUser!: IAgencyUser;
  canDelete: boolean = false;

  constructor(
    private _accountService: AccountService,
    private _tripService: TripService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this._route.queryParams.subscribe(params => {
      this.agencyUserObs = this._accountService.getAgencyUser(params['id']);
      this.agencyUserObs.subscribe(ag => {
        this.agencyUser = ag;
        this.canDelete = (this._accountService.loggedUser && ag.id === this._accountService.loggedUser.id);
        this.reloadTrips();
      });
    });
  }

  reloadTrips(): void {
    this.trips = this._tripService
      .getTrips(this.agencyUser.agency);
  }

  deleteTrip(tripId: number): void {
    this._tripService.deleteTrip(tripId)
      .subscribe(
        ok => this.reloadTrips(),
        error => alert(error.error)
      );
  }
}
