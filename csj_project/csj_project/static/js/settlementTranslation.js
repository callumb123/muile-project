$(document).ready(function(){


	//Activated whenever an item has the string 'settlementHistoricalForms' in its id and is hovered over
	$('span[id^="settlementHistoricalForms"]').hover(function() {
		
		//Grabs the id number of the current item that has been hovered over
   		var idNumber = $(this).attr("id").match(/[\d]+$/);
		//If the id number is correct then it sets the translated text to that item
		if(idNumber != null){
			$('#settlementHistoricalForms' + idNumber).text("Historical Forms (Year Recorded)");
		}
		else{
			$('#settlementHistoricalForms').text("Historical Forms (Year Recorded)");
		}
	});
	
	//Does the same as above but goes back to Gaelic when mouse leaves
	$('span[id^="settlementHistoricalForms"]').mouseout(function() {
   		var idNumber = $(this).attr("id").match(/[\d]+$/);
		if(idNumber != null){
			$('#settlementHistoricalForms' + idNumber).text("Seann Riochdan (Bliadhna)");
		}
		else{
			$('#settlementHistoricalForms').text("Seann Riochdan (Bliadhna)");
		}
	});


	//The above is then repeated for each piece of information we want to translate

	$('span[id^="settlementEnglishTrans"]').hover(function() {
   		var idNumber = $(this).attr("id").match(/[\d]+$/);
		if(idNumber != null){
			$('#settlementEnglishTrans' + idNumber).text("English Translation");
		}
		else{
			$('#settlementEnglishTrans').text("English Translation");
		}
	});
	$('span[id^="settlementEnglishTrans"]').mouseout(function() {
   		var idNumber = $(this).attr("id").match(/[\d]+$/);
		if(idNumber != null){
			$('#settlementEnglishTrans' + idNumber).text("Eadar-theangachadh Beurla");
		}
		else{
			$('#settlementEnglishTrans').text("Eadar-theangachadh Beurla");
		}
	});



	$('span[id^="settlementLangOfOrigin"]').hover(function() {
   		var idNumber = $(this).attr("id").match(/[\d]+$/);
		if(idNumber != null){
			$('#settlementLangOfOrigin' + idNumber).text("Language of Origin");
		}
		else{
			$('#settlementLangOfOrigin').text("Language of Origin");
		}
	});
	$('span[id^="settlementLangOfOrigin"]').mouseout(function() {
   		var idNumber = $(this).attr("id").match(/[\d]+$/);
		if(idNumber != null){
			$('#settlementLangOfOrigin' + idNumber).text("Cànan");
		}
		else{
			$('#settlementLangOfOrigin').text("Cànan");
		}
	});



	$('span[id^="settlementOriginalElements"]').hover(function() {
   		var idNumber = $(this).attr("id").match(/[\d]+$/);
		if(idNumber != null){
			$('#settlementOriginalElements' + idNumber).text("Original Elements");
		}
		else{
			$('#settlementOriginalElements').text("Original Elements");
		}
	});
	$('span[id^="settlementOriginalElements"]').mouseout(function() {
   		var idNumber = $(this).attr("id").match(/[\d]+$/);
		if(idNumber != null){
			$('#settlementOriginalElements' + idNumber).text("Mìrean Tùsail");
		}
		else{
			$('#settlementOriginalElements').text("Mìrean Tùsail");
		}
	});



	$('span[id^="settlementCertainty"]').hover(function() {
   		var idNumber = $(this).attr("id").match(/[\d]+$/);
		if(idNumber != null){
			$('#settlementCertainty' + idNumber).text("Certainty");
		}
		else{
			$('span[id^="settlementCertainty"]').text("Certainty");
		}
	});
	$('span[id^="settlementCertainty"]').mouseout(function() {
   		var idNumber = $(this).attr("id").match(/[\d]+$/);
		if(idNumber != null){
			$('#settlementCertainty' + idNumber).text("Cinnt");
		}
		else{
			$('span[id^="settlementCertainty"]').text("Cinnt");
		}
	});



    $('span[id^="settlementExtent"]').hover(function() {
        var idNumber = $(this).attr("id").match(/[\d]+$/);
        if(idNumber != null){
            $('#settlementExtent' + idNumber).text("Value/Extent");
        }
        else{
            $('#settlementExtent').text("Value/Extent");
        }
    });
    $('span[id^="settlementExtent"]').mouseout(function() {
        var idNumber = $(this).attr("id").match(/[\d]+$/);
        if(idNumber != null){
            $('#settlementExtent' + idNumber).text("Luach/Meud");
        }
        else{
            $('#settlementExtent').text("Luach/Meud");
        }
    });



    $('span[id^="settlementInterpretation"]').hover(function() {
        var idNumber = $(this).attr("id").match(/[\d]+$/);
        if(idNumber != null){
            $('#settlementInterpretation' + idNumber).text("Interpretation");
        }
        else{
            $('#settlementInterpretation').text("Interpretation");
        }
    });
    $('span[id^="settlementInterpretation"]').mouseout(function() {
        var idNumber = $(this).attr("id").match(/[\d]+$/);
        if(idNumber != null){
            $('#settlementInterpretation' + idNumber).text("Mìneachadh");
        }
        else{
            $('#settlementInterpretation').text("Mìneachadh");
        }
    });

});
