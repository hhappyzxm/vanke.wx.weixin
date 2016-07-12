(function (angular, app) {
    'use strict';

    app
        .config(configState)
        .run(function ($rootScope, $state) {
            $rootScope.$state = $state;
        });

    function configState($stateProvider, $urlRouterProvider, $compileProvider) {

        // Optimize load start with remove binding information inside the DOM element
        $compileProvider.debugInfoEnabled(true);

        // Set default state
        $urlRouterProvider.otherwise("/common/login");

        $stateProvider
            .state("settings", {
                abstract: true,
                url: "/settings",
                templateUrl: "/wwwroot/views/common/content.html",
                data: {
                    pageTitle: '系统设置'
                }
            })
            .state("settings.staffs", {
                 url: "/staffs",
                 templateUrl: "/wwwroot/views/settings/staffs.html",
                 data: {
                     pageTitle: '内部员工管理'
                 }
             })
            .state("settings.staffedit", {
                url: "/staffedit?id",
                templateUrl: "/wwwroot/views/settings/staffedit.html",
                data: {
                    pageTitle: '内部员工管理'
                }
            })
            .state("settings.dinnertypes", {
                url: "/dinnertypes",
                templateUrl: "/wwwroot/views/settings/dinnertypes.html",
                data: {
                    pageTitle: '宴会类型管理'
                }
            })
            .state("settings.dinnertypeedit", {
                url: "/dinnertypeedit?id",
                templateUrl: "/wwwroot/views/settings/dinnertypeedit.html",
                data: {
                    pageTitle: '宴会类型管理'
                }
            })
            .state("settings.mealtypes", {
                url: "/mealtypes",
                templateUrl: "/wwwroot/views/settings/mealtypes.html",
                data: {
                    pageTitle: '餐别管理'
                }
            })
            .state("settings.mealtypeedit", {
                url: "/mealtypeedit?id",
                templateUrl: "/wwwroot/views/settings/mealtypeedit.html",
                data: {
                    pageTitle: '餐别管理'
                }
            })
            .state("settings.dinnerplaces", {
                url: "/dinnerplaces",
                templateUrl: "/wwwroot/views/settings/dinnerplaces.html",
                data: {
                    pageTitle: '宴会地点管理'
                }
            })
            .state("settings.dinnerplaceedit", {
                url: "/dinnerplaceedit?id",
                templateUrl: "/wwwroot/views/settings/dinnerplaceedit.html",
                data: {
                    pageTitle: '宴会地点管理'
                }
            })
            .state("settings.items", {
                url: "/items",
                templateUrl: "/wwwroot/views/settings/items.html",
                data: {
                    pageTitle: '物品管理'
                }
            })
            .state("settings.itemedit", {
                url: "/itemedit?id",
                templateUrl: "/wwwroot/views/settings/itemedit.html",
                data: {
                    pageTitle: '物品管理'
                }
            })
            .state("settings.itemstorageareas", {
                url: "/itemstorageareas",
                templateUrl: "/wwwroot/views/settings/itemstorageareas.html",
                data: {
                    pageTitle: '物品存放区域管理'
                }
            })
            .state("settings.itemstorageareaedit", {
                url: "/itemstorageareaedit?id",
                templateUrl: "/wwwroot/views/settings/itemstorageareaedit.html",
                data: {
                    pageTitle: '物品存放区域管理'
                }
            })
            .state("settings.itemstorageplaces", {
                url: "/itemstorageplaces",
                templateUrl: "/wwwroot/views/settings/itemstorageplaces.html",
                data: {
                    pageTitle: '物品存放地点管理'
                }
            })
            .state("settings.itemstorageplaceedit", {
                url: "/itemstorageplaceedit?id",
                templateUrl: "/wwwroot/views/settings/itemstorageplaceedit.html",
                data: {
                    pageTitle: '物品存放地点管理'
                }
            })
            .state("settings.setting", {
                url: "/settings",
                templateUrl: "/wwwroot/views/settings/settings.html",
                data: {
                    pageTitle: '参数配置'
                }
            })

            // 行政服务
            .state('service', {
                abstract: true,
                url: "/service",
                templateUrl: "/wwwroot/views/common/content.html",
                data: {
                    pageTitle: '行政服务'
                }
            })
            .state('service.itemborrow', {
                url: "/itemborrow",
                templateUrl: "/wwwroot/views/services/itemborrowhistories.html",
                data: {
                    pageTitle: '物品借用'
                }
            })
            .state('service.idleassets', {
                url: "/idleassets",
                templateUrl: "/wwwroot/views/services/idleassets.html",
                data: {
                    pageTitle: '闲置资产'
                }
            })
            .state('service.idleassetedit', {
                url: "/idleassetedit?id",
                templateUrl: "/wwwroot/views/services/idleassetedit.html",
                data: {
                    pageTitle: '闲置资产'
                }
            })
            .state('service.dinnerregister', {
                url: "/dinnerregister",
                templateUrl: "/wwwroot/views/services/dinnerregisteredhistories.html",
                data: {
                    pageTitle: '宴请管理'
                }
            })
            .state('service.externalpersonneldiningregister', {
                url: "/externalpersonneldiningregister",
                templateUrl: "/wwwroot/views/services/externalpersonneldiningregisterhistories.html",
                data: {
                    pageTitle: '外部人员就餐管理'
                }
            })

            // 服务查询
            .state('query', {
                abstract: true,
                url: "/query",
                templateUrl: "/wwwroot/views/common/content.html",
                data: {
                    pageTitle: '服务查询'
                }
            })
            .state('query.designateddrivers', {
                url: "/designateddrivers",
                templateUrl: "/wwwroot/views/query/designateddrivers.html",
                data: {
                    pageTitle: '代驾管理'
                }
            })
            .state('query.designateddriveredit', {
                url: "/designateddriveredit?id",
                templateUrl: "/wwwroot/views/query/designateddriveredit.html",
                data: {
                    pageTitle: '代驾管理'
                }
            })
            .state('query.surroundingservices', {
                url: "/surroundingservices",
                templateUrl: "/wwwroot/views/query/surroundingservices.html",
                data: {
                    pageTitle: '无锡周边'
                }
            })
            .state('query.surroundingserviceedit', {
                url: "/surroundingserviceedit?id",
                templateUrl: "/wwwroot/views/query/surroundingserviceedit.html",
                data: {
                    pageTitle: '无锡周边'
                }
            })
            .state('query.employeediscounts', {
                url: "/employeediscounts",
                templateUrl: "/wwwroot/views/query/employeediscounts.html",
                data: {
                    pageTitle: '员工优惠'
                }
            })
            .state('query.employeediscountedit', {
                url: "/employeediscountedit?id",
                templateUrl: "/wwwroot/views/query/employeediscountedit.html",
                data: {
                    pageTitle: '员工优惠'
                }
            })

            // Common views
            .state('common', {
                abstract: true,
                url: "/common",
                templateUrl: "/wwwroot/views/common/content_empty.html",
                data: {
                    pageTitle: 'Common'
                }
            })
            .state('common.login', {
                url: "/login",
                templateUrl: "/wwwroot/views/common_app/login.html",
                data: {
                    pageTitle: '登录'
                }
            });
    }

})(angular, app);