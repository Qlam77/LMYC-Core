import { Injectable } from '@angular/core';
import { Reservation } from './reservation';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class ReservationService {
  private BASE_URL = "http://sheldonquincylymc.azurewebsites.net/api/reservationsapi"; 

  constructor(private http: Http) { }

  getReservations(): Promise<Reservation[]> {
    let reservations : Reservation[];

    return this.http.get(this.BASE_URL)
    .toPromise()
    .then(response => response.json() as Reservation[])
    .catch(this.handleError);
  }

  private headers = new Headers({'Content-Type': 'application/json'});

  create(newReservation: Reservation): Promise<Reservation> {
    return this.http.post(this.BASE_URL, JSON.stringify(newReservation), { headers: this.headers })
    .toPromise()
    .then(res => res.json().data)
    .catch(this.handleError)
  } 

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
