import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ITripCreate } from "../models/create/tripCreate";
import { ITrip } from "../models/trip";

@Injectable()
export class TripService {
    url: string = "https://localhost:7188/api/trips";
    trips: ITrip[] = [];

    constructor(private httpClient: HttpClient) {}

    getTrips(from?: string, to?: string): Observable<any> {
        if (from == null) from = "";
        if (to == null) to = "";
        return this.httpClient.get(this.url + "?departure=" + from + "&destination="+ to);
    }

    saveTrip(trip: ITripCreate): Observable<any> {
        return this.httpClient.post<ITripCreate>(this.url, trip);
    }

    deleteTrip(id: number): Observable<any> {
        return this.httpClient.delete<number>(this.url)
    }
}