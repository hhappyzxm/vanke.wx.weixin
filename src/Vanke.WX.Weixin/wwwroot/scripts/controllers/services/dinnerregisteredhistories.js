(function (angular, app) {
    'use strict';

    app.controller('DinnerRegisteredCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        $scope.filterStatus = '0';

        var loadData = function() {
            api.dinnerRegister.search({ status: $scope.filterStatus }, function (result) {
                $scope.dinnerRegisteredHistories = result;
            });
        }

        loadData();

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(9).notSortable()
        ];

        $scope.cancel = function (id) {
            sweetAlert.confirm(
                "你将取消这条数据!",
                function(resover) {
                    api.dinnerRegister.cancel({ id: id }, function () {
                        for (var i = 0; i < $scope.dinnerRegisteredHistories.length; i++) {
                            if ($scope.dinnerRegisteredHistories[i].ID === id) {
                                $scope.dinnerRegisteredHistories.splice(i, 1);
                                break;
                            }
                        }

                        resover();
                    });
                });
        };

        $scope.search = function() {
            loadData();
        }
    });

})(angular, window.app);