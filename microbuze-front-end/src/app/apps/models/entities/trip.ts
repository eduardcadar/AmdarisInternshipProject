import { IAgencyUser } from "./agency-user";

export interface ITrip {
    id: number;
    agencyUser: IAgencyUser,
    departureLocation: string;
    destination: string;
    departureTime: Date;
    arrivalTime: Date;
    duration: Date;
    price: number;
    seatsLeft: number;
}