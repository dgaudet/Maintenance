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
    }).state('gasAutomobiles', { // state for showing all tasks
        url: '/gasautomobile',
        templateUrl: 'Angular/partials/automobiles.html',
        controller: 'GasAutomobileListController'
    }).state('newGasAutomobile', { //state for adding a new movie
        url: '/gasautomobile',
        templateUrl: 'Angular/partials/automobile-add.html',
        controller: 'GasAutomobileCreateController'
    }).state('viewGasAutomobile', { //state for showing single task
        url: '/gasAutomobile/:id',
        templateUrl: 'Angular/partials/automobile-view.html',
        controller: 'GasAutomobileViewController'
    }).state('electricAutomobiles', {
        url: '/electricautomobile',
        templateUrl: 'Angular/partials/automobiles.html',
        controller: 'ElectricAutomobileListController'
    }).state('newElectricAutomobile', {
        url: '/electricautomobile',
        templateUrl: 'Angular/partials/automobile-add.html',
        controller: 'ElectricAutomobileCreateController'
    }).state('viewElectricAutomobile', {
        url: '/electricAutomobile/:id',
        templateUrl: 'Angular/partials/automobile-view.html',
        controller: 'ElectricAutomobileViewController'
    }).state('dieselAutomobiles', {
        url: '/dieselautomobile',
        templateUrl: 'Angular/partials/automobiles.html',
        controller: 'DieselAutomobileListController'
    }).state('newDieselAutomobile', {
        url: '/dieselautomobile',
        templateUrl: 'Angular/partials/automobile-add.html',
        controller: 'DieselAutomobileCreateController'
    }).state('viewDieselAutomobile', {
        url: '/dieselAutomobile/:id',
        templateUrl: 'Angular/partials/automobile-view.html',
        controller: 'DieselAutomobileViewController'
    });
}).run(function ($state) {
    $state.go('tasks'); //make a transition to movies state when app starts
});