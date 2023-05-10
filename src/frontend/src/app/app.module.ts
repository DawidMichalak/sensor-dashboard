import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SensorReadingsComponent } from './sensor-readings/sensor-readings.component';
import { DateRangeSelectionComponent } from './sensor-readings/date-range-selection/date-range-selection.component';
import { ReadingsMenuComponent } from './sensor-readings/readings-menu/readings-menu.component';
import { RenameDialogComponent } from './sensor-readings/readings-menu/rename-dialog/rename-dialog.component';
import { DeleteDialogComponent } from './shared/delete-dialog/delete-dialog.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AddCardDialogComponent } from './dashboard/add-card-dialog/add-card-dialog.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';
import { AppRoutingModule } from './app-routing.module';
import { SensorsListComponent } from './sensors-list/sensors-list.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    SensorReadingsComponent,
    DateRangeSelectionComponent,
    ReadingsMenuComponent,
    RenameDialogComponent,
    DeleteDialogComponent,
    NavbarComponent,
    AddCardDialogComponent,
    SensorsListComponent,
  ],
  imports: [
    ReactiveFormsModule,
    FormsModule,
    BrowserModule,
    HttpClientModule,
    SharedModule,
    AppRoutingModule,
  ],

  bootstrap: [AppComponent],
})
export class AppModule {}
