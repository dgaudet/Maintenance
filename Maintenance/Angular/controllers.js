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

maintenanceApp.controller('GasAutomobileListController', function ($scope, $state, $window, GasAutomobile) {
    $scope.gasAutomobiles = GasAutomobile.query();
}).controller('GasAutomobileCreateController', function ($scope, $state, $stateParams, GasAutomobile) {
    $scope.gasAutomobile = new GasAutomobile();  //create new task instance. Properties will be set via ng-model on UI

    $scope.addGasAutomobile = function () { //create a new task. Issues a POST to /api/tasks
        $scope.gasAutomobile.$save(function () {
            $state.go('gasAutomobiles'); // on success go back to home i.e. tasks state.
        });
    };
}).controller('GasAutomobileViewController', function ($scope, $state, $stateParams, popupService, GasAutomobile) {
    $scope.gasAutomobile = GasAutomobile.get({ id: $stateParams.id });

    $scope.deleteAutomobile = function (id) { // Delete a task. Issues a DELETE to /api/tasks/:id
        if (popupService.showPopup('Really delete this?')) {
            GasAutomobile.remove(id);
            $state.go('gasAutomobiles');
        }
    };
});

maintenanceApp.controller('ElectricAutomobileListController', function ElectricAutomobileListController($scope, $state, $window, ElectricAutomobile) {
    $scope.electricAutomobiles = ElectricAutomobile.query();
}).controller('ElectricAutomobileViewController', function ElectricAutomobileViewController($scope, $state, $stateParams, popupService, ElectricAutomobile) {
    $scope.electricAutomobile = ElectricAutomobile.get({ id: $stateParams.id });

    $scope.deleteAutomobile = function (id) { // Delete a task. Issues a DELETE to /api/tasks/:id
        if (popupService.showPopup('Really delete this?')) {
            ElectricAutomobile.remove(id);
            $state.go('electricAutomobiles');
        }
    };
}).controller('ElectricAutomobileCreateController', function ElectricAutomobileCreateController($scope, $state, $stateParams, ElectricAutomobile) {
    $scope.electricAutomobile = new ElectricAutomobile();  //create new task instance. Properties will be set via ng-model on UI

    $scope.addElectricAutomobile = function () {
        $scope.electricAutomobile.$save(function () {
            $state.go('electricAutomobiles');
        });
    };
})