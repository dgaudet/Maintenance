var maintenanceApp = angular.module('maintenanceApp.controllers', []).controller('TaskListController', function ($scope, $state, $window, Task) {
    $scope.tasks = Task.query(); //fetch all tasks. Issues a GET to /api/tasks
}).controller('TaskViewController', function ($scope, $state, $stateParams, popupService, Task) {
    $scope.task = Task.get({ id: $stateParams.id }); //Get a single task.Issues a GET to /api/tasks/:id

    $scope.deleteTask = function (id) { // Delete a task. Issues a DELETE to /api/tasks/:id
        if (popupService.showPopup('Really delete this?')) {
            Task.remove(id);
            $state.go('tasks');
        }
    };
}).controller('TaskCreateController', function ($scope, $state, $stateParams, Task) {
    $scope.task = new Task();  //create new task instance. Properties will be set via ng-model on UI

    $scope.addTask = function () { //create a new task. Issues a POST to /api/tasks
        $scope.task.$save(function () {
            $state.go('tasks'); // on success go back to home i.e. tasks state.
        });
    };
});

maintenanceApp.controller('GasAutomobileListController', function ($scope, $state, $window, GasAutomobileService) {
    $scope.automobiles = GasAutomobileService.query();
    $scope.automobileType = 'Gas';
    $scope.addAutomobileState = 'newGasAutomobile';
    $scope.viewAutomobileState = 'viewGasAutomobile';
}).controller('GasAutomobileCreateController', function ($scope, $state, $stateParams, GasAutomobileService) {
    $scope.gasAutomobile = new GasAutomobileService();  //create new task instance. Properties will be set via ng-model on UI

    $scope.addGasAutomobile = function () { //create a new task. Issues a POST to /api/tasks
        $scope.gasAutomobile.$save(function () {
            $state.go('gasAutomobiles'); // on success go back to home i.e. tasks state.
        });
    };
}).controller('GasAutomobileViewController', function ($scope, $state, $stateParams, popupService, GasAutomobileService) {
    $scope.gasAutomobile = GasAutomobileService.get({ id: $stateParams.id });

    $scope.deleteAutomobile = function (id) { // Delete a task. Issues a DELETE to /api/tasks/:id
        if (popupService.showPopup('Really delete this?')) {
            GasAutomobileService.remove(id);
            $state.go('gasAutomobiles');
        }
    };
});

maintenanceApp.controller('ElectricAutomobileListController', function ElectricAutomobileListController($scope, $state, $window, ElectricAutomobileService) {
    $scope.automobiles = ElectricAutomobileService.query();
    $scope.automobileType = 'Electric';
    $scope.addAutomobileState = 'newElectricAutomobile';
    $scope.viewAutomobileState = 'viewElectricAutomobile';
}).controller('ElectricAutomobileViewController', function ElectricAutomobileViewController($scope, $state, $stateParams, popupService, ElectricAutomobileService) {
    $scope.electricAutomobile = ElectricAutomobileService.get({ id: $stateParams.id });

    $scope.deleteAutomobile = function (id) { // Delete a task. Issues a DELETE to /api/tasks/:id
        if (popupService.showPopup('Really delete this?')) {
            ElectricAutomobileService.remove(id);
            $state.go('electricAutomobiles');
        }
    };
}).controller('ElectricAutomobileCreateController', function ElectricAutomobileCreateController($scope, $state, $stateParams, ElectricAutomobileService) {
    $scope.electricAutomobile = new ElectricAutomobileService();  //create new task instance. Properties will be set via ng-model on UI

    $scope.addElectricAutomobile = function () {
        $scope.electricAutomobile.$save(function () {
            $state.go('electricAutomobiles');
        });
    };
})

maintenanceApp.controller('DieselAutomobileListController', function DieselAutomobileListController($scope, $state, $window, DieselAutomobileService) {
    $scope.automobiles = DieselAutomobileService.query();
    $scope.automobileType = 'Diesel';
    $scope.addAutomobileState = 'newDieselAutomobile';
    $scope.viewAutomobileState = 'viewDieselAutomobile';
}).controller('DieselAutomobileViewController', function DieselAutomobileViewController($scope, $state, $stateParams, popupService, DieselAutomobileService) {
    $scope.dieselAutomobile = DieselAutomobileService.get({ id: $stateParams.id });

    $scope.deleteAutomobile = function (id) { // Delete a task. Issues a DELETE to /api/tasks/:id
        if (popupService.showPopup('Really delete this?')) {
            DieselAutomobileService.remove(id);
            $state.go('dieselAutomobiles');
        }
    };
}).controller('DieselAutomobileCreateController', function DieselAutomobileCreateController($scope, $state, $stateParams, DieselAutomobileService) {
    $scope.dieselAutomobile = new DieselAutomobileService();  //create new task instance. Properties will be set via ng-model on UI

    $scope.addDieselAutomobile = function () {
        $scope.dieselAutomobile.$save(function () {
            $state.go('dieselAutomobiles');
        });
    };
})