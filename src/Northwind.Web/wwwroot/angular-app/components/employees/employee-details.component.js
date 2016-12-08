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
var employee_service_1 = require("./employee.service");
var EmployeeDetailsComponent = (function () {
    function EmployeeDetailsComponent(_route, _router, _employeeService) {
        this._route = _route;
        this._router = _router;
        this._employeeService = _employeeService;
        this.pageTitle = 'Employee Details';
    }
    EmployeeDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.sub = this._route.params.subscribe(function (params) {
            var id = params['id'];
            _this.getEmployee(id);
        });
    };
    EmployeeDetailsComponent.prototype.ngOnDestroy = function () {
        this.sub.unsubscribe();
    };
    EmployeeDetailsComponent.prototype.getEmployee = function (id) {
        var _this = this;
        this._employeeService.getEmployeeById(id).subscribe(function (employee) { return _this.employee = employee; }, function (error) { return _this.errorMessage = error; });
    };
    EmployeeDetailsComponent.prototype.onBack = function () {
        this._router.navigate(['/employees-list']);
    };
    EmployeeDetailsComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            templateUrl: 'employee-details.component.html'
        }), 
        __metadata('design:paramtypes', [router_1.ActivatedRoute, router_1.Router, employee_service_1.EmployeeService])
    ], EmployeeDetailsComponent);
    return EmployeeDetailsComponent;
}());
exports.EmployeeDetailsComponent = EmployeeDetailsComponent;
//# sourceMappingURL=employee-details.component.js.map