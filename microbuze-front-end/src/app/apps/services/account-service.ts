import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { ILoginData } from "../models/account/loginData";
import { ILoginResponse } from "../models/account/loginResponse";
import { IRegisterData } from "../models/account/registerData";
import { map } from "rxjs/operators";
import { IRegularUser } from "../models/entities/regular-user";
import { IAgencyUser } from "../models/entities/agency-user";

@Injectable({ providedIn: 'root' })
export class AccountService {
    private url: string = 'https://localhost:7188/api';
    private user!: ILoginResponse;
    private loggedIn = new BehaviorSubject<boolean>(false);
    private isAgency = new BehaviorSubject<boolean>(false);

    get loggedUser(): ILoginResponse { return this.user; }

    get isLoggedInObs(): Observable<boolean> { return this.loggedIn.asObservable(); }

    get isAgencyObs(): Observable<boolean> { return this.isAgency.asObservable(); }

    get accessToken() {
        if (this.user)
            return this.user.token;
        return this.user;
    }

    constructor(private httpClient: HttpClient) {
        const userData = localStorage.getItem('user');
        if (userData) {
            const user: ILoginResponse = JSON.parse(userData);
            this.user = user;
            this.loggedIn.next(true);
            this.isAgency.next(user.isAgency);
        }
    }

    register(registerData: IRegisterData): Observable<any> {
        return this.httpClient.post(this.url + '/account/register', registerData);
    }

    login(loginData: ILoginData): Observable<ILoginResponse> {
        return this.httpClient
            .post<ILoginResponse>(this.url + '/account/authenticate', loginData)
            .pipe(map(user => 
                {
                    if (user && user.token) {
                        this.user = user;
                        this.loggedIn.next(true);
                        this.isAgency.next(user.isAgency);
                        localStorage.setItem('user', JSON.stringify(user))
                    }
                    return user;
                })
            );
    }

    logout(): void {
        this.loggedIn.next(false);
        this.user.token = '';
    }

    getRegularUser(id: string): Observable<IRegularUser> {
        return this.httpClient.get<IRegularUser>(this.url + `/regularUsers/${id}`);
    }

    getAgencyUser(id: string): Observable<IAgencyUser> {
        return this.httpClient.get<IAgencyUser>(this.url + `/agencyUsers/${id}`);
    }
}