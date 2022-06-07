import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { ILoginData } from "../models/account/loginData";
import { ILoginResponse } from "../models/account/loginResponse";
import { IRegisterData } from "../models/account/registerData";
import { map } from "rxjs/operators";

@Injectable({ providedIn: "root" })
export class AccountService {
    private url: string = "https://localhost:7188/api/account";
    public currentUser!: Observable<ILoginResponse>;
    private currentUserSubject!: BehaviorSubject<ILoginResponse>;

    constructor(private httpClient: HttpClient) {
        let user = localStorage.getItem('user');
        this.currentUserSubject = new BehaviorSubject<ILoginResponse>(
            user != null ? JSON.parse(user) : null
        );
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get getCurrentUser(): ILoginResponse {
        return this.currentUserSubject.value;
    }

    register(registerData: IRegisterData): Observable<any> {
        return this.httpClient.post(this.url + '/register', registerData);
    }

    login(loginData: ILoginData): Observable<ILoginResponse> {
        return this.httpClient
            .post<ILoginResponse>(this.url + '/authenticate', loginData)
            .pipe(map(user => {
                if (user && user.token) {
                    localStorage.setItem('user', JSON.stringify(user))
                }
                return user;
            }));
    }
}