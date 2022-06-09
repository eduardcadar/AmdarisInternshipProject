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

    getTrips(agency?: string, from?: string,
            to?: string, date?: string): Observable<ITrip[]> {
        let u: string = this.url, q: string = '?';
        if (agency && agency.trim()) {
            u += `${q}agency=${agency.trim()}`;
            q = '&';
        }
        if (from && from.trim()) {
            u += `${q}departure=${from.trim()}`;
            q = '&';
        }
        if (to && to.trim()) {
            u += `${q}destination=${to.trim()}`;
            q = '&';
        }
        if (date && date.trim()) {
            u += `${q}date=${date.trim()}`;
        }
        return this.httpClient.get<ITrip[]>(u);
    }

    saveTrip(trip: ITripCreate): Observable<any> {
        return this.httpClient.post<ITripCreate>(this.url, trip);
    }

    deleteTrip(id: number): Observable<any> {
        return this.httpClient.delete<number>(this.url + `/${id}`);
    }
}