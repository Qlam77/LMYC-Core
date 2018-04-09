import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Boat } from '../boat';
import { Reservation } from '../reservation';
import { ReservationService } from '../reservation.service'
import { BoatService } from '../boat.service'

@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.css'],
  providers: [ReservationService, BoatService]
})
export class AddReservationComponent implements OnInit {
  public boats: Boat[] = null;
  public reservation: Reservation = {
    startDate: '',
    endDate: '',
    reservedBoat: null,
    createdBy: null
  };
  public selectedBoat: any;

  constructor(
    private http: HttpClient,
    private reservationService: ReservationService,
    private boatService: BoatService,
    private router: Router) {}

  selectBoat(event) {
    console.log(event);
    this.reservation.reservedBoat = event;
  }

  disableSubmit() {
    return (!this.boats 
      || !this.reservation.startDate 
      || !this.reservation.endDate 
      || (this.reservation.startDate > this.reservation.endDate) 
      || !this.reservation.reservedBoat)
  }

  add(newReservation: Reservation): void {
    if (!newReservation) return;
    this.reservationService.create(newReservation)
    .then(newReservation => {
      this.router.navigate(['./reservation']);
    })
  }

  ngOnInit() {
    this.boatService.getBoats().then(boats => this.boats = boats);
  }

}