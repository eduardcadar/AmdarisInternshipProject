import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class ReservationsService {
    constructor(private httpClient: HttpClient) {}

    getReservationsForRegularUser(regularUserId: number): Observable<any> {
        return this.httpClient.get("https://localhost:7188/api/reservations/byRegularUserId/" + regularUserId);
    }
}