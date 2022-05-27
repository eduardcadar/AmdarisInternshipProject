import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ITripCreate } from "../models/create/tripCreate";
import { ITrip } from "../models/entities/trip";

@Injectable()
export class TripService {
    url: string = "https://localhost:7188/api/trips";
    trips: ITrip[] = [];

    constructor(private httpClient: HttpClient) {}

    getTrips(from?: string, to?: string, date?: string): Observable<any> {
        let query: boolean = false, u: string = this.url;
        if (from && from.trim()) {
            query = true;
            u += '?departure=' + from.trim();
        }
        if (to && to.trim()) {
            if (!query) u += '?';
            else u += '&';
            query = true;
            u += 'destination=' + to.trim();
        }
        if (date && date.trim()) {
            if (!query) u += '?';
            else u += '&';
            u += 'date=' + date.trim();
        }
        return this.httpClient.get(u);
    }

    saveTrip(trip: ITripCreate): Observable<any> {
        return this.httpClient.post<ITripCreate>(this.url, trip);
    }

    deleteTrip(id: number): Observable<any> {
        return this.httpClient.delete<number>(this.url)
    }
}