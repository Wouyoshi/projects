(function() {
    "use strict";
    var app = angular.module("gameUtilities");

    app.directive("gameDie", function () {
            return {
                restrict: "E",
                templateUrl: "game-die.html",
                scope: {
                    color: "=",
                    diename: "=",
                    diceNumber: "="
                }
            };
        }
    );
})();