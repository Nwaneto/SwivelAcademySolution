$(document).ready(function () {
    let table1 = $("#tbl-regCourses").DataTable();
    $.ajax({
        type: "GET",
        url: "/Student/GetRegisteredCourses",
        traditional: true,
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            table1.clear().draw();
            $.each(response, function (index, value) {
                table1.row.add([
                    value.courseID,
                    value.courseTitle,
                    value.courseSyllable,
                    value.teacherName
                ]).draw();
            });
        }
    });
    $.ajax({
        type: "GET",
        url: "/Student/GetAllCourses",
            dataType: "json",
        contentType: "application/json",

        success: function (response) {
            var s = '<option value="">Select a course</option>';
            var drp = $('#drpAllCourses').append(s);
            $.each(response, function (index, value) {
                drp.append('<option value="' + value.courseId + '">' + value.courseName + '</option>');
            });
            console.log(response);
        }
    });
    $("#btnRegisterCourse").on("click", function () {
        $('#frmScreen').validate({
            rules: {
                drpAllCourses: "required"
            },
            submitHandler: function (form) {
                
                var cId = $("#drpAllCourses").val();
                var userId = 1;
                console.log(cId);
                console.log(userId);
                $.ajax({
                    type: "POST",
                    url: "/Student/RegisterForCourse",
                    dataType: "json",
                    traditional: true,               
                    data: {
                        StudentId: cId,
                        Teacher_CourseId: userId
                    },
                    success: function (response) {
                        if (response == true) {
                            location.reload(true);
                        }                        
                    }
                });        
            }
        });
    })







    let table2 = $("#tbl-taughtCourses").DataTable();
    $.ajax({
        type: "GET",
        url: "/Teacher/GetTaughtCourses",
        traditional: true,
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            table2.clear().draw();
            $.each(response, function (index, value) {
                table2.row.add([
                    value.courseID,
                    value.courseTitle,
                    value.courseSyllable
                ]).draw();
            });
        }
    });

    $("#btnTeachCourse").on("click", function () {
        $('#frmScreen2').validate({
            rules: {
                drpAllCourses: "required"
            },
            submitHandler: function (form) {
                var cId = $("#drpAllCourses").val();
                var userId = "1";
                console.log("selected courseId " + cId);
                console.log(userId);
                $.ajax({
                    type: "POST",
                    url: "/Teacher/TeachCourse",
                    dataType: "json",
                    traditional: true,
                    data: {
                        TeacherID: 0,
                        CourseID: cId
                    },
                    success: function (response) {
                        if (response == true) {
                            location.reload(true);
                        }
                    }
                });
            }
        });
    })
})
