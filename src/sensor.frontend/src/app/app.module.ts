import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { LayoutModule } from '@angular/cdk/layout';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SensorReadingsComponent } from './sensor-readings/sensor-readings.component';
import { DateRangeSelectionComponent } from './sensor-readings/date-range-selection/date-range-selection.component';
import { ReadingsMenuComponent } from './sensor-readings/readings-menu/readings-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    SensorReadingsComponent,
    DateRangeSelectionComponent,
    ReadingsMenuComponent,
  ],
  imports: [
    MatChipsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    LayoutModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
