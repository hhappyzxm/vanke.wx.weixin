(function (angular, app) {
    'use strict';

    app.controller('ItemBorrowHistoriesCtrl', function ($scope, $location, api, sweetAlert) {
        $scope.isOwn = eval($location.search().isown);

        var userName;
        api.account.getUserInfo(function (result) {
            $scope.isItemBorrowManager = result.IsItemBorrowManager;
            userName = result.UserName;
        });

        if ($scope.isOwn) {
            api.itemBorrow.getOwnHistories(function (result) {
                $scope.histories = result;
            });
        } else {
            api.itemBorrow.search(function (result) {
                $scope.histories = result;
            });
        }

        $scope.return = function (id) {
            sweetAlert.confirm(
                "你将归还这件物品!",
                function (resover) {
                    api.itemBorrow.return({ id: id }, function () {
                        for (var i = 0; i < $scope.histories.length; i++) {
                            if ($scope.histories[i].ID === id) {
                                $scope.histories[i].Status = 1;
                                $scope.histories[i].ReturnedOn = new Date();
                                $scope.histories[i].ReturnedStaff = userName;
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);