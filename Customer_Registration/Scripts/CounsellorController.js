var app = angular.module('CounsellorApp', [])

app.directive('datetimepicker', function () {
    return {
        restrict: 'E',
        scope: { value: '=' },
        template: "<select id='Days' ng-model='user.selectedDay'><option ng-repeat='day in days' ng-selected='day==currDay' value='{{day}}'>{{day}}</option></select>/<select id='months' ng-model='user.selectedMonth'><option ng-repeat='month in months' ng-selected='month==currMonth' value='{{month}}'>{{month}}</option></select>/<select id='years' ng-model='user.selectedYear'><option ng-repeat='year in years' ng-selected='year==CurrYear' value='{{year}}'>{{year}}</option></select>&nbsp;&nbsp;<select id='Hours' ng-model='user.Hour'><option ng-repeat='hour in hours' ng-selected='hour==CurrentHour' value='{{hour}}'>{{hour}}</option></select>:<select id='Minutes' ng-model='user.Minute'><option ng-repeat='minute in minutes' ng-selected='minute==CurrentMinute' value='{{minute}}'>{{minute}}</option></select>"
        ,
        link: function ($scope, el) {
            document.getElementById('Days').onchange = function () {
                //     alert($("#Days").val());
                $scope.changeDay($("#Days").val());
            };
            document.getElementById('months').onchange = function () {
                //   alert($("#months").val());
                $scope.changeMonth($("#months").val());
            };
            document.getElementById('years').onchange = function () {
                // alert($("#years").val());
                $scope.changeYear($("#years").val());
            };
            document.getElementById('Hours').onchange = function () {
                // alert($("#Hours").val());
                $scope.changeHour($("#Hours").val());
            };
            document.getElementById('Minutes').onchange = function () {
                // alert($("#Minutes").val());
                $scope.changeMinute($("#Minutes").val());
            };

        },
        controller: function ($scope, $element) {
            $scope.totaldays = 31;
            $scope.totalmonths = 12;
            $scope.totalyears = 150;
            $scope.totalHours = 24;
            $scope.totalMinutes = 60;

            $scope.days = [];
            $scope.currDay = new Date().getDate();
            for (var i = 0; i < $scope.totaldays; i += 1) {
                $scope.days.push(i + 1);
            }
            $scope.months = [];
            $scope.currMonth = new Date().getMonth() + 1;
            for (var i = 0; i < $scope.totalmonths; i += 1) {
                $scope.months.push(i + 1);
            }

            $scope.years = [];
            var currentYear = new Date().getFullYear();
            $scope.CurrYear = currentYear;
            for (var i = currentYear; i > currentYear - $scope.totalyears; i--) {
                $scope.years.push(i);
            }

            var prefix = "";
            $scope.hours = [];
            $scope.CurrentHour = new Date().getHours();
            for (var i = 0; i < $scope.totalHours; i += 1) {
                if (i >= 0 && i < 10) {
                    prefix = "0" + i;
                    //alert(prefix);
                }
                else {
                    prefix = i;
                }
                $scope.hours.push(prefix);
            }
            $scope.minutes = [];
            $scope.CurrentMinute = new Date().getMinutes();
            for (var i = 0; i < $scope.totalMinutes; i += 1) {
                if (i >= 0 && i < 10)
                    prefix = "0" + i;
                else
                    prefix = i;
                $scope.minutes.push(prefix);
            }
            var dateofbirth = new Array(currentYear, $scope.currMonth, $scope.currDay, $scope.CurrentHour, $scope.CurrentMinute);

            $scope.value = currentYear + "-" + $scope.currMonth + "-" + $scope.currDay + " " + $scope.CurrentHour + ":" + $scope.CurrentMinute;

            // $scope.user.selectedDay = $scope.currDay;

            $scope.changeDay = function (newValue) {
                $scope.$apply(function () {
                    $scope.user.selectedDay = newValue;
                    dateofbirth[2] = newValue;
                    $scope.value = dateofbirth[0] + "-" + dateofbirth[1] + "-" + dateofbirth[2] + " " + dateofbirth[3] + ":" + dateofbirth[4];

                });
            }
            $scope.changeMonth = function (newValue) {
                $scope.$apply(function () {
                    $scope.user.selectedMonth = newValue;
                    dateofbirth[1] = newValue;
                    $scope.value = dateofbirth[0] + "-" + dateofbirth[1] + "-" + dateofbirth[2] + " " + dateofbirth[3] + ":" + dateofbirth[4];

                });
            }
            $scope.changeYear = function (newValue) {
                $scope.$apply(function () {
                    $scope.user.selectedYear = newValue;
                    dateofbirth[0] = newValue;
                    $scope.value = dateofbirth[0] + "-" + dateofbirth[1] + "-" + dateofbirth[2] + " " + dateofbirth[3] + ":" + dateofbirth[4];

                });
            }
            $scope.changeHour = function (newValue) {
                $scope.$apply(function () {
                    $scope.user.Hour = newValue;
                    dateofbirth[3] = newValue;
                    $scope.value = dateofbirth[0] + "-" + dateofbirth[1] + "-" + dateofbirth[2] + " " + dateofbirth[3] + ":" + dateofbirth[4];

                });
            }
            $scope.changeMinute = function (newValue) {
                $scope.$apply(function () {
                    $scope.user.Minute = newValue;
                    dateofbirth[4] = newValue;
                    $scope.value = dateofbirth[0] + "-" + dateofbirth[1] + "-" + dateofbirth[2] + " " + dateofbirth[3] + ":" + dateofbirth[4];

                });
            }

        }
    };

});





// This is the Angular Controller function call used in ng-Controller
function RegisterController($scope, $element, $http) {
    var registrationForm = $($element);
    $scope.datetimepick = 'initial value';

    $scope.user = {};
    $scope.loading = false;
    $scope.isInvalid = function () {
        return !registrationForm.form('validate form');
    };


    $scope.showGoogleMap = function () {

        $("#dialog").dialog({
            height: 320,
            width: 788,
            minheight: 96,
            maxheight: 1000
        });

    }
    /*  name: $scope.user.givenname,
                 surname: $scope.user.surname,
                 email: $scope.user.email,
                 dateofbirth: $scope.datetimepick,
                 username: $scope.user.username,
                 password: $scope.user.password*/
    $scope.register = function () {
        // alert($scope.datetimepick)
        if (this.isInvalid()) {
            return;
        }
        debugger;
        this.loading = true;


        var Counsellor = new Object();// JSON.stringify({ 'value': $scope.user.surname });

        Counsellor.surname = $scope.user.surname;

        $http({
            url: "Counsellor/Register1",
            dataType: 'json',
            method: 'POST',
            data: Counsellor,
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            $scope.value = response;
        }).error(function (error) {
                alert(error);
            });


        // To call the Web API throgh ajax post() to send the Angular Model (ng-Model)
     /*   var request = $.ajax({
            url: '/api/Registration',
            type: "POST",
            data: counsellorData,
            contentType: 'application/json',
            dataType: "json"

        });

        request.done(function (msg) {
            // alert($scope.user.selectedDay)

            $scope.loading = false;
            //alert(msg);
            if (msg.trim() == "Success") {
                $("#Loading").html("Thanks for Registering our Website!! <a href='/'>Click here</a> to exit  :)");
                // $scope.loading = false;
                jAlert('Thanks for Registering our Website!!', 'Registration is Successful');
                //$scope.user.givenname = "";
                //$('.ui.form').reset();
                document.getElementById("GivenName").Value = "";
                document.getElementById("Surname").Value = "";
                document.getElementById("Email").Value = "";
                document.getElementById("Username").Value = "";
                // document.getElementById("Password").Value = "";
                //document.getElementById("PasswordConfirm").Value = "";

            }
            else {
                $("#Loading").text("Registration is unsuccessful!! Please try again");
                jAlert('Registering Unsuccessful!!Please try again', 'Registration is Unsuccessful');
            }
            //this.loading = true;

            console.debug("saved comment", msg);
        });
     
        request.fail(function (jqXHR, textStatus) {
            //      alert("Request failed: " + textStatus);
            $("#Loading").text("Registration is unsuccessful!! Please try again");
            jAlert('Registering Unsuccessful!!Please try again', 'Registration is Unsuccessful');

        });   */
        // this.loading = false;
        /*   $http(req).success(function (data,status) {
               this.loading = false;
               alert(data + status);
           }).error(function (data, status) {
               alert(status);
           });*/

        console.log(this.user);
    };

}


