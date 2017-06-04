(function () {
	'use strict';

	angular
        .module('app')
        .component('recipeList', {
        	templateUrl: '../scripts/app/recipe-list/recipe-list.tpl.html',
        	controller: ['$state', 'recipeSvc', RecipeListCtrl]
        });

	function RecipeListCtrl($state, recipeSvc) {
	    var $ctrl = this;

	    $ctrl.showModal = false;
	    $ctrl.showAlert = false;
	    $ctrl.recipe = emptyRecipe();
	    $ctrl.recipes = [];
	    $ctrl.header = '';
	    $ctrl.orderIndex = 2;
	    $ctrl.orderList = [{
	        index: 0,
	        title: 'Title: ascending',
	        name: 'title',
	        reverse: false
	    }, {
	        index: 1,
	        title: 'Title: descending',
	        name: 'title',
	        reverse: true
	    }, {
	        index: 2,
	        title: 'Date: ascending',
	        name: 'dateCreated',
	        reverse: false
	    }, {
	        index: 3,
	        title: 'Date: descending',
	        name: 'dateCreated',
	        reverse: true
	    }];

	    init();

	    function init() {
	        recipeSvc
                .getAllRecipe()
                .then(function (response) {
                    $ctrl.recipes = response.data;
                });
	    }

	    $ctrl.setActiveOrderIndex = function (index) {
	        $ctrl.orderIndex = index;
	    }

	    $ctrl.openRecipe = function (id) {
	        $state.go('recipe', { id: id });
	    }

	    $ctrl.openModal = function () {
	        $ctrl.showModal = !$ctrl.showModal;
	    }

	    $ctrl.openAlert = function () {
	        $ctrl.showAlert = !$ctrl.showAlert;
	    }

	    $ctrl.addIngredient = function () {
	        $ctrl.recipe.ingredients.push({
	            name: '',
	            units: ''
	        });
	    }

	    $ctrl.deleteIngredient = function (index) {
	        if ($ctrl.recipe.ingredients.length > 1) {
	            $ctrl.recipe.ingredients.splice(index, 1);
	        }
	    }

	    $ctrl.addRecipe = function () {
	        $ctrl.recipe = emptyRecipe();
	        $ctrl.header = 'Add';
	        $ctrl.openModal();
	    }

	    $ctrl.editRecipe = function (recipe) {
	        $ctrl.recipe = recipe;
	        $ctrl.header = 'Edit';
	        $ctrl.openModal();
	    }

	    $ctrl.deleteRecipe = function (recipe) {
	        $ctrl.recipe = recipe;
	        $ctrl.openAlert();
	    }

	    $ctrl.saveRecipe = function () {

	        if ($ctrl.recipe.id > 0) {
	            recipeSvc
                    .editRecipe($ctrl.recipe)
                    .then(function onSuccess(response) {

                    });
	        } else {
	            recipeSvc
                    .addRecipe($ctrl.recipe)
                    .then(function onSuccess(response) {
                        $ctrl.recipes.push(response.data);                       
                    });
	        }

	        $ctrl.recipe = emptyRecipe();
	        $ctrl.openModal();
	    }

	    $ctrl.submitDeleting = function () {
	        recipeSvc
                    .deleteRecipe($ctrl.recipe.id)
                    .then(function onSuccess(response) {
                        var index = $ctrl.recipes.indexOf($ctrl.recipe);
                        $ctrl.recipes.splice(index, 1);
                        $ctrl.openAlert();
                    });
	    }

	    function emptyRecipe() {
	        return {
	            id: 0,
	            title: '',
	            description: '',
	            ingredients: [{
	                name: '',
	                units: ''
	            }],
	            instructions: ''
	        };
	    }
	}

})();