import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateRangeSelectionComponent } from '../sensor-readings/date-range-selection/date-range-selection.component';
import { ReadingsMenuComponent } from '../sensor-readings/readings-menu/readings-menu.component';
import { RenameDialogComponent } from '../sensor-readings/readings-menu/rename-dialog/rename-dialog.component';
import { SensorReadingsComponent } from '../sensor-readings/sensor-readings.component';
import { AddCardDialogComponent } from './add-card-dialog/add-card-dialog.component';
import { DashboardComponent } from './dashboard.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    DashboardComponent,
    SensorReadingsComponent,
    DateRangeSelectionComponent,
    ReadingsMenuComponent,
    RenameDialogComponent,
    AddCardDialogComponent,
  ],
  imports: [CommonModule, SharedModule, ReactiveFormsModule, FormsModule],
})
export class DashboardModule {}
