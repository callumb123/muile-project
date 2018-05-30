# Muile Project

## Project can be found at www.muile.net

### Project Overview
This project was designed and developed alongside the Celtic and Gaelic department at the University of Glasgow and Dress for the Weather. They proposed an application that would allow users to explore a virtual representation of the Isle of Mull, utilising a dataset of place-names and descriptions in both English and Gaelic. This would allow users to learn about the histroy of Mull while also learning some Gaelic words and phrases.

### Public Features
The main features of this project which are available to the public are:
* A Map view which displays all currently known settlements
* A Game version of the map which allows users to discover settlements
* A quiz in the game mode to test users on what they have discovered so far
* The Game is bilingual with both English and Gaelic versions
* Pages for each individual settlement giving more information about it
* Settlements separated by category
* The website is bilingual, originally the site is in gaelic but the user can hover over any Gaelic words to change these to English

### Admin Only Features
These features are only available to the the client:
* A manage page to add/remove categories, settlements and questions
* Ability to upload an excel spreadsheet to populate the database

### How to play Game
The player is first presented with a screen giving a very brief overview of how to play the game.

The user can then select whether they want to play the same in Gaelic or English.

The user is then taken to a first person mode in which they need to discover settlements by walking up to them.

Each time the player has discovered 5 settlements they are taken back to birds eye view and quizzed on all the settlements they have discovered so far.

The player needs to get 3 correct answers before they can then return to first person mode to discover 5 more settlements.

### How to use Map
When the Map version is loaded up all of the settlements are already discovered.

The user can click on a settlement marker to zoom into this.

The user can also then click on a settlement headname to be taken to a page which give more information on that settlement.

To return to bird eye view the user can press escape.

### How to use Manage Page
This page is only accessible to the admin/client.

The user will first need to log in to access this page.

Once they have logged in, the user can view all the categories, settlements and questions currently in the database.

The user can click 'delete' next to any of these to remove this object from the database.

The user can add a new instance of a category, settlement or question by clicking the add button at the top of each of these columns and filling in the relevant details.

The user can also upload an excel spreadsheet to populate the database with categories, settlements and default questions. This file must be in the EXACT format as below:
* First row must either be blank or include headings for each of the columns as this row is ignored during processing.
* The columns must be in the following order: Headname, Grid Reference, Anglicised, Historical Forms, Language of Origin, Original Elements, Interpretation, Value/Extent, Certainty, Place-Name Categories
* Headname can be in any format.
* Grid reference must be in the format 'AA123456'.
* Anglicised can be in any format.
* Historical Forms must be in the format similar to 'calchelle (1494); Callo hailӡe (1509); calchele (1534–1538)'.
* Language of Origin must be in the format 'GaelicVersion | EnglishVersion' such as 'Gàidhlig | Gaelic' or if more than one Language of origin it must be in the format 'GaelicVersion1/GaelicVersion2 | EnglishVersion1/EnglishVersion2' such as 'Gàidhlig/Seann Lochlannais | Gaelic/Old Norse'.
* Original elements can be in any format.
* Interpretation must be in the format 'gaelicInterpretation | englishInterpretation' such as 'coille-challtainn' | 'hazel-wood''.
* Value/Extent must be in the format 'gaelicValue | englishValue' such as 'peighinn | pennyland'.
* Certainty must be an integer between 1-5 inclusive.
* Place-name categories must be in the format 'gaelicCategory | englishCategory' such as 'Craobhan | Trees' or if more than one category must be in the format 'gaelicCategory1; gaelicCategory2 | englishCategory1; englishCategory2' such as 'Cumadh-tìre; Craobhan | Topography; Trees'.
