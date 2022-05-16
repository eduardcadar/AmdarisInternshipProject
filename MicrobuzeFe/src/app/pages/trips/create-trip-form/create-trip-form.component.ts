import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ISearchTrip } from 'src/app/models/search-trip';
import { TripService } from 'src/app/services/trip-service';

@Component({
  selector: 'app-create-trip-form',
  templateUrl: './create-trip-form.component.html',
  styleUrls: ['./create-trip-form.component.css']
})
export class CreateTripFormComponent implements OnInit {
  createTripForm: FormGroup = new FormGroup({
    agencyId: new FormControl('', [Validators.required]),
    departureLocation: new FormControl('', [Validators.required]),
    destination: new FormControl('', [Validators.required]),
    departureTime: new FormControl('', [Validators.required]),
    arriveTime: new FormControl('', [Validators.required]),
    price: new FormControl('', [Validators.required]),
    seats: new FormControl('', [Validators.required])
  });
  
  @Output() tripCreated: EventEmitter<ISearchTrip> = new EventEmitter();

  constructor(private tripService: TripService) { }

  ngOnInit(): void {
  }

  submitCreateTrip(): void {
    let start = Date.parse(this.createTripForm.value.departureTime);
    let end = Date.parse(this.createTripForm.value.arriveTime);
    let dateDuration = new Date(end - start);
    let duration = dateDuration.getHours() + ':' + dateDuration.getMinutes();
    let createdTrip = {
      agencyId: this.createTripForm.value.agencyId,
      departureLocation: this.createTripForm.value.departureLocation,
      destination: this.createTripForm.value.destination,
      departureTime: this.createTripForm.value.departureTime.toString(),
      duration: duration,
      price: this.createTripForm.value.price,
      seats: this.createTripForm.value.seats
    };
    this.tripService.saveTrip(createdTrip).subscribe(() => this.tripCreated.emit(
        {
          from: "",
          to: ""
        }));
  }
}
