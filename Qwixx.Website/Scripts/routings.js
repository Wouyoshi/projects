(function () {
    "use strict";
    var app = angular.module("qwixx", ["ngRoute", "qwixxGameOverview", "gameUtilities"]);
    
    app.config(['$routeProvider',
      function ($routeProvider) {
          $routeProvider.
            when('/', {
                templateUrl: 'game-overview.html',
                controller: 'gameOverviewController'
            }).
            when('/:id', {
                templateUrl: 'qwixx-game.html',
                controller: 'qwixxCardController'
            });
      }]);
})();