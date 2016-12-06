import { Component, OnChanges, Input,
    Output, EventEmitter, OnInit } from '@angular/core';

@Component({
    selector: 'pagination-controls',
    templateUrl: "angular-app/shared/pagination.component.html",
    styleUrls: ["angular-app/shared/pagination.component.css"]

})
export class PaginationComponent implements OnChanges, OnInit {
    numberOfPagesToDisplayOnEitherSideOfCurrentPage: number = 6;

    sortCol = '';
    sortDir = 'ASC';

    minPageToDisplay: number = 1;
    maxPageToDisplay: number = 1;

    pagesArray: number[];
    pagesLeftOfCurrentPageArray = [];
    pagesRightOfCurrentPageArray = [];
    showNextLink:boolean;
    showPreviousLink: boolean;
    showFirstLink:boolean;
    showLastLink:boolean;

    @Input() pageNumber: number;
    @Input() pageSize: number;
    @Input() totalNumberOfRecords: number;
    @Input() totalNumberOfPages: number;
    @Input() offsetFromZero: number;
    @Input() offsetUpperBound: number;
    @Input() searchTerms: string = '';

    showPaginationControls: boolean = false;

    calculateMinMaxPagesToDisplay(): void {
        this.calculateMinPageToDisplay();
        this.calculateMaxPageToDisplay();
        this.enableConvenienceNavLinks();
    }

    calculateMinPageToDisplay(): void {
        let min: number = this.pageNumber - this.numberOfPagesToDisplayOnEitherSideOfCurrentPage;
        if(min <= 0) { min = 1; }
        this.pagesLeftOfCurrentPageArray = [];
        for (var i = min; i < this.pageNumber; i++) {
            this.pagesLeftOfCurrentPageArray.push(i);
        }
    }    

    calculateMaxPageToDisplay(): void {
        let max: number = this.pageNumber + this.numberOfPagesToDisplayOnEitherSideOfCurrentPage;
        if(max > this.totalNumberOfPages) {
            max = this.totalNumberOfPages;
        }
        this.pagesRightOfCurrentPageArray = [];
        for (var i = (this.pageNumber+1); i <= max; i++) {
            this.pagesRightOfCurrentPageArray.push(i);
        }
    }

    enableConvenienceNavLinks() : void {
        this.showNextLink = (this.pageNumber !== this.totalNumberOfPages);
        this.showPreviousLink = (this.pageNumber > 1);
        this.showLastLink = (this.pageNumber < this.totalNumberOfPages);
        this.showFirstLink = (this.pageNumber > 1);
    }

    ngOnInit(): void {
        this.showPaginationControls = (this.totalNumberOfPages > 1);
        this.calculateMinMaxPagesToDisplay();
    }

    ngOnChanges(): void {
        this.showPaginationControls = (this.totalNumberOfPages > 1);
        this.calculateMinMaxPagesToDisplay();
    }
    
    @Output() pageNumberClicked: EventEmitter<number> = new EventEmitter<number>();

    onPageClick(newPageNumber: number): void {
        this.pageNumber = newPageNumber;
        this.enableConvenienceNavLinks();
        this.pageNumberClicked.emit(this.pageNumber);
    }

}