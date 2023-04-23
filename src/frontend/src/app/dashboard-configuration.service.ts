import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  CardConfiguration,
  DashboardConfiguration,
} from './shared/dashboardConfiguration';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DashboardConfigurationService {
  private apiUrl = 'https://localhost:7288/configuration';
  constructor(private http: HttpClient) {
    this.getDashboardConfigutation();
  }

  private configuration = new BehaviorSubject<CardConfiguration[]>([]);
  getConfiguration() {
    return this.configuration.asObservable();
  }

  updateConfiguration(newData: CardConfiguration[]) {
    this.configuration.next(newData);
  }

  private getDashboardConfigutation() {
    this.http.get<DashboardConfiguration>(this.apiUrl).subscribe((data) => {
      this.updateConfiguration(data.configurationItems);
    });
  }
}
