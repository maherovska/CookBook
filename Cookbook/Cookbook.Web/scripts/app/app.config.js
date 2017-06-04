(function () {
    'use strict';

    angular
        .module('app')
        .config(function ($stateProvider, $locationProvider) {

            $stateProvider
                .state({
                    name: 'default',
                    url: '/',
                    template: '<recipe-list></recipe-list>'
                })
                .state({
                    name: 'recipe',
                    url: '/recipe/:id',
                    template: '<recipe></recipe>'
                }).state("not-found", {
                    url: "*path",
                    template: "<h1>Page can't be found</h1>"
                });

            $locationProvider.html5Mode(true);

        });

})();