(function (angular, app) {
    'use strict';

    app.controller('IdleAssetsCtrl', function ($scope, api) {
        api.idleAssets.query(function (result) {
            var idleAssets = [];

            angular.forEach(result, function (data) {
                if (idleAssets.length > 0) {
                    var hasItem = false;
                    for (var i = 0; i < idleAssets.length; i++) {
                        if (idleAssets[i].area === data.Area) {
                            hasItem = true;
                            idleAssets[i].items.push(data);
                            break;
                        }
                    }
                    if (!hasItem) {
                        idleAssets.push({
                            area: data.Area,
                            items: [data]
                        });
                    }
                } else {
                    idleAssets.push({
                        area: data.Area,
                        items: [data]
                    });
                }
            });

            $scope.idleAssets = idleAssets;
        });
    });

})(angular, window.app);