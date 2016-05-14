(function (angular, app) {
    'use strict';

    app
        .factory('sweetAlert', sweetAlert)
        .factory('datatableSettings', datatableSettings);

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
                    swal('', message, 'success');
                });
            },
            error: function (message) {
                $rootScope.$evalAsync(function () {
                    swal('', message, 'error');
                });
            },
            warning: function (message) {
                $rootScope.$evalAsync(function () {
                    swal('', message, 'warning');
                });
            },
            info: function (message) {
                $rootScope.$evalAsync(function () {
                    swal('', message, 'info');
                });
            },
            showInputError: function (message) {
                $rootScope.$evalAsync(function () {
                    swal.showInputError(message);
                });
            },
            confirm: function (title, message, yesFn, noFn, closeOnConfirm, closeOnCancel) {
                $rootScope.$evalAsync(function() {
                    swal({
                            title: title,
                            text: message,
                            type: "warning",
                            showCancelButton: true,
                            confirmButtonColor: "#DD6B55",
                            confirmButtonText: "Yes",
                            cancelButtonText: "No",
                            closeOnConfirm: closeOnConfirm,
                            closeOnCancel: closeOnCancel
                        },
                        function(isConfirm) {
                            if (isConfirm) {
                                if (yesFn) {
                                    yesFn();
                                }
                            } else {
                                if (noFn) {
                                    noFn();
                                }
                            }
                        });
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

    function datatableSettings() {
        var self = {
            getGeneralSettings: function(dtOptionsBuilder) {
                return dtOptionsBuilder.newOptions()
                    .withDOM(
                        "<'row'<'col-sm-12'tr>>" +
                        "<'row'<'col-sm-5'i><'col-sm-7'p>>")
                    .withDisplayLength(10);
            }
        };

        return self;
    };
})(angular, app);