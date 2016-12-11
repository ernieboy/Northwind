import { NgModule } from '@angular/core';
import { RouterModule} from '@angular/router';

import { CustomerService } from '../components/customers/customer.service';
import { CustomersListingComponent } from '../components/customers/customers-listing.component';
import { CustomerDetailsComponent } from '../components/customers/customer-details.component';
import { CustomerDetailsGuard } from '../components/customers/customer-guard-service';


import { SharedModule } from './shared.module';

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: 'customers-list', component: CustomersListingComponent },
            {
                path: 'customer/:id',
                canActivate: [CustomerDetailsGuard],
                component: CustomerDetailsComponent
            }
        ])
    ],
    declarations: [
        CustomersListingComponent,
        CustomerDetailsComponent
    ],
    providers: [
        CustomerService,
        CustomerDetailsGuard
    ]
})
export class CustomerModule { }