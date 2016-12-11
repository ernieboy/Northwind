import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription } from 'rxjs/Subscription';

import { ICustomer } from "./customer";
import { CustomerService } from "./customer.service";

@Component({
    moduleId: module.id,
    templateUrl: 'customer-details.component.html'
})
export class CustomerDetailsComponent implements OnInit, OnDestroy {
    pageTitle: string = 'Customer Details';
    customer: ICustomer;
    errorMessage: string;
    private sub: Subscription;

    constructor(private _route: ActivatedRoute,
        private _router: Router,
        private _customerService: CustomerService) {
    }

    ngOnInit(): void {
        this.sub = this._route.params.subscribe(
            params => {
                let id = params['id'];
                this.getCustomer(id);
            });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    getCustomer(id: string) {
        this._customerService.getCustomerById(id).subscribe(
            customer => this.customer = customer,
            error => this.errorMessage = <any>error);
    }

    onBack(): void {
        this._router.navigate(['/customers-list']);
    }

    
}
