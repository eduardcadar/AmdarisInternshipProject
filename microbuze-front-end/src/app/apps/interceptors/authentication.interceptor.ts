import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AccountService } from "../services/account-service";

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
    constructor (private accountService: AccountService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.accountService.accessToken) {
            let token = this.accountService.accessToken;
            if (token) {
                req = req.clone({
                    setHeaders: {
                        Authorization: `Bearer ${token}`
                    }
                });
            }
        }
        return next.handle(req);
    }
}