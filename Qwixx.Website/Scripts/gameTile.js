(function() {
    "use strict";
    var app = angular.module("qwixx");

    app.directive("gameTile", function () {
        return {
            restrict: "E",
            templateUrl: "game-tile.html",
            scope: {
                playerCount: "=",
                maxPlayerCount: "=",
                gameName: "=",
                hostName: "="
            }
        };
    });
})();