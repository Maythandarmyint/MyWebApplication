var ContactService = angular.module('ContactService', [])

ContactService.factory('ContactDataOp', function ($http, $q, $window) {
    return {
        getContactList: function () {
            return $http.get('/Contact/Index');
        },

        GetContactId: function () {
            var urlPath = $window.location.href;
            var result = String(urlPath).split("/"); 
            if (result != null && result.length > 0) {
                var id = result[result.length - 1]; 
                return id;
            }
        },

        GetContactByID: function () { 
            var currentContactID = this.GetContactId();
            if (currentContactID != null) {
                return $http.get('/Contact/GetContactById', { params: { id: currentContactID } });
            }
        },

        AddContact: function (data) {
            $http({
                url: '/Contact/Create',
                method: "POST",
                data: data
            }).then(function successCallback(response) {

            }, function errorCallback(response) {

            });
            
        }, 

        DeleteContact: function (Contactid) {
            $http({
                url: '/Contact/Delete' + Contactid,
                method: "POST",
                data: data
            }).then(function successCallback(response) {

            }, function errorCallback(response) {

            });

        }, 

        UpdateContact: function (data) {
            Contact.Id = this.GetContactId();
            $http({
                url: '/Contact/UpdateContact',
                method: "POST",
                data: data
            }).then(function successCallback(response) {

            }, function errorCallback(response) {

            });

        }, 
    }
});