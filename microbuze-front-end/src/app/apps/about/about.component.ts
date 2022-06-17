import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IAgencyUser } from '../models/entities/agency-user';
import { IRegularUser } from '../models/entities/regular-user';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit, OnDestroy {
  private _routeSub!: Subscription;
  isAgency!: boolean;
  regularUser!: IRegularUser;
  agencyUser!: IAgencyUser;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router
  ) { }

  ngOnInit(): void {
    this._routeSub = this._route.queryParams.subscribe(params => {
      if (!params || params['isagency'] == undefined || !params['id']) {
        this._router.navigate(['/']);
      }
      else if (params['isagency'] == 'true') {
        this.isAgency = true;
      } else {
        this.isAgency = false;
      }
    });
  }
  
  ngOnDestroy(): void {
    this._routeSub.unsubscribe();
  }
}
