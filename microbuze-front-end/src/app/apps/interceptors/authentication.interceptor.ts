import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AccountService } from "../services/account-service";

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
    
    constructor (private accountService: AccountService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // let user = this.accountService.currentUser.;
        let user = localStorage.getItem('user');
        if (user != null) {
            let user2 = JSON.parse(user);
            req = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${user2.token}`
                }
            });
        }
        return next.handle(req);
    }
}