import { NgModule } from '@angular/core';
import { RouterModule} from '@angular/router';

import { CustomerService } from '../components/customers/customer.service';
import { CustomersListingComponent } from '../components/customers/customers-listing.component';

import { SharedModule } from '../shared/shared.module';

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild([
            { path: 'customers-list', component: CustomersListingComponent }
        ])
    ],
    declarations: [
        CustomersListingComponent
    ],
    providers: [
        CustomerService
    ]
})
export class CustomerModule { }