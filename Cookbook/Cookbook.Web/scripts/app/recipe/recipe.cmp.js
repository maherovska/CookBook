(function () {
    'use strict';

    angular
        .module('app')
        .component('recipe', {
            templateUrl: '../scripts/app/recipe/recipe.tpl.html',
            controller: ['$state', '$stateParams', 'recipeSvc', RecipeCtrl]
        });

    function RecipeCtrl($state, $stateParams, recipeSvc) {
        var $ctrl = this;

        init();

        function init() {
            var recipeId = $stateParams.id;
            recipeSvc
                .getRecipe(recipeId)
                .then(function (response) {
                    $ctrl.recipe = response.data;
                });
        }

        $ctrl.goToList = function () {
            $state.go('default');
        }
       
    }

})();