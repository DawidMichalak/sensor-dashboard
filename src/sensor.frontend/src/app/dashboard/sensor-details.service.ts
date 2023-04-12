import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SensorDetails } from './sensorDetails';

@Injectable({
  providedIn: 'root',
})
export class SensorDetailsService {
  private apiUrl = 'https://localhost:7288/sensors';

  constructor(private http: HttpClient) {}

  getSensorDetails(): Observable<SensorDetails[]> {
    return this.http.get<SensorDetails[]>(this.apiUrl);
  }
}
