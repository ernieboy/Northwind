import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';

@Injectable()
export  class CustomerDetailsGuard implements CanActivate {

    constructor(private _router: Router) {
    }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        let id:string = route.url[1].path;
        if (id == null) {
            alert('Invalid customer Id');
            // start a new navigation to redirect to list page
            this._router.navigate(['/customers']);
            // abort current navigation
            return false;
        };
        return true;
    }
}