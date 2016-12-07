"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var PaginationComponent = (function () {
    function PaginationComponent() {
        this.numberOfPagesToDisplayOnEitherSideOfCurrentPage = 6;
        this.sortCol = '';
        this.sortDir = 'ASC';
        this.minPageToDisplay = 1;
        this.maxPageToDisplay = 1;
        this.pagesLeftOfCurrentPageArray = [];
        this.pagesRightOfCurrentPageArray = [];
        this.searchTerms = '';
        this.showPaginationControls = false;
        this.pageNumberClicked = new core_1.EventEmitter();
    }
    PaginationComponent.prototype.calculateMinMaxPagesToDisplay = function () {
        this.calculateMinPageToDisplay();
        this.calculateMaxPageToDisplay();
        this.enableConvenienceNavLinks();
    };
    PaginationComponent.prototype.calculateMinPageToDisplay = function () {
        var min = this.pageNumber - this.numberOfPagesToDisplayOnEitherSideOfCurrentPage;
        if (min <= 0) {
            min = 1;
        }
        this.pagesLeftOfCurrentPageArray = [];
        for (var i = min; i < this.pageNumber; i++) {
            this.pagesLeftOfCurrentPageArray.push(i);
        }
    };
    PaginationComponent.prototype.calculateMaxPageToDisplay = function () {
        var max = this.pageNumber + this.numberOfPagesToDisplayOnEitherSideOfCurrentPage;
        if (max > this.totalNumberOfPages) {
            max = this.totalNumberOfPages;
        }
        this.pagesRightOfCurrentPageArray = [];
        for (var i = (this.pageNumber + 1); i <= max; i++) {
            this.pagesRightOfCurrentPageArray.push(i);
        }
    };
    PaginationComponent.prototype.enableConvenienceNavLinks = function () {
        this.showNextLink = (this.pageNumber !== this.totalNumberOfPages);
        this.showPreviousLink = (this.pageNumber > 1);
        this.showLastLink = (this.pageNumber < this.totalNumberOfPages);
        this.showFirstLink = (this.pageNumber > 1);
    };
    PaginationComponent.prototype.ngOnInit = function () {
        this.showPaginationControls = (this.totalNumberOfPages > 1);
        this.calculateMinMaxPagesToDisplay();
    };
    PaginationComponent.prototype.ngOnChanges = function () {
        this.showPaginationControls = (this.totalNumberOfPages > 1);
        this.calculateMinMaxPagesToDisplay();
    };
    PaginationComponent.prototype.onPageClick = function (newPageNumber) {
        this.pageNumber = newPageNumber;
        this.enableConvenienceNavLinks();
        this.pageNumberClicked.emit(this.pageNumber);
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Number)
    ], PaginationComponent.prototype, "pageNumber", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Number)
    ], PaginationComponent.prototype, "pageSize", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Number)
    ], PaginationComponent.prototype, "totalNumberOfRecords", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Number)
    ], PaginationComponent.prototype, "totalNumberOfPages", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Number)
    ], PaginationComponent.prototype, "offsetFromZero", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Number)
    ], PaginationComponent.prototype, "offsetUpperBound", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', String)
    ], PaginationComponent.prototype, "searchTerms", void 0);
    __decorate([
        core_1.Output(), 
        __metadata('design:type', core_1.EventEmitter)
    ], PaginationComponent.prototype, "pageNumberClicked", void 0);
    PaginationComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'pagination-controls',
            templateUrl: "pagination.component.html",
            styleUrls: ["pagination.component.css"]
        }), 
        __metadata('design:paramtypes', [])
    ], PaginationComponent);
    return PaginationComponent;
}());
exports.PaginationComponent = PaginationComponent;
//# sourceMappingURL=pagination.component.js.map