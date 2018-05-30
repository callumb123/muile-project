$(document).ready(function(){
	
	//Calculates the total number of categories we have generated
	//Needs this work around due to how Django generates models
	var totalCategories = ($('#allCategories').children('div').length)*2;
	
	//Initially hides all the English versions so just Gaelic translation showing
	for(i=1; i <= totalCategories+1; i++) {
		$('#categoryEnglishName' + i).hide();
    };


	//Activates whenever a item that contains the string 'current_category' in their id
	$('[id*="current_category"], span').mouseover(function() {
		
		//Grabs id of item that has been hovered over
   		var idNumber = $(this).attr("id").match(/[\d]+$/);
		
		//Switches between Gaelic and English translations
		$('#categoryGaelicName' + idNumber).hide();
		$('#categoryEnglishName' + idNumber).show();
	});

	
	//Same as above but for mouse out
	$('[id*="current_category"]').mouseout(function() {
		var idNumber = $(this).attr("id").match(/[\d]+$/);
		$('#categoryEnglishName' + idNumber).hide();
		$('#categoryGaelicName' + idNumber).show();
	});


	
});
