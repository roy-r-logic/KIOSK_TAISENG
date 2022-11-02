$(document).ready(function(){ 
    $('.page-height').css('height', $(window).height());
});
$(window).resize(function(){ 
    $('.page-height').css('height', $(window).height());
});


$(".closebutton").click(function(){
	$(".box-overlay").hide();
});

$(".number-ok").click(function(){
	$(".box-overlay").hide();
});


 
$('.amount-list .box-amount-number .amount-number').on('click', function(){
    $('.amount-list .box-amount-number .amount-number').removeClass('amount-active');
    $(this).addClass('amount-active');
});