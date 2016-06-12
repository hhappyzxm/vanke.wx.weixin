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
                templateUrl: "views/common/content.html",
                data: {
                    pageTitle: '系统设置'
                }
            })
            .state("settings.staffs", {
                 url: "/staffs",
                 templateUrl: "views/settings/staffs.html",
                 data: {
                     pageTitle: '内部员工管理'
                 }
             })
            .state("settings.staffedit", {
                url: "/staffedit?id",
                templateUrl: "views/settings/staffedit.html",
                data: {
                    pageTitle: '内部员工管理'
                }
            })
            .state("settings.dinnertypes", {
                url: "/dinnertypes",
                templateUrl: "views/settings/dinnertypes.html",
                data: {
                    pageTitle: '宴会类型管理'
                }
            })
            .state("settings.dinnertypeedit", {
                url: "/dinnertypeedit?id",
                templateUrl: "views/settings/dinnertypeedit.html",
                data: {
                    pageTitle: '宴会类型管理'
                }
            })
            .state("settings.dinnerplaces", {
                url: "/dinnerplaces",
                templateUrl: "views/settings/dinnerplaces.html",
                data: {
                    pageTitle: '宴会地点管理'
                }
            })
            .state("settings.dinnerplaceedit", {
                url: "/dinnerplaceedit?id",
                templateUrl: "views/settings/dinnerplaceedit.html",
                data: {
                    pageTitle: '宴会地点管理'
                }
            })
            .state("settings.items", {
                url: "/items",
                templateUrl: "views/settings/items.html",
                data: {
                    pageTitle: '物品管理'
                }
            })
            .state("settings.itemedit", {
                url: "/itemedit?id",
                templateUrl: "views/settings/itemedit.html",
                data: {
                    pageTitle: '物品管理'
                }
            })
            .state("settings.itemstorageareas", {
                url: "/itemstorageareas",
                templateUrl: "views/settings/itemstorageareas.html",
                data: {
                    pageTitle: '物品存放区域管理'
                }
            })
            .state("settings.itemstorageareaedit", {
                url: "/itemstorageareaedit?id",
                templateUrl: "views/settings/itemstorageareaedit.html",
                data: {
                    pageTitle: '物品存放区域管理'
                }
            })
            .state("settings.itemstorageplaces", {
                url: "/itemstorageplaces",
                templateUrl: "views/settings/itemstorageplaces.html",
                data: {
                    pageTitle: '物品存放地点管理'
                }
            })
            .state("settings.itemstorageplaceedit", {
                url: "/itemstorageplaceedit?id",
                templateUrl: "views/settings/itemstorageplaceedit.html",
                data: {
                    pageTitle: '物品存放地点管理'
                }
            })

            // 行政服务
            .state('service', {
                abstract: true,
                url: "/service",
                templateUrl: "views/common/content.html",
                data: {
                    pageTitle: '行政服务'
                }
            })
            .state('service.itemborrow', {
                url: "/itemborrow",
                templateUrl: "views/services/itemborrowhistories.html",
                data: {
                    pageTitle: '物品借用'
                }
            })
            .state('service.idleassets', {
                url: "/idleassets",
                templateUrl: "views/services/idleassets.html",
                data: {
                    pageTitle: '闲置资产'
                }
            })
            .state('service.idleassetedit', {
                url: "/idleassetedit?id",
                templateUrl: "views/services/idleassetedit.html",
                data: {
                    pageTitle: '闲置资产'
                }
            })
            .state('service.dinnerregister', {
                url: "/dinnerregister",
                templateUrl: "views/services/dinnerregisteredhistories.html",
                data: {
                    pageTitle: '宴请管理'
                }
            })
            .state('service.externalpersonneldiningregister', {
                url: "/externalpersonneldiningregister",
                templateUrl: "views/services/externalpersonneldiningregisterhistories.html",
                data: {
                    pageTitle: '外部人员就餐管理'
                }
            })

            // 服务查询
            .state('query', {
                abstract: true,
                url: "/query",
                templateUrl: "views/common/content.html",
                data: {
                    pageTitle: '服务查询'
                }
            })
            .state('query.designateddrivers', {
                url: "/designateddrivers",
                templateUrl: "views/query/designateddrivers.html",
                data: {
                    pageTitle: '代驾管理'
                }
            })
            .state('query.designateddriveredit', {
                url: "/designateddriveredit?id",
                templateUrl: "views/query/designateddriveredit.html",
                data: {
                    pageTitle: '代驾管理'
                }
            })
            .state('query.surroundingservices', {
                url: "/surroundingservices",
                templateUrl: "views/query/surroundingservices.html",
                data: {
                    pageTitle: '无锡周边'
                }
            })
            .state('query.surroundingserviceedit', {
                url: "/surroundingserviceedit?id",
                templateUrl: "views/query/surroundingserviceedit.html",
                data: {
                    pageTitle: '无锡周边'
                }
            })
            .state('query.employeediscounts', {
                url: "/employeediscounts",
                templateUrl: "views/query/employeediscounts.html",
                data: {
                    pageTitle: '员工优惠'
                }
            })
            .state('query.employeediscountedit', {
                url: "/employeediscountedit?id",
                templateUrl: "views/query/employeediscountedit.html",
                data: {
                    pageTitle: '员工优惠'
                }
            })

            // Common views
            .state('common', {
                abstract: true,
                url: "/common",
                templateUrl: "views/common/content_empty.html",
                data: {
                    pageTitle: 'Common'
                }
            })
            .state('common.login', {
                url: "/login",
                templateUrl: "views/common_app/login.html",
                data: {
                    pageTitle: '登录'
                }
            });
    }

})(angular, app);