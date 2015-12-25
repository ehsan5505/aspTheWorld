$(document).ready(function(){
    // alert("system initialize");
    $("#hide-sidebar").click(function(){
        var $hideClass = $("aside,section");
        $hideClass.toggleClass("hideClass");
        // console.warn("hiding the sidebar");
    
    if($("aside").hasClass("hideClass")){
        $("#hide-sidebar").text(">> Show Sidebar");
    }else{
        $("#hide-sidebar").text("<< Hide Sidebar");
    }
    })
})