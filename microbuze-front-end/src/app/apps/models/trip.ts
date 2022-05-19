import { IAgency } from "./agency";

export interface ITrip {
    tripId: number;
    agency: IAgency,
    departureLocation: string;
    destination: string;
    departureTime: Date;
    arrivalTime: Date;
    duration: Date;
    price: number;
    seats: number;
}