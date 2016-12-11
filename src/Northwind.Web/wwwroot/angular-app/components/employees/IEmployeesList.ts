import { IEmployee } from "./IEmployee";
import { IPaginationData } from "../../shared/interfaces/IPaginationData"

export interface IEmployeesList {
    employees: IEmployee[];
    paginationData: IPaginationData;
    
}