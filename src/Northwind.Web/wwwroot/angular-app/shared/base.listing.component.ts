import {IPaginationData} from "./interfaces/IPaginationData"

export abstract class BaseListingComponent {

    protected paginationData: IPaginationData;

    protected pageNumber: number = 1;
    protected pageSize: number = 10;
    protected searchTerms: string = '';
    protected sortColumn: string = 'Name';
    protected sortDirection: string = 'ASC';

    
    protected pagesArray: number[];

    protected errorMessage: string;
    protected isLoading: boolean = true;  

    constructor() {

    }

    protected initPagesArray(): void {
        if (!this.paginationData) return;
        this.pagesArray = [];
        for (var i = 1; i <= this.paginationData.totalNumberOfPages; i++) {
            this.pagesArray.push(i);
        }
    }

    protected clearSearch(): void {
        this.searchTerms = '';        
    }
}