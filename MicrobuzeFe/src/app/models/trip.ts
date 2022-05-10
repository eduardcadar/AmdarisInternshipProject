import { Time } from "@angular/common";
import { IAgency } from "./agency";

export interface ITrip {
    tripId: number;
    agency: IAgency,
    departureLocation: string;
    destination: string;
    departureTime: Date;
    duration: Time;
    price: number;
    seats: number;
}