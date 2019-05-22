studentApp.service("studentAngularService", function ($http) {
    //GET ALL STUDENTS
    this.getAllStudents = function () {
        var response = $http({
            method: 'GET',
            url: 'Student/GetAllStudents',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8'
        });
        return response;
    }

    //GET STUDENT    
    this.getStudentById = function (st) {
        var response = $http({
            method: 'GET',
            url: 'Student/GetStudentById',
            params: {
                id: st.StudentID
            },
            dataType: 'json',
            contentType: 'application/json; charset=utf-8'
        });
        return response;
    }

    //INSERT STUDENT   
    this.insertStudent = function (stObject) {       
        var response = $http({
            method: 'POST',
            url: 'Student/InsertStudent',
            data: JSON.stringify(stObject),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8'
        });
        return response;
    }

    //UPDATE STUDENT   
    this.updateStudent = function (stObject) {        
        var response = $http({
            method: 'POST',
            url: 'Student/UpdateStudent',
            data: JSON.stringify(stObject),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8'
        });
        return response;
    }

    //DELETE STUDENT    
    this.deleteStudent = function (st) {
        var response = $http({
            method: 'POST',
            url: 'Student/DeleteStudent',
            params: {
                id: st.StudentID
            },
            dataType: 'json',
            contentType: 'application/json; charset=utf-8'
        });
        return response;
    }   
});