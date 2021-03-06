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
var customer_service_1 = require("./customer.service");
var CustomerDetailsComponent = (function () {
    function CustomerDetailsComponent(_route, _router, _customerService) {
        this._route = _route;
        this._router = _router;
        this._customerService = _customerService;
        this.pageTitle = 'Customer Details';
    }
    CustomerDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.sub = this._route.params.subscribe(function (params) {
            var id = params['id'];
            _this.getCustomer(id);
        });
    };
    CustomerDetailsComponent.prototype.ngOnDestroy = function () {
        this.sub.unsubscribe();
    };
    CustomerDetailsComponent.prototype.getCustomer = function (id) {
        var _this = this;
        this._customerService.getCustomerById(id).subscribe(function (customer) { return _this.customer = customer; }, function (error) { return _this.errorMessage = error; });
    };
    CustomerDetailsComponent.prototype.onBack = function () {
        this._router.navigate(['/customers-list']);
    };
    CustomerDetailsComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            templateUrl: 'customer-details.component.html'
        }), 
        __metadata('design:paramtypes', [(typeof (_a = typeof router_1.ActivatedRoute !== 'undefined' && router_1.ActivatedRoute) === 'function' && _a) || Object, (typeof (_b = typeof router_1.Router !== 'undefined' && router_1.Router) === 'function' && _b) || Object, (typeof (_c = typeof customer_service_1.CustomerService !== 'undefined' && customer_service_1.CustomerService) === 'function' && _c) || Object])
    ], CustomerDetailsComponent);
    return CustomerDetailsComponent;
    var _a, _b, _c;
}());
exports.CustomerDetailsComponent = CustomerDetailsComponent;
//# sourceMappingURL=customer-details.component.js.map