import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SensorsListComponent } from './sensors/sensors-list/sensors-list.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'sensors', component: SensorsListComponent },
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
