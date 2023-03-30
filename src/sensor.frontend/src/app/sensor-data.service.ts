import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Reading } from './sensor-readings/reading';

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
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getReadings(): Observable<Reading[]> {
    return this.http.get<Reading[]>(this.apiUrl).pipe(
      tap(_ => console.log("fetch")),
      catchError(this.handleError<Reading[]>([]))
    );
  }
}
