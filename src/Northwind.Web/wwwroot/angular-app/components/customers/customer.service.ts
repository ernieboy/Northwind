import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';
import { Http, Response } from '@angular/http';

import {ICustomer} from "./customer";

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import {Config} from '../../shared/config';

@Injectable()
export class CustomerService {

    constructor(@Inject(Http) _http: Http) { }

    getCustomers(pageNumber: number = 1,
        pageSize: number = 20,
        searchTerms: string = '',
        sortColumn: string = 'Name',
        sortDirection: string = 'ASC'): Observable<ICustomer[]>{
        return "";
    }



    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return "";
    }

   
}