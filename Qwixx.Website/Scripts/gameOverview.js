(function () {
    "use strict";
    var app = angular.module("qwixx");


    
    app.controller("gameOverviewController", [
        "$scope", "gameListService", function ($scope, gameListService) {
            $scope.player = {
                playerName: ""
            };
            $scope.game = {
                gameName: "",
                maxPlayerCount: 5
            };

            $scope.gameList = gameListService;

            $scope.tiles = gameListService.getGames();
               /* [{ playerCount: 3, maxPlayerCount: 5, hostName: "Host name", gameName: "Game name", tileClass: "tile-1", dieColor: "red", players: [] },
                 { playerCount: 1, maxPlayerCount: 5, hostName: "Cool host", gameName: "Awesome game", tileClass: "tile-2", dieColor: "yellow", players: [] },
                 { playerCount: 3, maxPlayerCount: 5, hostName: "Pipo de Clown", gameName: "Super game", tileClass: "tile-4", dieColor: "blue", players: [] },
                 { playerCount: 3, maxPlayerCount: 5, hostName: "Hostie", gameName: "Tostie", tileClass: "tile-3", dieColor: "green", players: [] },
                 { playerCount: 3, maxPlayerCount: 5, hostName: "Hostie de Hostname", gameName: "Gostie de game name", tileClass: "tile-3", dieColor: "green", players: [] }];
*/
            $scope.addGame = function () {
                $scope.tiles.push(
                {
                    playerCount: 1,
                    maxPlayerCount: this.game.maxPlayerCount,
                    hostName: this.player.playerName,
                    gameName: this.game.gameName,
                    tileClass: "tile-1",
                    dieColor: "red",
                    players: [this.player]
                });
            };
            $scope.joinGame = function (gameName) {
                for (var i = 0; i < $scope.tiles.length; i++) {
                    if ($scope.tiles[i].gameName === gameName) {
                        $scope.tiles[i].players.push(this.player);
                        $scope.tiles[i].playerCount++;
                    }
                }
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
    app.factory("gameListService", ["$http", function ($http) {

        var gameList = {};
        gameList.getGames = function () {
            var games = [];
            $http({
                method: 'GET',
                url: 'http://localhost/Qwixx.WebAPI/GameIntention'
            }).then(function successCallback(response) {
                games = response;
            }, function errorCallback(response) {
                var getResp = response;
                getResp = 2;
            });
            return games;
        };
        gameList.addGame = function (game) {
            $http.post('http://localhost/Qwixx.WebAPI/GameIntention', game)
                .then(function successCallback(response) {
                    response = response;
                }, function errorCallback(response) {
                        // called asynchronously if an error occurs
                    // or server returns response with an error status.
                    response = response;
                    });
        };
        return gameList;
    }]);
})();