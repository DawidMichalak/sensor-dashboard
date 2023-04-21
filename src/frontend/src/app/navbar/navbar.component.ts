import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddCardDialogComponent } from '../add-card-dialog/add-card-dialog.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  constructor(private dialog: MatDialog) {}
  openCreateDialog(): void {
    const dialogRef = this.dialog.open(AddCardDialogComponent);

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
      }
    });
  }
}
