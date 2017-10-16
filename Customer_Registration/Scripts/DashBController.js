
var app = angular.module('dashboard', ['chart.js']);


app.controller("LineCtrl1", function ($scope, $http) {
  var lab = new Array();
  var ser = new Array();
  $scope.Records = null;
  $http({ method: 'get', url: '/api/DashBoardUpdates?id=1', cache: false }).

        success(function (data, status) {
          $scope.Records = data;
          //alert($scope.Records[0].count_customer);
          //$.each($scope.Records, function (i, obj) {
          /* if ($scope.Records[i].dateofbirth != null) {
             //alert($scope.Records[i].count_customer);
             lab.push($scope.Records[i].count_customer);
             ser.push($scope.Records[i].dateofbirth);
           }*/
          // if ($scope.Records[i].Created_Time != null) {
          //alert($scope.Records[i].count_customer);
          // lab.push($scope.Records[i].count_customer);
          // ser.push($scope.Records[i].Created_Time);
          //}

          //})
          $scope.temp = "";
          //   $scope.data = lab;
          $scope.labels = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"];
     //     alert($scope.labels)
          for (var i = 0; i < $scope.labels.length; i++) {
            $scope.temp = "0";
            for (var j = 0; j < $scope.Records.length; j++)//0 3 5
            {
              if (parseInt($scope.labels[i]) == parseInt($scope.Records[j].Created_Time)) {
                ser.push(parseInt($scope.Records[j].count_customer))
                $scope.temp = "1";
                break;
              }
            }
            if ($scope.temp == "0")
              ser.push(parseInt("0"));
          }
       //   alert(ser);
          $scope.series = ['Series A'];
          $scope.data = [
            ser
          ];
          // alert(ser + lab)
          $scope.onClick = function (points, evt) {
            console.log(points, evt);
          };

        }).
        error(function (data, status) {
          console.log(data + status);
        });

  // alert();
  $http.defaults.headers.get = { 'Accept': 'application/json' };


});

app.controller("LineCtrl2", function ($scope, $http) {
  var lab = new Array();
  var ser = new Array();
  $scope.Records = null;
  $http({ method: 'get', url: '/api/DashBoardUpdates', cache: false }).

        success(function (data, status) {
          $scope.Records = data;
          //alert($scope.Records[0].count_customer);
          $.each($scope.Records, function (i, obj) {
           if ($scope.Records[i].dateofbirth != null) {
             //alert($scope.Records[i].count_customer);
             ser.push($scope.Records[i].count_customer);
             lab.push($scope.Records[i].dateofbirth);
           }
          // if ($scope.Records[i].Created_Time != null) {
          //alert($scope.Records[i].count_customer);
          // lab.push($scope.Records[i].count_customer);
          // ser.push($scope.Records[i].Created_Time);
          //}

          })
          //   $scope.data = lab;
          //$scope.labels = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"];
          $scope.labels = lab;
        //  alert($scope.labels)
         // alert(ser);
          $scope.series = ['Series B'];
          $scope.data = [
            ser
          ];
          // alert(ser + lab)
          $scope.onClick1 = function (points, evt) {
            console.log(points, evt);
          };

        }).
        error(function (data, status) {
          console.log(data + status);
        });

  // alert();
  $http.defaults.headers.get = { 'Accept': 'application/json' };


});



