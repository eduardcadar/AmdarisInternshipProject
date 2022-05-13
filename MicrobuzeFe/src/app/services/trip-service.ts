import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IAgency } from "../models/agency";
import { ITripCreate } from "../models/create/tripCreate";

@Injectable()
export class TripService {
    constructor(private httpClient: HttpClient) {}

    private agency: IAgency = {
        agencyId: 1,
        agencyName: 'agentie',
        phoneNumber: '0728192372'
    }

    getTrips(): Observable<any> {
        return this.httpClient.get("https://localhost:7188/api/trips");
    }

    createTrip(trip: ITripCreate): Observable<ITripCreate> {
        return this.httpClient.post<ITripCreate>("https://localhost:7188/api/trips", trip);
    }
}