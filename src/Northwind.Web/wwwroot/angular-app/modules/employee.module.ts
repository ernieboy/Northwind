import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { EmployeeService } from '../components/employees/employee.service';
import { EmployeesListingComponent } from '../components/employees/employees-listing.component';
import { EmployeeDetailsComponent } from '../components/employees/employee-details.component';
import { EmployeeDetailsGuard } from '../components/employees/employee-guard-service';


import { SharedModule } from './shared.module';

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: 'employees-list', component: EmployeesListingComponent },
            {
                path: 'employee/:id',
                canActivate: [EmployeeDetailsGuard],
                component: EmployeeDetailsComponent
            }
            
        ])
    ],
    declarations: [
        EmployeesListingComponent, EmployeeDetailsComponent
   ],
    providers: [
        EmployeeService, EmployeeDetailsGuard
    ]
})
export class EmployeeModule { }