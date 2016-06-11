(function (angular, app) {
    'use strict';

    app.controller('ExternalPersonnelDiningRegisterHistoryCtrl', function ($scope, api, datatableSettings, sweetAlert, DTOptionsBuilder, DTColumnDefBuilder) {
        $scope.filterStatus = '0';

        var loadData = function() {
            api.externalPersonnelDiningRegister.search({ status: $scope.filterStatus }, function (result) {
                $scope.externalPersonnelDiningRegisterHistories = result;
            });
        }

        loadData();

        $scope.dtOptions = datatableSettings.getGeneralSettings(DTOptionsBuilder);

        $scope.dtMessageColumnDefs = [
            DTColumnDefBuilder.newColumnDef(6).notSortable()
        ];

        $scope.cancel = function (id) {
            sweetAlert.confirm(
                "你将取消这条数据!",
                function(resover) {
                    api.externalPersonnelDiningRegister.cancel({ id: id }, function () {
                        for (var i = 0; i < $scope.externalPersonnelDiningRegisterHistories.length; i++) {
                            if ($scope.externalPersonnelDiningRegisterHistories[i].ID === id) {
                                $scope.externalPersonnelDiningRegisterHistories.splice(i, 1);
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