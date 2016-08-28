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
        url: '/movies/new',
        templateUrl: 'Angular/partials/movie-add.html',
        controller: 'TaskCreateController'
    }).state('editTask', { //state for updating a movie
        url: '/movies/:id/edit',
        templateUrl: 'Angular/partials/movie-edit.html',
        controller: 'TaskEditController'
    });
}).run(function ($state) {
    $state.go('tasks'); //make a transition to movies state when app starts
});