import { Time } from "@angular/common";
import { IAgency } from "./agency";

export interface ITrip {
    tripId: number;
    agency: IAgency,
    departurePlace: string;
    destination: string;
    departureTime: Date;
    duration: Time;
    price: number;
    seats: number;
}