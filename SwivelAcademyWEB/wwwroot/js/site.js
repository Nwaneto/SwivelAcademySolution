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
                $.ajax({
                    type: "POST",
                    url: "/Student/RegisterForCourse",
                    traditional: true,
                    dataType: "json",
                    contentType: "application/json",
                    data: {
                        Job_Id: cId,
                        UserId: userId
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
