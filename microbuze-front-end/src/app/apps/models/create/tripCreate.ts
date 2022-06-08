export interface ITripCreate {
    agencyUserId: string,
    departureLocation: string;
    destination: string;
    departureTime: string;
    duration: string;
    price: number;
    seats: number;
}