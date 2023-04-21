import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-card-dialog',
  templateUrl: './add-card-dialog.component.html',
  styleUrls: ['./add-card-dialog.component.scss'],
})
export class AddCardDialogComponent {
  constructor(public dialogRef: MatDialogRef<AddCardDialogComponent>) {}
  name = '';
  selected = '';
}
