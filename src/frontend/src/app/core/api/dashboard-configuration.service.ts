import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  CardConfiguration,
  DashboardConfiguration,
} from '../models/dashboardConfiguration';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DashboardConfigurationService {
  private apiUrl = 'https://localhost:7288/configurations';
  private configurationId = '6448e7271840ac33b58cbb9e'; //for now use this configuration
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

  updateConfigurationItem(newData: CardConfiguration) {
    const currentData = this.configuration.value;
    currentData[currentData.findIndex((x) => x.id == newData.id)] = newData;

    const params = {
      params: new HttpParams()
        .set('Name', newData.name)
        .set('SensorId', newData.sensorId),
    };

    this.http
      .patch(
        `${this.apiUrl}/${this.configurationId}/item/${newData.id}`,
        undefined,
        params
      )
      .subscribe();
    this.configuration.next(currentData);
  }

  removeConfigurationItem(itemId: string) {
    this.http
      .delete(`${this.apiUrl}/${this.configurationId}/item/${itemId}`)
      .subscribe(() => {
        const currentData = this.configuration.value;
        const newData = currentData.filter((item) => item.id !== itemId);
        this.updateConfiguration(newData);
      });
  }

  addConfigurationItem(item: Partial<CardConfiguration>) {
    this.http
      .post<CardConfiguration>(`${this.apiUrl}/${this.configurationId}`, item)
      .subscribe((data) => {
        const currentData = this.configuration.value;
        currentData.push(data);
        this.updateConfiguration(currentData);
      });
  }

  private getDashboardConfigutation() {
    this.http
      .get<DashboardConfiguration>(`${this.apiUrl}/${this.configurationId}`)
      .subscribe((data) => {
        this.updateConfiguration(data.configurationItems);
      });
  }
}
