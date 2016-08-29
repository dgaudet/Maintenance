var maintenanceApp = angular.module('maintenanceApp.controllers', []).controller('TaskListController', function ($scope, $state, popupService, $window, Task) {
    $scope.tasks = Task.query(); //fetch all tasks. Issues a GET to /api/tasks

    $scope.deleteTask = function (task) { // Delete a task. Issues a DELETE to /api/tasks/:id
        if (popupService.showPopup('Really delete this?')) {
            task.$delete(function () {
                $window.location.href = ''; //redirect to home
            });
        }
    };
}).controller('TaskViewController', function ($scope, $stateParams, Task) {
    $scope.task = Task.get({ id: $stateParams.id }); //Get a single task.Issues a GET to /api/tasks/:id
}).controller('TaskCreateController', function ($scope, $state, $stateParams, Task) {
    $scope.task = new Task();  //create new task instance. Properties will be set via ng-model on UI

    $scope.addTask = function () { //create a new task. Issues a POST to /api/tasks
        $scope.task.$save(function () {
            $state.go('tasks'); // on success go back to home i.e. tasks state.
        });
    };
}).controller('TaskEditController', function ($scope, $state, $stateParams, Task) {
    $scope.updateTask = function () { //Update the edited task. Issues a PUT to /api/tasks/:id
        $scope.task.$update(function () {
            $state.go('tasks'); // on success go back to home i.e. tasks state.
        });
    };

    $scope.loadTask = function () { //Issues a GET request to /api/tasks/:id to get a task to update
        $scope.task = Task.get({ id: $stateParams.id });
    };

    $scope.loadTask(); // Load a task which can be edited on UI
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
}).controller('GasAutomobileViewController', function ($scope, $stateParams, GasAutomobile) {
    $scope.gasAutomobile = GasAutomobile.get({ id: $stateParams.id });
});

maintenanceApp.controller('ElectricAutomobileListController', function ElectricAutomobileListController($scope, $state, $window, ElectricAutomobile) {
    $scope.electricAutomobiles = ElectricAutomobile.query();
}).controller('ElectricAutomobileViewController', function ElectricAutomobileViewController($scope, $stateParams, ElectricAutomobile) {
    $scope.electricAutomobile = ElectricAutomobile.get({ id: $stateParams.id });
}).controller('ElectricAutomobileCreateController', function ElectricAutomobileCreateController($scope, $state, $stateParams, ElectricAutomobile) {
    $scope.electricAutomobile = new ElectricAutomobile();  //create new task instance. Properties will be set via ng-model on UI

    $scope.addElectricAutomobile = function () {
        $scope.electricAutomobile.$save(function () {
            $state.go('electricAutomobiles');
        });
    };
})