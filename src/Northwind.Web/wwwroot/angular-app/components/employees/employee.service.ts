import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { Config } from '../../shared/config';
import { IEmployee } from "./IEmployee";
import { IEmployeesList } from "./IEmployeesList";
import { IPaginationData } from "../../shared/interfaces/IPaginationData"

@Injectable()
export class EmployeeService {

    constructor(private _http: Http) { }

    getEmployees(pageNumber: number = 1,
        pageSize: number = 20,
        searchTerms: string = '',
        sortColumn: string = 'lastName',
        sortDirection: string = 'ASC'): Observable<IEmployeesList> {

        let paginationData: string = '?pageNumber=' + pageNumber +
            '&pageSize=' + pageSize + '&searchTerms=' + searchTerms +
            '&sortCol=' + sortColumn + '&sortDir=' + sortDirection;

        return this._http.get(Config.apiUrls.employeesListing + paginationData)
            .map((response: Response) => response.json())
            .map(this.mapJsonResultToViewObject)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    mapJsonResultToViewObject(result) {
        let employeesList: IEmployeesList = {
            employees: null,
            paginationData: null
        };
        employeesList.employees = <IEmployee[]>result.list;
        employeesList.paginationData = <IPaginationData>result.paginationData;
        return employeesList;
    }

    getEmployeeById(id: string): Observable<IEmployee> {
        let lastIndexOfSlash: number = Config.apiUrls.findEmployeeById.lastIndexOf("\/");
        let apiUrl: string = Config.apiUrls.findEmployeeById.toString().substring(0, (lastIndexOfSlash + 1)) + id;
        return this._http.get(apiUrl)
            .map((response: Response) => <IEmployee>response.json())
            .do(data => console.log('Employee: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }



    private handleError(error: Response) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }


}