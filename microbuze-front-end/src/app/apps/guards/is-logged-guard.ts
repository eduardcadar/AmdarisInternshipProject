import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { AccountService } from "../services/account-service";

@Injectable()
export class IsLoggedGuard implements CanActivate {
    constructor(
        private _accountService: AccountService,
        private _router: Router
    ) {}

    canActivate(): boolean {
        if (this._accountService.loggedUser &&
            this._accountService.loggedUser.token)
            return true;
        else {
            alert('You need to be logged in');
            this._router.navigate(['/']);
            return false;
        }
    }
}