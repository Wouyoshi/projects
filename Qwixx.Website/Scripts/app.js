(function () {
    "use strict";
    var app = angular.module("qwixx", []);

    app.controller("qwixxController", [
        "$scope", function($scope) {
            $scope.red = { rowClass: "qwixx-row-1", imageSrc: "Content/Icons/lock-icon-red.png" };
            $scope.yellow = { rowClass: "qwixx-row-2", imageSrc: "Content/Icons/lock-icon-yellow.png" };
            $scope.green = { rowClass: "qwixx-row-3", imageSrc: "Content/Icons/lock-icon-green.png" };
            $scope.blue = { rowClass: "qwixx-row-4", imageSrc: "Content/Icons/lock-icon-blue.png" };
            $scope.rules = { rowClass: "qwixx-row-5" };
            $scope.score = { rowClass: "qwixx-row-6" };
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
        "$scope", function ($scope) {
            $scope.qwixxSelected = false;
            $scope.numberClicked = function () {
                this.qwixxSelected = true;

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
})();