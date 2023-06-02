import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { SensorDetails } from '../models/sensorDetails';

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

  deleteSensorDetails(detailsId: number) {
    const currentData = this.sensorDetails.value;
    const newData = currentData.filter((details) => details.id !== detailsId);
    this.sensorDetails.next(newData);
    this.sendDeleteSensor(detailsId);
  }

  updateSensorDetails(newDetails: SensorDetails) {
    const currentData = this.sensorDetails.value;
    const detailsIndex = currentData.findIndex((x) => x.id === newDetails.id);
    currentData[detailsIndex].name = newDetails.name;
    this.sensorDetails.next(currentData);
    this.sendUpdateSensor(newDetails);
  }

  private sendUpdateSensor(updatedDetails: SensorDetails) {
    this.http.patch(this.apiUrl, updatedDetails).subscribe();
  }

  private sendDeleteSensor(detailsId: number) {
    this.http.delete(`${this.apiUrl}/${detailsId}`).subscribe();
  }

  private getSensorDetails() {
    this.http.get<SensorDetails[]>(this.apiUrl).subscribe((data) => {
      this.updateData(data);
    });
  }
}
