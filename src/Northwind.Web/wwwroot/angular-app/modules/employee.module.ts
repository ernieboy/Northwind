import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { EmployeeService } from '../components/employees/employee.service';
import { EmployeesListingComponent } from '../components/employees/employees-listing.component';


import { SharedModule } from './shared.module';

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: 'employees-list', component: EmployeesListingComponent }
            
        ])
    ],
    declarations: [
        EmployeesListingComponent
   ],
    providers: [
        EmployeeService
    ]
})
export class EmployeeModule { }