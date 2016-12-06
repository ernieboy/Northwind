"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
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
var customer_service_1 = require("./customer.service");
var base_listing_component_1 = require('../../shared/base.listing.component');
var CustomersListingComponent = (function (_super) {
    __extends(CustomersListingComponent, _super);
    function CustomersListingComponent(_customerService) {
        _super.call(this);
        this._customerService = _customerService;
        this.pageTitle = 'Products Listing';
        this.customersList = {
            customers: null,
            paginationData: null
        };
        this.sortColumn = 'CustomerId';
    }
    CustomersListingComponent.prototype.ngOnInit = function () {
        this.pageData(this.pageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection);
    };
    CustomersListingComponent.prototype.pageData = function (pageNumber, pageSize, searchTerms, sortColumn, sortDirection) {
        var _this = this;
        this.pageNumber = pageNumber;
        this.pageSize = pageSize;
        this.searchTerms = (searchTerms == null ? '' : searchTerms);
        this.sortColumn = sortColumn;
        this.sortDirection = sortDirection;
        this._customerService.getCustomers(this.pageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection)
            .subscribe(function (customersList) { return _this.customersList = customersList; }, function (error) { return _this.errorMessage = error; });
    };
    CustomersListingComponent.prototype.onPageNumberChanged = function (newPageNumber) {
        this.pageNumber = newPageNumber;
        this.pageData(newPageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection);
    };
    CustomersListingComponent.prototype.clearSearch = function () {
        _super.prototype.clearSearch.call(this);
        this.pageData(this.pageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection);
    };
    CustomersListingComponent = __decorate([
        core_1.Component({
            templateUrl: 'angular-app/components/customers/customers-listing.component.html'
        }), 
        __metadata('design:paramtypes', [customer_service_1.CustomerService])
    ], CustomersListingComponent);
    return CustomersListingComponent;
}(base_listing_component_1.BaseListingComponent));
exports.CustomersListingComponent = CustomersListingComponent;
//# sourceMappingURL=customers-listing.component.js.map