import { IRegularUser } from "./regular-user";
import { ITrip } from "./trip";

export interface IReservation {
    trip: ITrip;
    regularUser: IRegularUser;
    seats: number;
}