(function (angular, app) {
    'use strict';

    app
        .factory('sweetAlert', sweetAlert)
        .factory('datatableSettings', datatableSettings);

    function sweetAlert($rootScope, $window) {
        var swal = $window.swal;

        var self = {
            success: function (message) {
                $rootScope.$evalAsync(function () {
                    swal('Sucess', message, 'success');
                });
            },
            error: function (message) {
                $rootScope.$evalAsync(function () {
                    swal('Error', message, 'error');
                });
            },
            warning: function (message) {
                $rootScope.$evalAsync(function () {
                    swal('Warning', message, 'warning');
                });
            },
            info: function (message) {
                $rootScope.$evalAsync(function () {
                    swal('Info', message, 'info');
                });
            },
            confirm: function (message, yesFn, noFn) {
                $rootScope.$evalAsync(function () {
                    swal({
                        title: 'Are you sure?',
                        text: message,
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "Yes",
                        cancelButtonText: "No",
                        preConfirm: function() {
                            return new Promise(function(resolve) {
                                swal.enableLoading();
                                yesFn(resolve);
                            });
                        },
                        allowOutsideClick: false
                    }).then(function(isConfirm) {
                        if (isConfirm == false) {
                            if (noFn) {
                                noFn();
                            }
                        }
                    });
                });
            },
            close: function () {
                $rootScope.$evalAsync(function () {
                    swal.closeModal();
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