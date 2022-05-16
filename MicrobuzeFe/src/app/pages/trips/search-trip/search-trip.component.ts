import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ISearchTrip } from 'src/app/models/search-trip';

@Component({
  selector: 'app-search-trip',
  templateUrl: './search-trip.component.html',
  styleUrls: ['./search-trip.component.css']
})
export class SearchTripComponent implements OnInit {
  searchTripsForm: FormGroup = new FormGroup({
    from: new FormControl(''),
    to: new FormControl('')
  });

  @Output() searchChanged: EventEmitter<ISearchTrip> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  submitSearchTrip(): void {
    let searchTrip: ISearchTrip = {
      from: this.searchTripsForm.value.from,
      to: this.searchTripsForm.value.to
    }
    this.searchChanged.emit(searchTrip);
  }
}
