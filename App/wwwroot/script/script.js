$(document).ready(function(){
    // alert("system initialize");
    $("#hide-sidebar").click(function(){
        var $hideClass = $("aside,section");
        $hideClass.toggleClass("hideClass");
        // console.warn("hiding the sidebar");
        var $sidebarIcon=$("#hide-sidebar i.fa");
    if($("aside").hasClass("hideClass")){
        //$("#hide-sidebar").text(">> Show Sidebar");
        $(".navbar-fixed-top").css({ "margin-left":"0", "transition": "margin-left ease 2s","width":"100%" });
        $sidebarIcon.removeClass("fa-chevron-left");
        $sidebarIcon.addClass("fa-chevron-right");
    }else{
        //$("#hide-sidebar").text("<< Hide Sidebar");
        $(".navbar-fixed-top").css({ "margin-left": "20%", "transition": "margin-left ease 2s","width":"80%" });
        $sidebarIcon.removeClass("fa-chevron-right");
        $sidebarIcon.addClass("fa-chevron-left");
    }
    })

    $("aside nav ul li").hover(function(){
        $(this).children("a").css("color", "#222");
    }, function () {
        $(this).children("a").css("color", "#fff");
    });
})