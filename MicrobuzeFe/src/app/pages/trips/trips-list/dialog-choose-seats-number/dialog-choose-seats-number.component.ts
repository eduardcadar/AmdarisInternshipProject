import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

export interface DialogData {
  seats: number;
}

@Component({
  selector: 'app-dialog-choose-seats-number',
  templateUrl: './dialog-choose-seats-number.component.html',
  styleUrls: ['./dialog-choose-seats-number.component.css']
})
export class DialogChooseSeatsNumberComponent {

  constructor(public dialogRef: MatDialogRef<DialogChooseSeatsNumberComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) { }

  onBackClick(): void {
    this.dialogRef.close();
  }
}
