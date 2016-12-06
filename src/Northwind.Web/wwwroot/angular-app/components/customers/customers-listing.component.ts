import { Component, OnInit }  from '@angular/core';
import {ICustomer} from "./customer";
import {CustomerService} from "./customer.service";
import {IPaginationData} from "../../shared/interfaces/IPaginationData"
import { BaseListingComponent } from '../../shared/base.listing.component';
import { ICustomerList } from "./ICustomerList";


@Component({
    templateUrl: 'angular-app/components/customers/customers-listing.component.html'
})
export class CustomersListingComponent extends BaseListingComponent implements OnInit {
    pageTitle: string = 'Products Listing';

      customersList: ICustomerList = {
        customers: null,
        paginationData: null
    };

    constructor(private _customerService: CustomerService) {
        super();
        this.sortColumn = 'CustomerId';
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
        
        this._customerService.getCustomers(this.pageNumber,
            this.pageSize,
            this.searchTerms,
            this.sortColumn,
            this.sortDirection)
            .subscribe(customersList => this.customersList = customersList,
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
