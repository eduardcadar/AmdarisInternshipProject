import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { AccountService } from "../services/account-service";

@Injectable()
export class IsAgencyGuard implements CanActivate {
    constructor(
        private _accountService: AccountService,
        private _router: Router
    ) {}

    canActivate(): boolean {
        const isAgency: boolean = this._accountService.loggedUser.isAgency;
        if (isAgency)
            return true;
        else {
            alert('You need to be logged into an agency account');
            this._router.navigate(['/']);
            return false;
        }
    }
}