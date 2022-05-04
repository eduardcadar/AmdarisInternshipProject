import { Time } from "@angular/common";

export interface ITrip {
    tripId: number;
    // agency: IAgency,
    departurePlace: string;
    destination: string;
    // departureTime: Date;
    duration: string; // time
    // price: number;
    // seats: number;
}