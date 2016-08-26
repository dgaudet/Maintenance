function Hello($scope, $http) {
    $http.get('http://rest-service.guides.spring.io/greeting').
        success(function (data) {
            $scope.greeting = data;
        });
}

angular.module('greeting1', ['greetingRetriever1']).controller('GreetingController', ['greetingRetriever', function GreetingController(greetingRetriever) {
    this.id = 'test id';
    this.content = 'hello content';

    this.data = function data() {
        window.alert('hello ' + greetingRetriever.data);
    };
}]);

angular.module('greetingRetriever1', []).factory('greetingRetriever', ['$http', function ($http) {
    var url = 'http://rest-service.guides.spring.io/greeting';
    var refresh = function () {
        return $http.get(url).then(function (response) {
            response.data;
        });
    };

    var data = refresh();

    return {
        data: data
    };
}]);