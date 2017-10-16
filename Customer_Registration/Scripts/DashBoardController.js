var app = angular.module('dashboard', []);




app.controller('ViewRecords', function ($scope, $http) {

    $scope.i = 0;

    $scope.CustomerRecords = null;

    $http({ method: 'get', url: '/api/ViewCustomerRecords', cache: false }).
      
        success(function (data, status) {
            $scope.CustomerRecords = data;
            //alert($scope.CustomerRecords);
        }).
        error(function (data, status) {
            console.log(data + status);
        });


    $http.defaults.headers.get = { 'Accept': 'application/json' };


    
    
    $scope.UpdateCustomerInfo = function (cid, val, param) {

        var value = $("#exampleInput"+param+"_"+cid).val();
        var request = $.ajax({
            url: '/api/UpdateCustomerRecords',
            type: "GET",
            data: {
                cid: cid,
                val: value,
                field: param,
            },
            //  contentType: 'application/xml; charset=utf-8',
            // dataType: "xml

        });

       
        request.done(function (msg) {
           // alert($scope.CustomerRecords)
            //alert("success" + $index);
            //alert(value);
            $("#"+param+"_" + cid).text(value);
            $("#"+param+"_" + cid).removeClass("hidden")
            $("#" + param + "_" + cid).next().addClass("hidden")
        });


    }


});