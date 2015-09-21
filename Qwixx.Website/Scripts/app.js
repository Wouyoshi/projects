(function() {
    "use strict";
    var app = angular.module("qwixx", []);

    app.controller("qwixxCardController", [
        "$scope", "$attrs", "scoreService", function ($scope, $attrs, scoreService) {
            if (!$scope.players) {
                $scope.players = [];
            }
            var playerName = $attrs.player;
            scoreService.addPlayer(playerName);
            $scope.red = { playerName: playerName, color: "red", rowClass: "qwixx-row-1", imageSrc: "Content/Icons/lock-icon-red.png", order: "asc", scoreService: scoreService };
            $scope.yellow = { playerName: playerName, color: "yellow", rowClass: "qwixx-row-2", imageSrc: "Content/Icons/lock-icon-yellow.png", order: "asc", scoreService: scoreService };
            $scope.green = { playerName: playerName, color: "green", rowClass: "qwixx-row-3", imageSrc: "Content/Icons/lock-icon-green.png", order: "desc", scoreService: scoreService };
            $scope.blue = { playerName: playerName, color: "blue", rowClass: "qwixx-row-4", imageSrc: "Content/Icons/lock-icon-blue.png", order: "desc", scoreService: scoreService };
            $scope.rules = { playerName: playerName, rowClass: "qwixx-row-5" };
            $scope.score = { playerName: playerName, rowClass: "qwixx-row-6", scoreService: scoreService };
        }
    ]);
    app.directive("qwixxCard", function () {
        return {
            restrict: "E",
            templateUrl: "qwixx-card.html",
            controller: 'qwixxCardController',
            scope: true
        };
    });

    app.directive("qwixxNumberRow", function() {
        return {
            restrict: "E",
            templateUrl: "qwixx-number-row.html",
            scope: {
                row: "=row"
            }
        };
    });
    app.directive("qwixxScoreRow", function() {
        return {
            restrict: "E",
            templateUrl: "qwixx-score-row.html",
            scope: {
                row: "=row"
            }
        };
    });
    app.controller("qwixxRowController", [
        "$scope", "scoreService", function ($scope, scoreService) {
            $scope.two = { numberText: "2", scoreService: scoreService, color: $scope.$parent.row.color, playerName: $scope.$parent.row.playerName };
            $scope.three = { numberText: "3", scoreService: scoreService, color: $scope.$parent.row.color, playerName: $scope.$parent.row.playerName };
            $scope.four = { numberText: "4", scoreService: scoreService, color: $scope.$parent.row.color, playerName: $scope.$parent.row.playerName };
            $scope.five = { numberText: "5", scoreService: scoreService, color: $scope.$parent.row.color, playerName: $scope.$parent.row.playerName };
            $scope.six = { numberText: "6", scoreService: scoreService, color: $scope.$parent.row.color, playerName: $scope.$parent.row.playerName };
            $scope.seven = { numberText: "7", scoreService: scoreService, color: $scope.$parent.row.color, playerName: $scope.$parent.row.playerName };
            $scope.eight = { numberText: "8", scoreService: scoreService, color: $scope.$parent.row.color, playerName: $scope.$parent.row.playerName };
            $scope.nine = { numberText: "9", scoreService: scoreService, color: $scope.$parent.row.color, playerName: $scope.$parent.row.playerName };
            $scope.ten = { numberText: "10", scoreService: scoreService, color: $scope.$parent.row.color, playerName: $scope.$parent.row.playerName };
            $scope.eleven = { numberText: "11", scoreService: scoreService, color: $scope.$parent.row.color, playerName: $scope.$parent.row.playerName };
            $scope.twelve = { numberText: "12", scoreService: scoreService, color: $scope.$parent.row.color, playerName: $scope.$parent.row.playerName };

            $scope.checked1 = { amountText: "1x", scoreText: "1" };
            $scope.checked2 = { amountText: "2x", scoreText: "3" };
            $scope.checked3 = { amountText: "3x", scoreText: "6" };
            $scope.checked4 = { amountText: "4x", scoreText: "10" };
            $scope.checked5 = { amountText: "5x", scoreText: "15" };
            $scope.checked6 = { amountText: "6x", scoreText: "21" };
            $scope.checked7 = { amountText: "7x", scoreText: "28" };
            $scope.checked8 = { amountText: "8x", scoreText: "36" };
            $scope.checked9 = { amountText: "9x", scoreText: "45" };
            $scope.checked10 = { amountText: "10x", scoreText: "55" };
            $scope.checked11 = { amountText: "11x", scoreText: "66" };
            $scope.checked12 = { amountText: "12x", scoreText: "78" };
        }
    ]);
    app.directive("qwixxDie", [
        "scoreService", function(scoreService) {
            return {
                restrict: "E",
                templateUrl: "qwixx-die.html",
                scope: {
                    color: "=",
                    diename: "="
                },
                link: function(scope, element, attrs) {
                    scope.scoreService = scoreService;
                }
            };
        }
    ]);
    app.directive("qwixxNumber", function() {
        return {
            restrict: "E",
            templateUrl: "qwixx-number.html",
            scope: {
                number: "=number"
            }
        };
    });
    app.directive("qwixxLock", function() {
        return {
            restrict: "E",
            templateUrl: "qwixx-lock.html"
        };
    });
    app.controller("qwixxNumberController", [
        "$scope", "scoreService", function($scope, scoreService) {
            $scope.qwixxSelected = false;
            $scope.numberClicked = function() {
                var color = $scope.$parent.$parent.$parent.row.color;
                var playerName = $scope.$parent.$parent.$parent.row.playerName;
                var added = false;
                if (!$scope.$parent.number) {
                    added = scoreService.addLock(playerName, color);
                    if (!added) {
                        return;
                    }
                    $scope.qwixxSelected = true;
                    return;
                }

                var number = $scope.$parent.number.numberText;
                added = scoreService.addNumber(playerName, color, number);
                if (!added) {
                    return;
                }
                //$scope.qwixxSelected = true;
            };
        }
    ]);
    app.controller("qwixxWastedController", [
        "$scope", "scoreService", function ($scope, scoreService) {
            $scope.waste1 = { amount: 1, qwixxSelected: false, scoreService: scoreService, playerName: $scope.$parent.$parent.row.playerName };
            $scope.waste2 = { amount: 2, qwixxSelected: false, scoreService: scoreService, playerName: $scope.$parent.$parent.row.playerName };
            $scope.waste3 = { amount: 3, qwixxSelected: false, scoreService: scoreService, playerName: $scope.$parent.$parent.row.playerName };
            $scope.waste4 = { amount: 4, qwixxSelected: false, scoreService: scoreService, playerName: $scope.$parent.$parent.row.playerName };
        }
    ]);

    app.directive("qwixxRulesRow", function() {
        return {
            restrict: "E",
            templateUrl: "qwixx-rules-row.html",
            scope: {
                row: "=row"
            }
        };
    });
    app.directive("qwixxRuleBubble", function() {
        return {
            scope: {
                rule: "=rule"
            },
            restrict: "E",
            templateUrl: "qwixx-rule-bubble.html"
        };
    });
    app.directive("qwixxRuleExplanationBubble", function() {
        return {
            restrict: "E",
            templateUrl: "qwixx-rule-explanation-bubble.html"
        };
    });
    app.directive("qwixxWastedDiceRow", function() {
        return {
            restrict: "E",
            templateUrl: "qwixx-wasted-dice-row.html"
        };
    });
    app.directive("qwixxWasted", function() {
        return {
            restrict: "E",
            scope: {
                waste: "=waste"
            },
            templateUrl: "qwixx-wasted.html"
        };
    });
    app.controller("qwixxDiceController", ["$scope","scoreService" , function($scope, scoreService) {
        $scope.scoreService = scoreService;
    }]);
    app.directive("qwixxDice", function () {
        return {
            restrict: "E",
            templateUrl: "qwixx-dice.html",
            controller: "qwixxDiceController"
        };
    });
    app.directive("qwixxGame", function () {
        return {
            restrict: "E",
            templateUrl: "qwixx-game.html"
        };
    });
    app.factory("scoreService", function() {
        var scores = {};
        scores.playerList = [];
        scores.currentTurnNumber = 0;
        scores.turnOrder = [];
        scores.turns = [];
        scores.redDiePresent = true;
        scores.yellowDiePresent = true;
        scores.greenDiePresent = true;
        scores.blueDiePresent = true;
        scores.gameOver = false;

        scores.getDiceNumber = function(diceName) {
            if (!diceName) {
                return 0;
            }
            var currentTurn = scores.turns[scores.currentTurnNumber - 1];
            if (!currentTurn) {
                return 0;
            }
            switch (diceName) {
            case "dieRed":
                return currentTurn.dieRed;
            case "dieYellow":
                return currentTurn.dieYellow;
            case "dieGreen":
                return currentTurn.dieGreen;
            case "dieBlue":
                return currentTurn.dieBlue;
            case "dieWhite1":
                return currentTurn.dieWhite1;
            case "dieWhite2":
                return currentTurn.dieWhite2;
            default:
                return 0;
            }

        };
        scores.startNewTurn = function () {
            // If this is not the first turn, check to see if a wasted should be added.
            if (scores.currentTurnNumber > 0) {
                var currentTurn = scores.turns[scores.currentTurnNumber - 1];
                var currentTurnOwner = currentTurn.turnOwner;
                // will only add a wasted if it should.
                scores.addWasted(currentTurnOwner);
                // if total wasted is 4, game is over.
                var totalWasted = scores.getWastedAmount(currentTurnOwner);
                if (totalWasted >= 4) {
                    scores.gameOver = true;
                }
                // Check if die should be removed.
                for (var i = 0; i < scores.playerList.length; i++) {
                    var player = scores.playerList[i];
                    if (player.red.hasLock) {
                        scores.redDiePresent = false;
                    }
                    if (player.yellow.hasLock) {
                        scores.yellowDiePresent = false;
                    }
                    if (player.green.hasLock) {
                        scores.greenDiePresent = false;
                    }
                    if (player.blue.hasLock) {
                        scores.blueDiePresent = false;
                    }
                }
                // Check how many dies are removed, if 2 or more, the game should end.
                var diesRemoved = 0;
                if (!scores.redDiePresent) {
                    diesRemoved++;
                }
                if (!scores.yellowDiePresent) {
                    diesRemoved++;
                }
                if (!scores.greenDiePresent) {
                    diesRemoved++;
                }
                if (!scores.blueDiePresent) {
                    diesRemoved++;
                }
                if (diesRemoved >= 2) {
                    scores.gameOver = true;
                }
            }
            // Don't start new turn if game over.
            if (scores.gameOver) {
                return;
            }
            var nextTurn = scores.currentTurnNumber + 1;
            var randomNumber = function(min, max) {
                return Math.floor(Math.random() * (max - min + 1) + min);
            };
            // Switch turns.
            var turnOwner = scores.playerList[nextTurn % scores.playerList.length];
            var turn = {
                turnNumber: nextTurn,
                playersWhoDidAction: [],
                turnOwner: turnOwner.playerName,
                turnOwnerAction: false,
                addedWasted: false,
                dieRed: randomNumber(1, 6),
                dieYellow: randomNumber(1, 6),
                dieGreen: randomNumber(1, 6),
                dieBlue: randomNumber(1, 6),
                dieWhite1: randomNumber(1, 6),
                dieWhite2: randomNumber(1, 6)
            };
            scores.turns.push(turn);
            scores.currentTurnNumber = nextTurn;
        };
        scores.addPlayer = function(playerName) {
            if (!playerName) {
                return;
            }
            for (var i = 0; i < scores.playerList.length; i++) {
                if (scores.playerList[i].playerName === playerName) {
                    return;
                }
            }
            var player = {
                playerName: playerName,
                red: {
                    list: [],
                    total: 0,
                    hasLock: false
                },
                yellow: {
                    list: [],
                    total: 0,
                    hasLock: false
                },
                green: {
                    list: [],
                    total: 0,
                    hasLock: false
                },
                blue: {
                    list: [],
                    total: 0,
                    hasLock: false
                },
                wasted: {
                    amount: 0,
                    total: 0
                }
            };

            scores.playerList.push(player);
            scores.turnOrder.push(player.playerName);
        };
        scores.getWastedTotal = function (playerName) {
            if (!playerName) {
                return 0;
            }
            var player = scores.getPlayer(playerName);
            if (!player) {
                return 0;
            }
            return player.wasted.total;
        };
        scores.getWastedAmount = function(playerName) {
            if (!playerName) {
                return 0;
            }
            var player = scores.getPlayer(playerName);
            if (!player) {
                return 0;
            }
            return player.wasted.amount;
        };
        scores.getPlayer = function (playerName) {
            if (!playerName) {
                return null;
            }
            for (var i = 0; i < scores.playerList.length; i++) {
                if (scores.playerList[i].playerName === playerName) {
                    return scores.playerList[i];
                }
            }
            return null;
        };
        scores.hasLock = function (playerName, color) {
            if (!playerName) {
                return false;
            }
            if (!color) {
                return false;
            }

            var player = scores.getPlayer(playerName);
            if (player == null) {
                return false;
            }

            switch (color) {
            case "red":
                return player.red.hasLock;
            case "yellow":
                return player.yellow.hasLock;
            case "green":
                return player.green.hasLock;
            case "blue":
                return player.blue.hasLock;
            default:
                return false;
            }
        };
        scores.isInList = function (playerName, color, number) {
            /// <summary>
            /// Checks if the number is in the list.
            /// </summary>
            /// <param name="color"></param>
            /// <param name="number"></param>
            /// <returns type=""></returns>
            if (!playerName) {
                return false;
            }
            if (!color) {
                return false;
            }
            
            var list = scores.getList(playerName, color);
            if (!list) {
                return false;
            }
            return list.indexOf(Number(number)) >= 0;
        };

        scores.getList = function (playerName, color) {
            if (!color) {
                return null;
            }

            if (!playerName) {
                return null;
            }
            var colorItem = scores.getColor(playerName, color);
            if (!colorItem) {
                return null;
            }
            return colorItem.list;
        };
        scores.getColor = function(playerName, color) {
            if (!color) {
                return null;
            }

            if (!playerName) {
                return false;
            }
            var player = scores.getPlayer(playerName);
            if (player == null) {
                return false;
            }

            switch (color) {
            case "red":
                return player.red;
            case "yellow":
                return player.yellow;
            case "green":
                return player.green;
            case "blue":
                return player.blue;
            default:
                return null;
            }
        };
        scores.addWasted = function (playerName) {

            if (!playerName) {
                return;
            }
            var player = scores.getPlayer(playerName);
            if (player == null) {
                return;
            }

            if (player.wasted.amount >= 4) {
                return;
            }


            // Has player already done an action this turn?
            var currentTurn = scores.turns[scores.currentTurnNumber - 1];
            if (!currentTurn) {
                return;
            }

            // Can only add a wasted if this is the current player.
            if (currentTurn.turnOwner !== playerName) {
                return;
            }
            // You can't add wasted if already an action has been done.
            if (currentTurn.playersWhoDidAction.indexOf(playerName) >= 0 || currentTurn.turnOwnerAction || currentTurn.addedWasted) {
                return;
            }

            player.wasted.amount++;
            currentTurn.addedWasted = true;
            scores.recalculate();

        };
        scores.addLock = function (playerName, color) {
            if (!color) {
                return false;
            }
            if (!playerName) {
                return false;
            }
            var list = scores.getList(playerName, color);
            if (list === null || list === undefined) {
                return false;
            }
            if (list.indexOf("lock") >= 0) {
                return false;
            }
            // Should be at least 5 entries.
            if (list.length < 5) {
                return false;
            }
            if (color === "red" || color === "yellow") {
                if (list.indexOf(12) < 0) {
                    return false;
                }
            } else {
                if (list.indexOf(2) < 0) {
                    return false;
                }
            }
            list.push("lock");
            scores.recalculate();
            return true;
        };
        scores.addNumber = function (playerName, color, number) {
            // validate.
            if (!color || !number) {
                return false;
            }
            if (isNaN(number)) {
                return false;
            }

            if (!playerName) {
                return false;
            }
            // make sure it's an int value.
            var intValue = Math.floor(number);
            if (intValue < 2 || number > 12) {
                return false;
            }
            var list = scores.getList(playerName, color);
            if (list === null || list === undefined) {
                return false;
            }
            if (list.indexOf(intValue) >= 0) {
                return false;
            }
            // There should be no lock in the list.
            if (list.indexOf("lock") >= 0) {
                return false;
            }
            // Make sure the die is actually present.
            switch(color) {
                case "red":
                    if (!scores.redDiePresent) {
                        return false;
                    }
                    break;
                case "yellow":
                    if (!scores.yellowDiePresent) {
                        return false;
                    }
                    break;
                case "green":
                    if (!scores.greenDiePresent) {
                        return false;
                    }
                    break;
                case "blue":
                    if (!scores.blueDiePresent) {
                        return false;
                    }
                    break;
                default:
                    return false;
            }

            // If there's already a higher number (in case of red and yellow) 
            // or lower number (in case of green and blue). Don't add.
            for (var i = 0; i < list.length; i++) {
                var listNumber = Number(list[i]);
                if (color === "red" || color === "yellow") {
                    if (listNumber > number) {
                        return false;
                    }
                } else {
                    if (listNumber < number) {
                        return false;
                    }
                }
            }

            // Has player already done an action this turn?
            var currentTurn = scores.turns[scores.currentTurnNumber - 1];
            if (!currentTurn) {
                return false;
            }
            if (currentTurn.playersWhoDidAction.indexOf(playerName) >= 0 &&
                (currentTurn.turnOwner !== playerName || currentTurn.turnOwnerAction)) {
                return false;
            }
            // If a this is the turn owner and a wasted has been added, you can't add a number.
            if (currentTurn.turnOwner === playerName && currentTurn.addedWasted) {
                return false;
            }

            // Check if the dice agree with this number.
            var whiteTotal = currentTurn.dieWhite1 + currentTurn.dieWhite2;
            // It works differently for owner of the turn.
            if (currentTurn.turnOwner === playerName) {
                var isWhiteTotalSameAllowed = intValue === whiteTotal;
                var dieNumber = 0;
                switch(color) {
                    case "red":
                        dieNumber = currentTurn.dieRed;
                        break;
                    case "yellow":
                        dieNumber = currentTurn.dieYellow;
                        break;
                    case "green":
                        dieNumber = currentTurn.dieGreen;
                        break;
                    case "blue":
                        dieNumber = currentTurn.dieBlue;
                        break;
                    default:
                        return false;
                }
                var isColoredTotalSameAllowed = intValue === currentTurn.dieWhite1 + dieNumber || intValue === currentTurn.dieWhite2 + dieNumber;
                if (!isWhiteTotalSameAllowed && !isColoredTotalSameAllowed) { // Dice must be ok.
                    return false;
                } else if (!isWhiteTotalSameAllowed && currentTurn.turnOwnerAction) { // Player may only do 1 colored action.
                    return false;
                } else if (!isColoredTotalSameAllowed && currentTurn.playersWhoDidAction.indexOf(playerName) >= 0) { // Player may only do 1 white action.
                    return false;
                } else if (isWhiteTotalSameAllowed && isColoredTotalSameAllowed) { 
                    // This one is tricky. What action should you do if both are allowed?
                    // According to the rules white goes first.
                    currentTurn.playersWhoDidAction.push(playerName);
                } else if (isWhiteTotalSameAllowed) {
                    currentTurn.playersWhoDidAction.push(playerName);
                } else if (isColoredTotalSameAllowed) {
                    currentTurn.turnOwnerAction = true;
                }
            } else {
                // If not the turn owner, just look at the white dice.
                if (intValue !== whiteTotal) {
                    return false;
                }
                // Make sure the player can't do another action this turn.
                currentTurn.playersWhoDidAction.push(playerName);
            }

            // Add the score to the list.
            list.push(intValue);

            // Try to add lock. Might fail if conditions are not met but that's ok.
            scores.addLock(playerName, color);
            scores.recalculate();
            return true;
        };

        scores.getTotal = function(playerName, color) {
            if (!playerName) {
                return 0;
            }
            if (!color) {
                return 0;
            }
            var colorItem = scores.getColor(playerName, color);
            if (!colorItem) {
                return 0;
            }
            return colorItem.total;
        };
        scores.recalculate = function() {
            var calc = function(length) {
                var total = 0;
                for (var i = 0; i <= length; i++) {
                    total += i;
                }
                return total;
            };
            for (var j = 0; j < scores.playerList.length; j++) {
                var player = scores.playerList[j];
                player.red.total = calc(scores.getList(player.playerName, "red").length);
                player.yellow.total = calc(scores.getList(player.playerName, "yellow").length);
                player.green.total = calc(scores.getList(player.playerName, "green").length);
                player.blue.total = calc(scores.getList(player.playerName, "blue").length);
                player.wasted.total = player.wasted.amount * 5;
                player.red.hasLock = scores.getList(player.playerName, "red").indexOf("lock") >= 0;
                player.yellow.hasLock = scores.getList(player.playerName, "yellow").indexOf("lock") >= 0;
                player.green.hasLock = scores.getList(player.playerName, "green").indexOf("lock") >= 0;
                player.blue.hasLock = scores.getList(player.playerName, "blue").indexOf("lock") >= 0;
            }
        };
        return scores;
    });
})();