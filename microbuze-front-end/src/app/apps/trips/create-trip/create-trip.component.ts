import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FullComponent } from '../../layout/full/full.component';
import { ITripCreate } from '../../models/create/tripCreate';
import { TripService } from '../../services/trip-service';

@Component({
  selector: 'app-create-trip',
  templateUrl: './create-trip.component.html',
  styleUrls: ['./create-trip.component.css']
})
export class CreateTripComponent implements OnInit {
  createTripForm: FormGroup = new FormGroup({
    departureLocation: new FormControl('', [Validators.required]),
    destination: new FormControl('', [Validators.required]),
    departureTime: new FormControl('', [Validators.required]),
    arriveTime: new FormControl('', [Validators.required]),
    price: new FormControl('', [Validators.required]),
    seats: new FormControl('', [Validators.required])
  });
  
  constructor(
    private _parent: FullComponent,
    private tripService: TripService
  ) { }

  ngOnInit(): void { }

  submitCreateTrip(): void {
    let start = Date.parse(this.createTripForm.value.departureTime);
    let end = Date.parse(this.createTripForm.value.arriveTime);
    let dateDuration = new Date(end - start);
    let duration = (dateDuration.getHours() - 2) + ':' + dateDuration.getMinutes();
    let createdTrip: ITripCreate = {
      agencyId: this._parent.agencyId,
      departureLocation: this.createTripForm.value.departureLocation,
      destination: this.createTripForm.value.destination,
      departureTime: this.createTripForm.value.departureTime.toString(),
      duration: duration,
      price: this.createTripForm.value.price,
      seats: this.createTripForm.value.seats
    };
    this.tripService.saveTrip(createdTrip).subscribe(
      () => alert('Cursa creata'),
      error => alert(error.error)
    );
  }
}
