import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IReservationCreate } from "../models/create/reservationCreate";

@Injectable()
export class ReservationsService {
    url: string = "https://localhost:7188/api/reservations";
    constructor(private httpClient: HttpClient) {}

    getReservationsForRegularUser(regularUserId: number): Observable<any> {
        return this.httpClient.get(this.url + "/byRegularUserId/" + regularUserId);
    }

    saveReservation(reservation: IReservationCreate): Observable<any> {
        return this.httpClient.post<IReservationCreate>(this.url, reservation);
    }
}