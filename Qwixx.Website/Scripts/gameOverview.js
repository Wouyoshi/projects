(function () {
    "use strict";
    var app = angular.module("qwixx");

    
    app.controller("gameOverviewController", [
        "$scope", function ($scope) {
            $scope.player = {
                playerName: ""
            };
            $scope.game = {
                gameName: "",
                maxPlayerCount: 5
            };

            $scope.tiles =
                [{ playerCount: 3, maxPlayerCount: 5, hostName: "Host name", gameName: "Game name", tileClass: "tile-1", dieColor: "red" },
                 { playerCount: 1, maxPlayerCount: 5, hostName: "Cool host", gameName: "Awesome game", tileClass: "tile-2", dieColor: "yellow" },
                 { playerCount: 3, maxPlayerCount: 5, hostName: "Pipo de Clown", gameName: "Super game", tileClass: "tile-4", dieColor: "blue" },
                 { playerCount: 3, maxPlayerCount: 5, hostName: "Hostie", gameName: "Tostie", tileClass: "tile-3", dieColor: "green" },
                 { playerCount: 3, maxPlayerCount: 5, hostName: "Hostie de Hostname", gameName: "Gostie de game name", tileClass: "tile-3", dieColor: "green" }];
            $scope.addGame = function() {
                $scope.tiles.push({ playerCount: 1, maxPlayerCount: this.game.maxPlayerCount, hostName: this.player.playerName, gameName: this.game.gameName, tileClass: "tile-1", dieColor: "red" });
            };
        }
    ]);
    app.directive("gameOverview", function () {
        return {
            restrict: "E",
            templateUrl: "game-overview.html",
            controller: "gameOverviewController"
        };
    });
})();