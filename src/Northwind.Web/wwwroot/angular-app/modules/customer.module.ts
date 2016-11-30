import { NgModule } from '@angular/core';
import { RouterModule} from '@angular/router';

import { CustomerService } from '../components/customers/customer.service';
import { CustomersListingComponent } from '../components/customers/customers-listing.component';

@NgModule({
    imports: [
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