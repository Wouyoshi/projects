﻿(function() {
    "use strict";
    var app = angular.module("gameUtilities");

    app.directive("gameTile", function () {
        return {
            restrict: "E",
            templateUrl: "game-tile.html",
            scope: {
                playerCount: "=",
                maxPlayerCount: "=",
                gameName: "=",
                hostName: "=",
                dieColor: "=",
                tileClass: "="
            }
        };
    });
})();