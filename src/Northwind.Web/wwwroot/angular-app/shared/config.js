"use strict";
var appRoot = thisApplication.rootPath + '/';
var apiRoot = appRoot + 'api/';
exports.Config = {
    pageActions: {
        list: 0,
        edit: 1,
        delete: 2,
        add: 3
    },
    apiUrls: {
        customersListing: apiRoot + 'customers',
        findCustomerById: apiRoot + 'customers' + '/{id}',
        employeesListing: apiRoot + 'employees',
        findEmployeeById: apiRoot + 'employees' + '/{id}'
    },
    entityFrameworkEntityState: {
        Unchanged: 0,
        Added: 1,
        Modified: 2,
        Deleted: 3
    }
};
//# sourceMappingURL=config.js.map