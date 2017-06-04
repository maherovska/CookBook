(function () {
    'use strict';

    angular
        .module('app')
        .factory('recipeSvc', ['$http', recipeSvc]);

    function recipeSvc($http) {

        var getAllRecipe = function () {
            var promise = $http({
                method: 'GET',
                url: '/api/Recipe'
            });

            return promise;
        }

        var getRecipe = function (id) {
            var promise = $http({
                method: 'GET',
                url: '/api/Recipe',
                params: { id: id }
            });

            return promise;
        }

        var addRecipe = function (recipe) {
            var promise = $http({
                method: 'POST',
                url: '/api/Recipe',
                data: recipe
            });

            return promise;
        }

        var editRecipe = function (recipe) {
            var promise = $http({
                method: 'PUT',
                url: '/api/Recipe',
                data: recipe
            });

            return promise;
        }

        var deleteRecipe = function(id) {
            var promise = $http({
                method: 'DELETE',
                url: '/api/Recipe',
                params: { id: id }
            });

            return promise;
        }

        return {
            getAllRecipe: getAllRecipe,
            getRecipe: getRecipe,
            addRecipe: addRecipe,
            editRecipe: editRecipe,
            deleteRecipe: deleteRecipe
        };
    }

})();