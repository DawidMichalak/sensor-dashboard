import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SensorsListComponent } from './sensors-list/sensors-list.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { EditSensorComponent } from './sensors-list/edit-sensor/edit-sensor.component';
import { ReactiveFormsModule } from '@angular/forms';

const routes: Routes = [
  {
    path: '',
    component: SensorsListComponent,
  },
];

@NgModule({
  declarations: [SensorsListComponent, EditSensorComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
  ],
})
export class SensorsModule {}
