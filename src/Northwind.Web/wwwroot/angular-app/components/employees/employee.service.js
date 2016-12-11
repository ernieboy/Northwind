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
var http_1 = require('@angular/http');
var Observable_1 = require('rxjs/Observable');
require('rxjs/add/operator/do');
require('rxjs/add/operator/catch');
require('rxjs/add/operator/map');
var config_1 = require('../../shared/config');
var EmployeeService = (function () {
    function EmployeeService(_http) {
        this._http = _http;
    }
    EmployeeService.prototype.getEmployees = function (pageNumber, pageSize, searchTerms, sortColumn, sortDirection) {
        if (pageNumber === void 0) { pageNumber = 1; }
        if (pageSize === void 0) { pageSize = 20; }
        if (searchTerms === void 0) { searchTerms = ''; }
        if (sortColumn === void 0) { sortColumn = 'lastName'; }
        if (sortDirection === void 0) { sortDirection = 'ASC'; }
        var paginationData = '?pageNumber=' + pageNumber +
            '&pageSize=' + pageSize + '&searchTerms=' + searchTerms +
            '&sortCol=' + sortColumn + '&sortDir=' + sortDirection;
        return this._http.get(config_1.Config.apiUrls.employeesListing + paginationData)
            .map(function (response) { return response.json(); })
            .map(this.mapJsonResultToViewObject)
            .do(function (data) { return console.log('All: ' + JSON.stringify(data)); })
            .catch(this.handleError);
    };
    EmployeeService.prototype.mapJsonResultToViewObject = function (result) {
        var employeesList = {
            employees: null,
            paginationData: null
        };
        employeesList.employees = result.list;
        employeesList.paginationData = result.paginationData;
        return employeesList;
    };
    EmployeeService.prototype.getEmployeeById = function (id) {
        var lastIndexOfSlash = config_1.Config.apiUrls.findEmployeeById.lastIndexOf("\/");
        var apiUrl = config_1.Config.apiUrls.findEmployeeById.toString().substring(0, (lastIndexOfSlash + 1)) + id;
        return this._http.get(apiUrl)
            .map(function (response) { return response.json(); })
            .do(function (data) { return console.log('Employee: ' + JSON.stringify(data)); })
            .catch(this.handleError);
    };
    EmployeeService.prototype.handleError = function (error) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable_1.Observable.throw(error.json().error || 'Server error');
    };
    EmployeeService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [(typeof (_a = typeof http_1.Http !== 'undefined' && http_1.Http) === 'function' && _a) || Object])
    ], EmployeeService);
    return EmployeeService;
    var _a;
}());
exports.EmployeeService = EmployeeService;
//# sourceMappingURL=employee.service.js.map