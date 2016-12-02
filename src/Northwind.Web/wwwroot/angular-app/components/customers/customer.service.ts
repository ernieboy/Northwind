import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { Config } from '../../shared/config';
import { ICustomer } from "./customer";
import { ICustomerList } from "./ICustomerList";
import { IPaginationData } from "../../shared/interfaces/IPaginationData"

@Injectable()
export class CustomerService {

    constructor(private _http: Http) { }

    getCustomers(pageNumber: number = 1,
        pageSize: number = 20,
        searchTerms: string = '',
        sortColumn: string = 'Name',
        sortDirection: string = 'ASC'): Observable<ICustomerList>{

        let paginationData: string = '?pageNumber=' + pageNumber +
            '&pageSize=' + pageSize + '&searchTerms=' + searchTerms +
            '&sortCol=' + sortColumn + '&sortDir=' + sortDirection;

        return this._http.get(Config.apiUrls.customersListing + paginationData)
            .map((response: Response) => response.json())
            .map(this.mapJsonResultToViewObject)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    mapJsonResultToViewObject(result) {
        let customersList: ICustomerList = {
            customers: null,
            paginationData: null
        };
        customersList.customers = <ICustomer[]>result.list;
       customersList.paginationData = <IPaginationData>result.paginationData;
        return customersList;
    }



    private handleError(error: Response) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

   
}