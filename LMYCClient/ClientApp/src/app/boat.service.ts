import { Injectable } from '@angular/core';
import { Boat } from './boat';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class BoatService {
  private BASE_URL = "http://sheldonquincylymc.azurewebsites.net/api/boatsapi"; 

  constructor(private http: Http) { }

  getBoats(): Promise<Boat[]> {

    return this.http.get(this.BASE_URL)
    .toPromise()
    .then(response => response.json() as Boat[])
    .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
