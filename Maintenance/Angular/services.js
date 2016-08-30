angular.module('maintenanceApp.services', []).factory('Task', function ($resource) {
    return $resource('http://localhost:52970/api/maintenancetask/:id');
});

angular.module('maintenanceApp.services').factory('GasAutomobile', function ($resource) {
    return $resource('http://localhost:52970/api/gasautomobile/:id');
});

angular.module('maintenanceApp.services').factory('ElectricAutomobile', function ($resource) {
    return $resource('http://localhost:52970/api/electricautomobile/:id');
});

angular.module('maintenanceApp.services').factory('DieselAutomobile', function ($resource) {
    return $resource('http://localhost:52970/api/dieselautomobile/:id');
});


angular.module('maintenanceApp.services').service('popupService', ['$window', function ($window) {
    this.showPopup = function (message) {
        return $window.confirm(message); //Ask the users if they really want to delete
    }
}]);