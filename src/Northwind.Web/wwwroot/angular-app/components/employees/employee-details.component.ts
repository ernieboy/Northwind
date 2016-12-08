import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription } from 'rxjs/Subscription';

import { IEmployee } from "./IEmployee";
import { EmployeeService } from "./employee.service";

@Component({
    moduleId: module.id,
    templateUrl: 'employee-details.component.html'
})
export class EmployeeDetailsComponent implements OnInit, OnDestroy {
    pageTitle: string = 'Employee Details';
    employee: IEmployee;
    errorMessage: string;
    private sub: Subscription;

    constructor(private _route: ActivatedRoute,
        private _router: Router,
        private _employeeService: EmployeeService) {
    }

    ngOnInit(): void {
        this.sub = this._route.params.subscribe(
            params => {
                let id = params['id'];
                this.getEmployee(id);
            });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    getEmployee(id: string) {
        this._employeeService.getEmployeeById(id).subscribe(
            employee => this.employee = employee,
            error => this.errorMessage = <any>error);
    }

    onBack(): void {
        this._router.navigate(['/employees-list']);
    }

    
}
