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

            gameListService.getGames($scope);
               
            $scope.addGame = function () {
                var game = {
                    maxPlayerCount: this.game.maxPlayerCount,
                    hostName: this.player.playerName,
                    gameName: this.game.gameName
                };
                gameListService.addGame(game, $scope);
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
        gameList.getTileClass = function(number) {
            var i = number % 4 + 1;
            return "tile-" + i;
        };
        gameList.getDieColor = function (number) {
            var i = number % 4 + 1;
            switch (i) {
                case 1:
                    return "red";
                case 2:
                    return "yellow";
                case 3:
                    return "green";
                case 4:
                    return "blue";
                default:
                    return "white";
            }
        };
        gameList.getGames = function ($scope) {
            var games = [];
            $http({
                method: 'GET',
                url: 'http://localhost/Qwixx.WebAPI/api/GameIntention'
            }).then(function successCallback(response) {
                if (!response || !response.data || !response.data.length) {
                    return;
                }
                for (var i = 0; i < response.data.length; i++) {
                    var respData = response.data[i];
                    var game = {
                        maxPlayerCount: respData.MaxPlayers,
                        hostName: respData.Host,
                        gameName: respData.GameName,
                        playerCount: respData.PlayerCount,
                        tileClass: gameList.getTileClass(i),
                        dieColor: gameList.getDieColor(i),
                        players: []
                    };
                    games.push(game);
                }
                //games = response.data;
                $scope.tiles = games;
            }, function errorCallback(response) {
                var getResp = response;
                getResp = 2;
            });
        };
        gameList.addGame = function (game, $scope) {
            $http.post('http://localhost/Qwixx.WebAPI/api/GameIntention', game)
                .then(function successCallback(response) {
                    response = response;
                    gameList.getGames($scope);
                }, function errorCallback(response) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                    response = response;
                });
        };
        return gameList;
    }]);
})();