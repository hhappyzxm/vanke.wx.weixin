(function (angular, app) {
    'use strict';

    app.controller('ItemBorrowCtrl', function ($scope, api, sweetAlert) {
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
                    sweetAlert.success('提交成功');
                    form.$submitted = false;
                    $scope.data = null;
                });
            }
        };
    });

})(angular, window.app);