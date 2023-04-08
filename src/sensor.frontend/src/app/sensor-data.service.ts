import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Readings } from './sensor-readings/readings';
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

  private handleError<T>(result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }

  getReadings(): Observable<Readings[]> {
    const options = {
      params: new HttpParams()
        .set('BeginDate', DateTime.now().minus({ days: 3 }).toISO() ?? '')
        .set('EndDate', DateTime.now().toISO() ?? ''),
    };
    return this.http
      .get<Readings[]>(this.apiUrl, options)
      .pipe(catchError(this.handleError<Readings[]>([])));
  }
}
