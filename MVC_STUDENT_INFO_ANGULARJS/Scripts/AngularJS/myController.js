myApp.controller("myAngularController", function ($scope, myAngularService) {
    $scope.attendance = {
        value: true       
    };
    //GET ALL STUDENTS
    GetAllStudents();
    function GetAllStudents() {
        var stObj = myAngularService.getAllStudents();
        stObj.then(function (st) {
            $scope.Students = st.data;
        }, function (error) {

        })
    }

    ////GET AN STUDENT
    $scope.GetAnStudent = function (st) {
        var stObj = myAngularService.getStudentById(st);
        stObj.then(function (response) {
            if (response.data) {
                $scope.studentID = response.data.StudentID
                $scope.name = response.data.Name;
                $scope.class = response.data.Class;
                $scope.age = response.data.Age;
                $scope.presentAddress = response.data.PresentAddress;
                $scope.permanentAddress = response.data.PermanentAddress;
                $scope.attendance.value = response.data.Attendance == 1 ? true : false;

                $('#studentId').val($scope.studentID);
                $('#name').val($scope.name);
                $('#class').val($scope.class);
                $('#age').val($scope.age);
                $('#presentAddress').val($scope.presentAddress);
                $('#permanentAddress').val($scope.permanentAddress);
                $('#chkAttendance').val($scope.attendance.value);
               
                $('#myModal').modal('show');
                $('#btnUpdate').show();
                $('#btnAdd').hide();

                $('#name').css('border-color', 'lightgrey');
                $('#class').css('border-color', 'lightgrey');
                $('#age').css('border-color', 'lightgrey');
                $('#presentAddress').css('border-color', 'lightgrey');
                $('#permanentAddress').css('border-color', 'lightgrey');
            }
        }, function (error) {

        })
    }

    //INSERT STUDENT
    $scope.InsertStudent = function () {
        var val = Validation();
        if (val == false) {
            return false;
        }
        var stObject = {
            Name: $scope.name,
            Class: $scope.class,
            Age: $scope.age,
            PresentAddress: $scope.presentAddress,
            PermanentAddress: $scope.permanentAddress,
            Attendance: $scope.attendance.value == true ? 1 : 0
        };
        var stObj = myAngularService.insertStudent(stObject);
        stObj.then(function (success) {
            GetAllStudents();
            $('#myModal').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();           
        }, function (error) {

        })
    }

    //UPDATE STUDENT
    $scope.UpdateStudent = function () {
        var val = Validation();
        if (val == false) {
            return false;
        }
        var stObject = {
            StudentID: $scope.studentID,
            Name: $scope.name,
            Class: $scope.class,           
            Age: $scope.age,
            PresentAddress: $scope.presentAddress,
            PermanentAddress: $scope.permanentAddress,
            Attendance: $scope.attendance.value == true ? 1 : 0
        };
        var stObj = myAngularService.updateStudent(stObject);       
        stObj.then(function (response) {
            GetAllStudents();
            $('#myModal').modal('hide');
        }, function (error) {

        })
    }

    //DELETE STUDENT
    $scope.DeleteStudent = function (st) {
        var stObj = myAngularService.deleteStudent(st);
        stObj.then(function (success) {
            GetAllStudents();
        }, function (error) {

        })
    }
    
    $scope.ClearForm = function () {
        $scope.studentID = "";
        $scope.name = "";
        $scope.class = "";
        $scope.age = "";
        $scope.presentAddress = "";
        $scope.permanentAddress = "";
        $scope.attendance.value = false;

        $('#btnUpdate').hide();
        $('#btnAdd').show();

        $('#name').css('border-color', 'lightgrey');
        $('#class').css('border-color', 'lightgrey');
        $('#age').css('border-color', 'lightgrey');
        $('#presentAddress').css('border-color', 'lightgrey');
        $('#permanentAddress').css('border-color', 'lightgrey');        
    }

    function Validation() {
        var isValid = true;

        if ($('#name').val().trim() == "") {
            $('#name').css('border-color', 'red');
            isValid = false;
        }
        else {
            $('#name').css('border-color', 'lightgrey');
        }
        if ($('#class').val().trim() == "") {
            $('#class').css('border-color', 'red');
            isValid = false;
        }
        else {
            $('#class').css('border-color', 'lightgrey');
        }
        if ($('#age').val().trim() == "") {
            $('#age').css('border-color', 'red');
            isValid = false;
        }
        else {
            $('#age').css('border-color', 'lightgrey');
        }

        if ($('#presentAddress').val().trim() == "") {
            $('#presentAddress').css('border-color', 'red');
            isValid = false;
        }
        else {
            $('#presentAddress').css('border-color', 'lightgrey');
        }

        if ($('#permanentAddress').val().trim() == "") {
            $('#permanentAddress').css('border-color', 'red');
            isValid = false;
        }
        else {
            $('#permanentAddress').css('border-color', 'lightgrey');
        }

        return isValid;
    }
});