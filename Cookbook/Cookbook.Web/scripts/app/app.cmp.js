(function () {
    'use strict';
    
    angular
        .module('app')
        .component('app', {
            templateUrl: '../scripts/app/app.tpl.html',
            controller: ['$state', AppCtrl]
        });

    function AppCtrl($state) {

        var $ctrl = this;

        $ctrl.openRecipeList = function () {
            $state.go('default');
        }

    }

})();