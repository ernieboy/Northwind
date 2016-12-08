declare var thisApplication: any;
var appRoot: string = thisApplication.rootPath + '/';
var apiRoot: string = appRoot + 'api/';
export let Config = {
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
}