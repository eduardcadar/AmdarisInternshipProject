import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IRegisterData } from "../models/account/registerData";

@Injectable()
export class AccountService {
    private url: string = "https://localhost:7188/api/account";

    constructor(private httpClient: HttpClient) {}

    register(registerData: IRegisterData): Observable<any> {
        return this.httpClient.post(this.url + '/register', registerData);
    }
}