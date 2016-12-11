import { Component, OnInit } from '@angular/core';
import { IEmployee } from "./IEmployee";
import { EmployeeService } from "./employee.service";
import { IPaginationData } from "../../shared/interfaces/IPaginationData"
import { BaseListingComponent } from '../shared/base.listing.component';
import { IEmployeesList } from "./IEmployeesList";


@Component({
        moduleId: module.id,
        templateUrl: 'employees-listing.component.html'
    })
export class EmployeesListingComponent extends BaseListingComponent implements OnInit {
    pageTitle: string = 'Employees Listing';

    employeesList: IEmployeesList = {
        employees: null,
        paginationData: null
    };

    constructor(private _employeeService: EmployeeService) {
        super();
        this.sortColumn = 'EmployeeId';
        this.pageSize = 5;
    }

    ngOnInit(): void {
        this.pageData(this.pageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection);
    }

    pageData(pageNumber: number, pageSize: number, searchTerms: string,
        sortColumn: string, sortDirection: string): void {
        this.pageNumber = pageNumber;
        this.pageSize = pageSize;
        this.searchTerms = (searchTerms == null ? '' : searchTerms);
        this.sortColumn = sortColumn;
        this.sortDirection = sortDirection;

        this._employeeService.getEmployees(this.pageNumber,
            this.pageSize,
            this.searchTerms,
            this.sortColumn,
            this.sortDirection)
            .subscribe(employeesList => this.employeesList = employeesList,
            error => this.errorMessage = <any>error);
    }

    onPageNumberChanged(newPageNumber: number): void {
        this.pageNumber = newPageNumber;
        this.pageData(newPageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection);
    }

    protected clearSearch(): void {
        super.clearSearch();
        this.pageData(this.pageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection);
    }





}
