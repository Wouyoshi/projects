(function () {
    "use strict";
    var app = angular.module("qwixx", []);

    app.controller("qwixxController", [
        "$scope", "scoreService", function ($scope, scoreService) {
            $scope.red = { color: "red", rowClass: "qwixx-row-1", imageSrc: "Content/Icons/lock-icon-red.png", order: "asc" };
            $scope.yellow = { color: "yellow", rowClass: "qwixx-row-2", imageSrc: "Content/Icons/lock-icon-yellow.png", order: "asc" };
            $scope.green = { color: "green", rowClass: "qwixx-row-3", imageSrc: "Content/Icons/lock-icon-green.png", order: "desc" };
            $scope.blue = { color: "blue", rowClass: "qwixx-row-4", imageSrc: "Content/Icons/lock-icon-blue.png", order:"desc" };
            $scope.rules = { rowClass: "qwixx-row-5" };
            $scope.score = { rowClass: "qwixx-row-6", scoreService: scoreService };
        }
    ]);
    app.directive("qwixxNumberRow", function() {
        return {
            restrict: "E",
            templateUrl: "qwixx-number-row.html",
            scope: {
                row: "=row"
            }
        };
    });
    app.directive("qwixxScoreRow", function () {
        return {
            restrict: "E",
            templateUrl: "qwixx-score-row.html",
            scope: {
                row: "=row"
            }
        };
    });
    app.controller("qwixxRowController", [
        "$scope", function ($scope) {
            $scope.two = { numberText: "2" };
            $scope.three = { numberText: "3" };
            $scope.four = { numberText: "4" };
            $scope.five = { numberText: "5" };
            $scope.six = { numberText: "6" };
            $scope.seven = { numberText: "7" };
            $scope.eight = { numberText: "8" };
            $scope.nine = { numberText: "9" };
            $scope.ten = { numberText: "10" };
            $scope.eleven = { numberText: "11" };
            $scope.twelve = { numberText: "12" };

            $scope.checked1 =  { amountText: "1x" , scoreText: "1"};
            $scope.checked2 =  { amountText: "2x" , scoreText: "3"};
            $scope.checked3 =  { amountText: "3x" , scoreText: "6"};
            $scope.checked4 =  { amountText: "4x" , scoreText: "10"};
            $scope.checked5 =  { amountText: "5x" , scoreText: "15"};
            $scope.checked6 =  { amountText: "6x" , scoreText: "21"};
            $scope.checked7 =  { amountText: "7x" , scoreText: "28"};
            $scope.checked8 =  { amountText: "8x" , scoreText: "36"};
            $scope.checked9 =  { amountText: "9x" , scoreText: "45"};
            $scope.checked10 = { amountText: "10x", scoreText: "55"};
            $scope.checked11 = { amountText: "11x", scoreText: "66"};
            $scope.checked12 = { amountText: "12x", scoreText: "78"};
        }
    ]);
    app.directive("qwixxNumber", function () {
        return {
            restrict: "E",
            templateUrl: "qwixx-number.html",
            scope: {
                number: "=number"
            }
        };
    });
    app.directive("qwixxLock", function () {
        return {
            restrict: "E",
            templateUrl: "qwixx-lock.html"
        };
    });
    app.controller("qwixxNumberController", [
        "$scope", "scoreService", function ($scope, scoreService) {
            $scope.qwixxSelected = false;
            $scope.numberClicked = function () {
                $scope.qwixxSelected = true;
                var color = $scope.$parent.$parent.$parent.row.color;
                if (!$scope.$parent.number) {
                    scoreService.addLock(color);
                    return;
                }

                var number = $scope.$parent.number.numberText;
                scoreService.addNumber(color, number);
            }
        }
    ]);

    app.directive("qwixxRulesRow", function () {
        return {
            restrict: "E",
            templateUrl: "qwixx-rules-row.html",
            scope: {
                row: "=row"
            }
        };
    });
    app.directive("qwixxRuleBubble", function () {
        return {
            scope: {
                rule: "=rule"
            },
            restrict: "E",
            templateUrl: "qwixx-rule-bubble.html"
        };
    });
    app.directive("qwixxRuleExplanationBubble", function () {
        return {
            restrict: "E",
            templateUrl: "qwixx-rule-explanation-bubble.html"
        };
    });
    app.directive("qwixxWastedDiceRow", function () {
        return {
            restrict: "E",
            templateUrl: "qwixx-wasted-dice-row.html"
        };
    });
    app.directive("qwixxWasted", function () {
        return {
            restrict: "E",
            templateUrl: "qwixx-wasted.html"
        };
    });
    app.factory("scoreService", function() {
        var scores = {};
        scores.red = {};
        scores.red.list = [];
        scores.red.total = 0;
        scores.yellow = {};
        scores.yellow.list = [];
        scores.yellow.total = 0;
        scores.green = {};
        scores.green.list = [];
        scores.green.total = 0;
        scores.blue = {};
        scores.blue.list = [];
        scores.blue.total = 0;
        scores.wasted = {};
        scores.wasted.list = [];
        scores.wasted.total = 0;

        scores.getList = function(color) {
            if (!color) {
                return null;
            }
            switch(color) {
                case "red":
                    return scores.red.list;
                case "yellow":
                    return scores.yellow.list;
                case "green":
                    return scores.green.list;
                case "blue":
                    return scores.blue.list;
                default:
                    return null;
            }
        }
        scores.addLock = function(color) {
            if (!color) {
                return;
            }
            var list = scores.getList(color);
            if (list == null) {
                return;
            }
            if (list.indexOf("lock") >= 0) {
                return;
            }
            list.push("lock");
            scores.recalculate();
        }
        scores.addNumber = function (color, number) {
            // validate.
            if (!color || !number) {
                return;
            }
            if (isNaN(number)) {
                return;
            }
            // make sure it's an int value.
            var intValue = Math.floor(number);
            if (intValue < 2 || number > 12) {
                return;
            }
            var list = scores.getList(color);
            if (list == null) {
                return;
            }
            if (list.indexOf(intValue) >= 0) {
                return;
            }
            // Add the score to the list.
            list.push(intValue);
            scores.recalculate();
        }
        scores.recalculate = function() {
            var calc = function (length) {
                var total = 0;
                for (var i = 0; i <= length; i++) {
                    total += i;
                }
                return total;
            }
            scores.red.total = calc(scores.getList("red").length);
            scores.yellow.total = calc(scores.getList("yellow").length);
            scores.green.total = calc(scores.getList("green").length);
            scores.blue.total = calc(scores.getList("blue").length);
        }
        return scores;
    });
})();