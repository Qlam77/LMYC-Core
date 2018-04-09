import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Reservation } from '../reservation';
import { Boat } from '../boat';
import { ReservationService } from '../reservation.service'
import { BoatService } from '../boat.service'

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css'],
  providers: [ReservationService, BoatService]
})
export class ReservationComponent implements OnInit {
  public reservations: Reservation[];
  public boats: Boat[];

  constructor(http: HttpClient, private reservationService: ReservationService, private boatService: BoatService) {
  }

  getReservations(): void {
    this.reservationService.getReservations()
    .then(reservations => this.reservations = reservations);
  }

  getBoats(): void {
    this.boatService.getBoats()
    .then(boats => {
      this.boats = boats;
    });
  }

  getBoatName(boatId): string {
    if (!this.boats) return;

    let boat = this.boats.filter(boat => boat.boatId === boatId);

    console.log("filtered boat", boat);

    if (boat.length == 0) return;

    return boat[0].boatName;
  }

  ngOnInit() {
    this.getReservations();
    this.getBoats();
  }
}

