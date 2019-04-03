$(document).ready(function () { 
	
	let $imgMain = $("#img-main");

	$("#test-button").on("click", function () {
		console.log(`You clicked on: ${$(this).text()}`);
		$imgMain.toggle();
		});

});