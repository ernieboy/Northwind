import { NgModule } from '@angular/core';
import { RouterModule} from '@angular/router';

import { CutomersListingComponent } from '../components/customers/customers-listing.component';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: 'customers-list', component: CutomersListingComponent }
        ])
    ],
    declarations: [
        CutomersListingComponent
    ],
    providers: [
    ]
})
export class CustomerModule { }