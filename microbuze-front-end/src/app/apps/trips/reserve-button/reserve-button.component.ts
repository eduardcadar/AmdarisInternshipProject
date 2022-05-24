import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { IReservationCreate } from '../../models/create/reservationCreate';

@Component({
  selector: 'app-reserve-button',
  templateUrl: './reserve-button.component.html',
  styleUrls: ['./reserve-button.component.css']
})
export class ReserveButtonComponent implements OnInit {
  showSeatsInput: boolean = false;

  reserveSeatsForm: FormGroup = new FormGroup({
    seats: new FormControl('')
  });
  @Output() reserveClick: EventEmitter<number> = new EventEmitter();

  constructor() { }

  ngOnInit(): void { }

  toggleSeatsInput() {
    this.showSeatsInput = !this.showSeatsInput;
  }

  reserveSeats(): void {
    let seatsNumber: number = this.reserveSeatsForm.value.seats;
    this.toggleSeatsInput();
    if (seatsNumber < 1) {
      alert('Introduceti numarul de locuri');
      return;
    }
    this.reserveClick.emit(seatsNumber);
  }
}
