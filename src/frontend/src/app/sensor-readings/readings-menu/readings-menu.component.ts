import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RenameDialogComponent } from './rename-dialog/rename-dialog.component';
import { DeleteDialogComponent } from '../../shared/delete-dialog/delete-dialog.component';
import { CardConfiguration } from 'src/app/core/models/dashboardConfiguration';
import { DashboardConfigurationService } from 'src/app/core/api/dashboard-configuration.service';

@Component({
  selector: 'app-readings-menu',
  templateUrl: './readings-menu.component.html',
  styleUrls: ['./readings-menu.component.scss'],
})
export class ReadingsMenuComponent implements OnInit {
  constructor(
    public dialog: MatDialog,
    private configurationService: DashboardConfigurationService
  ) {}
  @Input() public cardConfiguration!: CardConfiguration;

  ngOnInit(): void {}

  openRenameDialog(): void {
    if (this.cardConfiguration !== undefined) {
      const dialogRef = this.dialog.open(RenameDialogComponent, {
        data: { name: this.cardConfiguration.name },
      });

      dialogRef.afterClosed().subscribe((result) => {
        if (result) {
          this.cardConfiguration.name = result;
          this.configurationService.updateConfigurationItem(
            this.cardConfiguration
          );
        }
      });
    }
  }

  openDeleteDialog(): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      data: { itemName: 'card' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.configurationService.removeConfigurationItem(
          this.cardConfiguration.id
        );
      }
    });
  }
}
