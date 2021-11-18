var HeadPortrait = document.getElementById("HeadPortrait");
var selectTitle = document.getElementById("selectTitle");

HeadPortrait.onmousemove = function ()
{
    selectTitle.style.display = "block";
}
HeadPortrait.onmouseout = function ()
{
    selectTitle.style.display = "none";
}