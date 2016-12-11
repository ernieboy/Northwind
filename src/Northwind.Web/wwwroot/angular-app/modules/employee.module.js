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
var employee_service_1 = require('../components/employees/employee.service');
var employees_listing_component_1 = require('../components/employees/employees-listing.component');
var employee_details_component_1 = require('../components/employees/employee-details.component');
var employee_guard_service_1 = require('../components/employees/employee-guard-service');
var shared_module_1 = require('./shared.module');
var EmployeeModule = (function () {
    function EmployeeModule() {
    }
    EmployeeModule = __decorate([
        core_1.NgModule({
            imports: [
                shared_module_1.SharedModule,
                router_1.RouterModule.forChild([
                    { path: 'employees-list', component: employees_listing_component_1.EmployeesListingComponent },
                    {
                        path: 'employee/:id',
                        canActivate: [employee_guard_service_1.EmployeeDetailsGuard],
                        component: employee_details_component_1.EmployeeDetailsComponent
                    }
                ])
            ],
            declarations: [
                employees_listing_component_1.EmployeesListingComponent, employee_details_component_1.EmployeeDetailsComponent
            ],
            providers: [
                employee_service_1.EmployeeService, employee_guard_service_1.EmployeeDetailsGuard
            ]
        }), 
        __metadata('design:paramtypes', [])
    ], EmployeeModule);
    return EmployeeModule;
}());
exports.EmployeeModule = EmployeeModule;
//# sourceMappingURL=employee.module.js.map