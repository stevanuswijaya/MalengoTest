(function () {
    var app = angular.module('palindrome-app', []),
        uri = 'http://localhost:45731/api/Palindrome',
        stopUri = 'http://localhost:45731/api/StopPalindrome',
        errorMessage = function (data, status) {
            return 'Error: ' + status +
                (data.Message !== undefined ? (' ' + data.Message) : '');
        };

    app.controller('PalindromeController', ['$http', '$scope', function ($http, $scope) {
        $scope.palindromeList = null;
        $scope.isGenerated = false;
        $scope.listCount = 0;
        $scope.message = "";
        var isGeneratedString = "IsGenerated";
        var palindromeList = "PalindromeList";

        //Preparing signalR hub to connect with server
        var hub = $.connection.signalrHub;
        $.connection.hub.url = 'http://localhost:45731/signalr';
        $.connection.hub.start().done(function () {
            $scope.message = "Hub connection successfully created!";
            console.log($scope.message);
            $scope.$apply();
        });

        //Client signalr method to be invoked from server to populate new palindromes
        hub.client.populateOnePalindrome = function (newObject) {
            $scope.message = "SignalR received from server, populate new item!";
            console.log($scope.message);

            angular.forEach(newObject, function (value, key) {
                if (key == palindromeList) {
                    $scope.palindromeList = value;
                }
                else if (key == isGeneratedString) {
                    $scope.isGenerated = value;
                }
                if (key == 'ListCount') {
                    $scope.listCount = value;
                }
            });

            $scope.$apply();
        };

        $scope.populatePalindrome = function () {
            $scope.isGenerated = true;
            $http.get(uri)
                .success(function (data, status) {
                    angular.forEach(data, function (value, key) {
                        if (key == palindromeList)
                        {
                            $scope.palindromeList = value;
                        }
                        else if (key == isGeneratedString) {
                            $scope.isGenerated = value;
                        }
                        if (key == 'ListCount') {
                            $scope.listCount = value;
                        }
                    });
                    $scope.message="Populate palindrome success";
                    console.log($scope.message);
                    $scope.$apply();
                })
                .error(function (data, status) {
                    $scope.palindromeResult = null;
                    $scope.message = errorMessage(data, status);
                    console.log("Populate palindrome error. Error = " + $scope.message);
                    $scope.$apply();
                })
        }

        $scope.stopPalindrome = function () {
            $http.get(stopUri)
                .success(function (data, status) {
                    angular.forEach(data, function (value, key) {
                        if (key == palindromeList) {
                            $scope.palindromeList = value;
                        }
                        else if (key == isGeneratedString) {
                            $scope.isGenerated = value;
                        }
                        if (key == 'ListCount') {
                            $scope.listCount = value;
                        }
                    });
                    $scope.message = "Stop palindrome success";
                    console.log($scope.message);
                    $scope.$apply();
                })
                .error(function (data, status) {
                    $scope.palindromeResult = null;
                    $scope.message = errorMessage(data, status);
                    console.log("Stop palindrome error. Error = " + $scope.message);
                    $scope.$apply();
                })
        }
    }])
}());