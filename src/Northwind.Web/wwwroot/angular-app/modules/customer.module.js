"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var router_1 = require('@angular/router');
var customer_service_1 = require('../components/customers/customer.service');
var customers_listing_component_1 = require('../components/customers/customers-listing.component');
var customer_details_component_1 = require('../components/customers/customer-details.component');
var customer_guard_service_1 = require('../components/customers/customer-guard-service');
var shared_module_1 = require('./shared.module');
var CustomerModule = (function () {
    function CustomerModule() {
    }
    CustomerModule = __decorate([
        core_1.NgModule({
            imports: [
                shared_module_1.SharedModule,
                router_1.RouterModule.forChild([
                    { path: 'customers-list', component: customers_listing_component_1.CustomersListingComponent },
                    {
                        path: 'customer/:id',
                        canActivate: [customer_guard_service_1.CustomerDetailsGuard],
                        component: customer_details_component_1.CustomerDetailsComponent
                    }
                ])
            ],
            declarations: [
                customers_listing_component_1.CustomersListingComponent,
                customer_details_component_1.CustomerDetailsComponent
            ],
            providers: [
                customer_service_1.CustomerService,
                customer_guard_service_1.CustomerDetailsGuard
            ]
        }), 
        __metadata('design:paramtypes', [])
    ], CustomerModule);
    return CustomerModule;
}());
exports.CustomerModule = CustomerModule;
//# sourceMappingURL=customer.module.js.map