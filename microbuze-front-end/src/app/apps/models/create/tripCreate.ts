export interface ITripCreate {
    agencyId: number,
    departureLocation: string;
    destination: string;
    departureTime: string;
    duration: string;
    price: number;
    seats: number;
}