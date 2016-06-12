(function (angular, app) {
    'use strict';

    app.controller('ItemBorrowHistoriesCtrl', function ($scope, api) {
        api.itemBorrow.getOwnHistories(function (result) {
            $scope.histories = result;
        });
    });

})(angular, window.app);