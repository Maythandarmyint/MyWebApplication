var myApp = angular.module('mywebApp', ['ContactService']);

myApp.controller('ContactController', function ($scope, ContactDataOp) {
    $scope.Person = null;
    getContactList();

    function getContactList() {

    }

    $scope.ContactRecord = function (data) {
        $scope.message = '';
        $scope.Contact = data;
        $scope.isFormValid = true; //assume all field has value
        if ($scope.isFormValid) {
            ContactDataOp.AddContact($scope.Contact).then(function (d) { 
                alert(d);
                if (d == 'Success') {
                    ClearForm();
                }
            });
        }
        else {
            $scope.message = 'Please fill the required fields';
        }
    };

});