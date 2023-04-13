import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { SensorDetails } from './sensorDetails';

@Injectable({
  providedIn: 'root',
})
export class SensorDetailsService {
  private apiUrl = 'https://localhost:7288/sensors';

  constructor(private http: HttpClient) {
    this.getSensorDetails();
  }

  private sensorDetails = new BehaviorSubject<SensorDetails[]>([]);

  getData() {
    return this.sensorDetails.asObservable();
  }

  updateData(newData: SensorDetails[]) {
    this.sensorDetails.next(newData);
  }

  private getSensorDetails() {
    this.http.get<SensorDetails[]>(this.apiUrl).subscribe((data) => {
      this.updateData(data);
    });
  }
}
