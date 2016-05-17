(function (angular, app) {
    'use strict';

    app.controller('LoginCtrl', function ($rootScope,$scope, $state, authService, sweetAlert) {
        //api.account.logout();

        $scope.login = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                //var data = "grant_type=password&username=aa&password=bb";

                //$http.post('http://localhost:54843/token', data, {
                //    headers:
                //    { 'Content-Type': 'application/x-www-form-urlencoded' }
                //}).then(function (res) {
                //    var a = res;

                //    $rootScope.aa = res.data.access_token;
                //    $state.go('admin.dashboard');
                //});
                //api.account.login($scope.data, function(response) {
                //    if(response.Result){
                //        $state.go('admin.dashboard');
                //    }
                //    else{
                //        sweetAlert.error('用户名和密码错误');
                //    }
                //});
                authService.login($scope.data.LoginName, $scope.data.Password,
                    function() {
                        $state.go('admin.dashboard');
                    });
            }
        };
    });

})(angular, app);