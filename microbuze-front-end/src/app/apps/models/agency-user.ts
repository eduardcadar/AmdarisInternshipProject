import { IAgency } from "./agency";

export interface IAgencyUser {
    agencyUserId: number;
    username: string;
    password: string;
    phoneNumber: string;
    agency: IAgency;
}