(function (angular, app) {
    'use strict';

    app.controller('ChangePasswordCtrl',
        function ($scope, $window, $filter, api, sweetAlert) {
            $scope.save = function (form) {
                form.$setSubmitted(true);

                if (form.$valid && $scope.data.NewPassword === $scope.data.ConfirmPassword) {
                    api.staffs.changePassword({
                            OldPassword: $scope.data.OldPassword,
                            NewPassword: $scope.data.NewPassword
                        },
                        function () {
                            sweetAlert.success("修改成功");
                            $scope.data.OldPassword = "";
                            $scope.data.NewPassword = "";
                            $scope.data.ConfirmPassword = "";
                            form.$submitted = false;
                        });
                };
            }
        });
})(angular, window.app);