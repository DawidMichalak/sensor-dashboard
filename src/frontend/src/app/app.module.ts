import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from './shared/shared.module';
import { AppRoutingModule } from './app-routing.module';
import { SensorsModule } from './sensors/sensors.module';
import { DashboardModule } from './dashboard/dashboard.module';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, HttpClientModule, SharedModule, AppRoutingModule],

  bootstrap: [AppComponent],
})
export class AppModule {}
