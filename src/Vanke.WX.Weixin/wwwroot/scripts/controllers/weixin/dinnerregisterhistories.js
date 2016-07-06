(function (angular, app) {
    'use strict';

    app.controller('DinnerRegisterHistoriesCtrl', function ($scope, $location, api, sweetAlert) {
        $scope.isOwn = eval($location.search().isown);

        var userName;
        api.account.getUserInfo(function (result) {
            $scope.isExternalPersonnelDiningManager = result.IsExternalPersonnelDiningManager;
            userName = result.UserName;
        });

        if ($scope.isOwn) {
            api.dinnerRegister.getOwnHistories(function(result) {
                $scope.histories = result;
            });
        } else {
            api.dinnerRegister.search(function (result) {
                $scope.histories = result;
            });
        }

        $scope.read = function(id) {
            sweetAlert.confirm(
                "你将确认这条数据!",
                function (resover) {
                    api.dinnerRegister.read({ id: id }, function () {
                        for (var i = 0; i < $scope.histories.length; i++) {
                            if ($scope.histories[i].ID === id) {
                                $scope.histories[i].IsRead = true;
                                $scope.histories[i].ReadTime = new Date();
                                $scope.histories[i].ReadStaff = userName;
                                break;
                            }
                        }

                        resover();
                    });
                });
        };
    });

})(angular, window.app);