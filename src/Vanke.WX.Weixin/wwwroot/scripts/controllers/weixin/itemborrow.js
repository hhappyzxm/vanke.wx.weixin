(function (angular, app) {
    'use strict';

    app.controller('ItemBorrowCtrl', function ($scope, $window, api) {
        api.items.query(function(result) {
            $scope.items = result;
        });

        api.itemBorrow.getOwnHistories(function (result) {
            $scope.hasHistories = result.length > 0;
        });

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.itemBorrow.save($scope.data, function () {
                    $window.location.href = "/weixin/itemborrowhistories";
                });
            }
        };
    });

})(angular, window.app);