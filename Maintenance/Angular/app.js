angular.module('maintenanceApp', ['ui.router', 'ngResource', 'maintenanceApp.controllers', 'maintenanceApp.services']);

angular.module('maintenanceApp').config(function ($stateProvider) {
    $stateProvider.state('tasks', { // state for showing all tasks
        url: '/maintenancetask',
        templateUrl: 'Angular/partials/tasks.html',
        controller: 'TaskListController'
    }).state('viewTask', { //state for showing single task
        url: '/maintenancetask/:id',
        templateUrl: 'Angular/partials/task-view.html',
        controller: 'TaskViewController'
    }).state('newTask', { //state for adding a new movie
        url: '/maintenancetask',
        templateUrl: 'Angular/partials/task-add.html',
        controller: 'TaskCreateController'
    }).state('editTask', { //state for updating a movie
        url: '/maintenancetask/:id',
        templateUrl: 'Angular/partials/task-edit.html',
        controller: 'TaskEditController'
    }).state('gasAutomobiles', { // state for showing all tasks
        url: '/gasautomobile',
        templateUrl: 'Angular/partials/gasautomobiles.html',
        controller: 'GasAutomobileListController'
    }).state('newGasAutomobile', { //state for adding a new movie
        url: '/gasautomobile',
        templateUrl: 'Angular/partials/gasautomobile-add.html',
        controller: 'GasAutomobileCreateController'
    }).state('viewGasAutomobile', { //state for showing single task
        url: '/gasAutomobile/:id',
        templateUrl: 'Angular/partials/gasAutomobile-view.html',
        controller: 'GasAutomobileViewController'
    });
}).run(function ($state) {
    $state.go('gasAutomobiles'); //make a transition to movies state when app starts
});