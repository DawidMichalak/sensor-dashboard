import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import {
  MAT_FORM_FIELD_DEFAULT_OPTIONS,
  MatFormFieldModule,
} from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SensorReadingsComponent } from './sensor-readings/sensor-readings.component';
import { DateRangeSelectionComponent } from './sensor-readings/date-range-selection/date-range-selection.component';
import { ReadingsMenuComponent } from './sensor-readings/readings-menu/readings-menu.component';
import { RenameDialogComponent } from './sensor-readings/readings-menu/rename-dialog/rename-dialog.component';
import { DeleteDialogComponent } from './sensor-readings/readings-menu/delete-dialog/delete-dialog.component';
import { MatInputModule } from '@angular/material/input';
import { NavbarComponent } from './navbar/navbar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSelectModule } from '@angular/material/select';
import { AddCardDialogComponent } from './add-card-dialog/add-card-dialog.component';
import { ReactiveFormsModule } from '@angular/forms';

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
  ],
  imports: [
    ReactiveFormsModule,
    FormsModule,
    MatChipsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    MatDialogModule,
    MatInputModule,
    MatToolbarModule,
    MatSelectModule,
    HttpClientModule,
  ],
  providers: [
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
      useValue: { appearance: 'outline' },
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
