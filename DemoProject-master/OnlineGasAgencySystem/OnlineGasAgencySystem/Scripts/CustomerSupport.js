
function getFAQList(companyId) {
    var url = window.location.origin + '/CustomerSupport/GetFAQList?CompanyID=' + companyId;
    $.ajax({
        type: "GET",
        dataType: "json",
        cache: false,
        url: url,
        success: function (result) {
            if (result != null) {
                $("#faqlist").html("");
                for (var i = 0; i < result.length; i++) {
                    $("#faqlist").append(result[i].notimssg);
                 // var option = "<option value=" + result[i].companyId + ">" + result[i].companyName+"</option>";
                }
            }
            else {
                alert("Please Contact customer support");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Error getFAQList ");
        }
    });
}
function getCompanyList() {
    var url = window.location.origin + '/CustomerSupport/GetCompanies';
    $.ajax({
        type: "GET",
        dataType: "json",
        cache: false,
        url: url,
        success: function (result) {
            if (result != null) {
                $("#companyddl").html("");
                var option = "<option value=" + 0+ ">--Select--</option>";
                $("#companyddl").append(option);
                for (var i = 0; i < result.length; i++) {
                     option = "<option value=" + result[i].companyid + ">" + result[i].companyname+"</option>";
                    $("#companyddl").append(option);
                }
            }
            else {
                alert("Please Contact customer support");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Error getCompanyList ");
        }
    });
}



jQuery(function () {
    getCompanyList();

    $("#companyddl").change(function () {
        var companyID = $("#companyddl").val();
        if (companyID != 0) {
            getFAQList(companyID);
        }
        else {
            $("#faqlist").html("");
        }
    });
   
});