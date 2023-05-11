import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SensorsListComponent } from './sensors-list/sensors-list.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: SensorsListComponent,
  },
];

@NgModule({
  declarations: [SensorsListComponent],
  imports: [CommonModule, SharedModule, RouterModule.forChild(routes)],
})
export class SensorsModule {}
