import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SensorsListComponent } from './sensors-list/sensors-list.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [SensorsListComponent],
  imports: [CommonModule, SharedModule],
})
export class SensorsModule {}
