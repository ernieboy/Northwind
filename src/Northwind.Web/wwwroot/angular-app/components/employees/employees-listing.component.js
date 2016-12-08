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
var employee_service_1 = require("./employee.service");
var base_listing_component_1 = require('../shared/base.listing.component');
var EmployeesListingComponent = (function (_super) {
    __extends(EmployeesListingComponent, _super);
    function EmployeesListingComponent(_employeeService) {
        _super.call(this);
        this._employeeService = _employeeService;
        this.pageTitle = 'Employees Listing';
        this.employeesList = {
            employees: null,
            paginationData: null
        };
        this.sortColumn = 'EmployeeId';
        this.pageSize = 5;
    }
    EmployeesListingComponent.prototype.ngOnInit = function () {
        this.pageData(this.pageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection);
    };
    EmployeesListingComponent.prototype.pageData = function (pageNumber, pageSize, searchTerms, sortColumn, sortDirection) {
        var _this = this;
        this.pageNumber = pageNumber;
        this.pageSize = pageSize;
        this.searchTerms = (searchTerms == null ? '' : searchTerms);
        this.sortColumn = sortColumn;
        this.sortDirection = sortDirection;
        this._employeeService.getEmployees(this.pageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection)
            .subscribe(function (employeesList) { return _this.employeesList = employeesList; }, function (error) { return _this.errorMessage = error; });
    };
    EmployeesListingComponent.prototype.onPageNumberChanged = function (newPageNumber) {
        this.pageNumber = newPageNumber;
        this.pageData(newPageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection);
    };
    EmployeesListingComponent.prototype.clearSearch = function () {
        _super.prototype.clearSearch.call(this);
        this.pageData(this.pageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection);
    };
    EmployeesListingComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            templateUrl: 'employees-listing.component.html'
        }), 
        __metadata('design:paramtypes', [employee_service_1.EmployeeService])
    ], EmployeesListingComponent);
    return EmployeesListingComponent;
}(base_listing_component_1.BaseListingComponent));
exports.EmployeesListingComponent = EmployeesListingComponent;
//# sourceMappingURL=employees-listing.component.js.map