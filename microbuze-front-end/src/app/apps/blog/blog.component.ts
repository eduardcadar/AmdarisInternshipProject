import { Component, OnInit, ViewChild } from '@angular/core';
import { Blog } from './blog-type';
import { ServiceblogService } from './blog-service.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { TripService } from '../services/trip-service';
import { ITrip } from '../models/trip';
import { ISearchTrip } from '../models/search-trip';
import { Observable, pipe } from 'rxjs';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css'],
})
export class BlogComponent implements OnInit {
  // blogsDetail: Blog[] = [];
  trips!: Observable<ITrip[]>;
  searched: boolean = false;
  pipe = new DatePipe('en-GB');

  constructor(
    public tripService: TripService,
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

  loginClick() {
    this.router.navigate(['/login']);
  }

  newPost() {
    this.router.navigate(['/post']);
  }

  viewDetail(id: number) {
    // this.service.detailId = id;
    // if (this.service.loginStatusService) this.service.showEdit = true;
    this.router.navigate(['/blogDetail', id]);
  }
}
