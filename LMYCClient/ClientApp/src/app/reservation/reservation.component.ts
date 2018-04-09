import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent implements OnInit {
  public reservations: Reservation[];

  constructor(http: HttpClient) {
    http.get<Reservation[]>('localhost:44330/api/reservationsapi').subscribe(result => {
      this.reservations = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  
  }
}

interface Reservation {
  startDate: string;
  endDate: string;
  reservedBoat: number;
  createdBy: number;
}

