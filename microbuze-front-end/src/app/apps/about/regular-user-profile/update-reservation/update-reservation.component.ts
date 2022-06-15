import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-update-reservation',
  templateUrl: './update-reservation.component.html',
  styleUrls: ['./update-reservation.component.css']
})
export class UpdateReservationComponent implements OnInit {
  showUpdateSeats: boolean = false;

  updateSeatsForm: FormGroup = new FormGroup({
    seats: new FormControl('')
  });
  @Output() reserveClick: EventEmitter<number> = new EventEmitter();

  constructor() { }

  ngOnInit(): void { }

  toggleUpdateSeats(): void {
    this.showUpdateSeats = !this.showUpdateSeats;
  }

  updateSeats(): void {
    let seatsNumber: number = this.updateSeatsForm.value.seats;
    this.toggleUpdateSeats();
    if (seatsNumber < 1) {
      alert('Write the number of seats');
      return;
    }
    this.reserveClick.emit(seatsNumber);
  }
}
