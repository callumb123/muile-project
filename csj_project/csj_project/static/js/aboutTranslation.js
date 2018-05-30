
// switch between the English and Gaelic versions of the text
function changeText(value) {

    // if switching to see English text
    if (value == "English") {

        // hide Gaelic text
        document.getElementById('aboutContainerGaelic').style.display = 'none';
        document.getElementById('aboutHeaderGaelic').style.display = 'none';

        // show English text
        document.getElementById('aboutContainerEnglish').style.display = 'block';
        document.getElementById('aboutHeaderEnglish').style.display = 'block';

        // change the value of the button
        document.getElementById('button').value = 'Gàidhlig';

    // if switching to see Gaelic text
    } else if (value == "Gàidhlig") {

        // hide English text
        document.getElementById('aboutContainerEnglish').style.display = 'none';
        document.getElementById('aboutHeaderEnglish').style.display = 'none';

        // show Gaelic text
        document.getElementById('aboutContainerGaelic').style.display = 'block';
        document.getElementById('aboutHeaderGaelic').style.display = 'block';

        // change the value of the button
        document.getElementById('button').value = 'English';
    }
}
