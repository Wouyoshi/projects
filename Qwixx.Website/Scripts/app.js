(function() {
    var app = angular.module("qwixx", []);

    app.controller("qwixxController", [
        "$scope", function($scope) {
            $scope.red = { rowClass: "qwixx-row-1" };
            $scope.yellow = { rowClass: "qwixx-row-2" };
            $scope.green = { rowClass: "qwixx-row-3" };
            $scope.blue = { rowClass: "qwixx-row-4" };
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
            controller: function ($scope) {
                $scope.checked1 = { amountText: "1" };
                $scope.checked2 = { amountText: "2" };
                $scope.checked3 = { amountText: "3" };
                $scope.checked4 = { amountText: "4" };
                $scope.checked5 = { amountText: "5" };
                $scope.checked6 = { amountText: "6" };
                $scope.checked7 = { amountText: "7" };
                $scope.checked8 = { amountText: "8" };
                $scope.checked9 = { amountText: "9" };
                $scope.checked10 = { amountText: "10" };
                $scope.checked11 = { amountText: "11" };
                $scope.checked12 = { amountText: "12" };
                
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
})();