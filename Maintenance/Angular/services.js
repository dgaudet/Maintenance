angular.module('maintenanceApp.services', []).factory('Task', function ($resource) {
    return $resource('http://localhost:52970/api/maintenancetask/:id', { id: '@_id' }, {
        update: {
            method: 'PUT'
        }
    });
});

angular.module('maintenanceApp.services').factory('GasAutomobile', function ($resource) {
    return $resource('http://localhost:52970/api/gasautomobile/:id', { id: '@_id' }, {
        update: {
            method: 'PUT'
        }
    });
});

angular.module('maintenanceApp.services').service('popupService', ['$window', function ($window) {
    this.showPopup = function (message) {
        return $window.confirm(message); //Ask the users if they really want to delete
    }
}]);