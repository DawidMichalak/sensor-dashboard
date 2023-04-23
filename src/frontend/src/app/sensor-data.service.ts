import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Readings } from './shared/readings';
import { DateTime } from 'luxon';

@Injectable({
  providedIn: 'root',
})
export class SensorDataService {
  private apiUrl = 'https://localhost:7288/readings';

  constructor(private http: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  getDefaultReadings(): Observable<Readings[]> {
    const beginDate = DateTime.now().minus({ days: 2 });

    return this.getReadings<Readings[]>(beginDate);
  }

  getSelectedReadings(start: DateTime, sensorId: number): Observable<Readings> {
    return this.getReadings<Readings>(start, sensorId);
  }

  private getReadings<Type>(
    beginDate: DateTime,
    sensorId?: number
  ): Observable<Type> {
    let url = this.apiUrl;
    if (sensorId) {
      url += `/${sensorId}`;
    }

    const options = {
      params: new HttpParams()
        .set('BeginDate', beginDate.toISO()!)
        .set('EndDate', DateTime.now().toISO()!),
    };

    return this.http.get<Type>(url, options);
  }
}
