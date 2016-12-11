import { ICustomer } from "./customer";
import { IPaginationData } from "../../shared/interfaces/IPaginationData"

export interface ICustomerList {
    customers: ICustomer[];
    paginationData: IPaginationData;
    
}