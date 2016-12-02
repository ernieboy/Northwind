"use strict";
//Note, this class should be abstract but if it's made abstract then it can't be listed in the the shared.modules.ts file.
var BaseListingComponent = (function () {
    function BaseListingComponent() {
        this.pageNumber = 1;
        this.pageSize = 10;
        this.searchTerms = '';
        this.sortColumn = 'Name';
        this.sortDirection = 'ASC';
        this.isLoading = true;
    }
    BaseListingComponent.prototype.initPagesArray = function () {
        if (!this.paginationData)
            return;
        this.pagesArray = [];
        for (var i = 1; i <= this.paginationData.totalNumberOfPages; i++) {
            this.pagesArray.push(i);
        }
    };
    BaseListingComponent.prototype.clearSearch = function () {
        this.searchTerms = '';
    };
    return BaseListingComponent;
}());
exports.BaseListingComponent = BaseListingComponent;
//# sourceMappingURL=base.listing.component.js.map