(function (angular, app) {
    'use strict';

    app.factory('sweetAlert', sweetAlert);

    function sweetAlert($rootScope, $window) {
        var swal = $window.swal;

        var self = {
            swal: function (arg1, arg2, arg3) {
                $rootScope.$evalAsync(function () {
                    if (typeof (arg2) === 'function') {
                        swal(arg1, function (isConfirm) {
                            $rootScope.$evalAsync(function () {
                                arg2(isConfirm);
                            });
                        }, arg3);
                    } else {
                        swal(arg1, arg2, arg3);
                    }
                });
            },
            success: function (title, message) {
                $rootScope.$evalAsync(function () {
                    swal(title, message, 'success');
                });
            },
            error: function (title, message) {
                $rootScope.$evalAsync(function () {
                    swal(title, message, 'error');
                });
            },
            warning: function (title, message) {
                $rootScope.$evalAsync(function () {
                    swal(title, message, 'warning');
                });
            },
            info: function (title, message) {
                $rootScope.$evalAsync(function () {
                    swal(title, message, 'info');
                });
            },
            showInputError: function (message) {
                $rootScope.$evalAsync(function () {
                    swal.showInputError(message);
                });
            },
            close: function () {
                $rootScope.$evalAsync(function () {
                    swal.close();
                });
            }
        };

        return self;
    };
})(angular, app);