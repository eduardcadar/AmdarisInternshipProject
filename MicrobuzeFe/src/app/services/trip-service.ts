import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IAgency } from "../models/agency";
import { IReservationCreate } from "../models/create/reservationCreate";
import { ITripCreate } from "../models/create/tripCreate";

@Injectable()
export class TripService {
    constructor(private httpClient: HttpClient) {}

    getTrips(from?: string, to?: string): Observable<any> {
        if (from == null) from = "";
        if (to == null) to = "";
        return this.httpClient.get("https://localhost:7188/api/trips?departure=" + from + "&destination="+ to);
    }

    saveTrip(trip: ITripCreate): Observable<any> {
        return this.httpClient.post<ITripCreate>("https://localhost:7188/api/trips", trip);
    }

    saveReservation(reservation: IReservationCreate): Observable<any> {
        return this.httpClient.post<IReservationCreate>("https://localhost:7188/api/reservations", reservation);
    }
}