import { IAgency } from "./agency";

export interface ITrip {
    id: number;
    agency: IAgency,
    departureLocation: string;
    destination: string;
    departureTime: Date;
    arrivalTime: Date;
    duration: Date;
    price: number;
    seatsLeft: number;
}