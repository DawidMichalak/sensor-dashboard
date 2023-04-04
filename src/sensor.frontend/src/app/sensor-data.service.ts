import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Readings } from './sensor-readings/readings';

@Injectable({
  providedIn: 'root'
})

export class SensorDataService {

  private apiUrl = 'https://localhost:7288/readings';
  
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private handleError<T>(result?: T) {
    return (error: any): Observable<T> => {
      console.error(error); 
      return of(result as T);
    };
  }

  getReadings(): Observable<Readings[]> {
    return this.http.get<Readings[]>(this.apiUrl).pipe(
      tap(_ => console.log("fetch")),
      catchError(this.handleError<Readings[]>([]))
    );
  }
}
