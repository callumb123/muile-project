# -*- coding: utf-8 -*-

import os
os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'csj_project.settings')

import django
django.setup()
from mullproject.models import Category, Settlement, Question

# define objects and add them to database
# adds categories, settlements, and then questions
def populate():

    # list of categories to be added
    categories = [
		{"gaelic_name": "Tuineachadh",
		"english_name": "Habitation"
		},
		{"gaelic_name": "Cumadh-tìre",
		"english_name": "Topography"
		},
		{"gaelic_name": "Craobhan",
		"english_name": "Trees"
		},
		{"gaelic_name": "Crìostachd",
		"english_name": "Christianity"
		},
		{"gaelic_name": "Inilt is Sprèidh",
		"english_name": "Pastoral Farming/Livestock"
		},
		{"gaelic_name": "Tional",
		"english_name": "Assembly"
		},
		{"gaelic_name": "Uisge",
		"english_name": "Water"
		},
		{"gaelic_name": "Daoine",
		"english_name": "Individuals"
		},
        {"gaelic_name": "Gàidhlig",
        "english_name": "Gaelic"
        },
        {"gaelic_name": "Seann Lochlannais",
        "english_name": "Old Norse"
        }
    ]

    # add each category to database
    for category in categories:
        add_category(category["gaelic_name"], category["english_name"])

    # list of settlements to be added
    settlements = [
			{"headname":"Call-Choille",
			"anglicised":"Callachally",
			"grid_ref":"NM591422",
			"historical_forms":"calchelle (1494); Callo hailӡe (1509); calchele (1534–1538)",
            "lang_of_origin":"Gaelic",
            "original_elements":"call + coille",
            "interpretation":"'coille-challtainn' | 'hazel-wood'",
            "extent":"Pennyland",
            "certainty":"4",
            "categories":["Gaelic", "Trees"]
			},
			{"headname":"Dibeadail",
			"anglicised":"Glenlibidil",
			"grid_ref":"NM667223",
			"historical_forms":"debedell (1494); Debadill (1509)",
            "lang_of_origin":"Old Norse",
            "original_elements":"djúp(r) + dal(r)",
            "interpretation":"domhain-ghleann' | 'deep dale'",
            "extent":"Half-Pennyland",
            "certainty":"4",
            "categories":["Old Norse", "Topography"]
			},
            {"headname":"Druim nan Taighean",
			"anglicised":"Drimnatain",
			"grid_ref":"NM697269",
			"historical_forms":"drumnatyin (1494)",
            "lang_of_origin":"Gaelic",
            "original_elements":"druim + nan + taighean",
            "interpretation":"druim nan taighean' | 'dwellings-ridge'",
            "extent":"Pennyland",
            "certainty":"4",
            "categories":["Gaelic", "Habitation", "Topography"]
			},
            {"headname":"Garbh-Mhòine",
			"anglicised":"Garmony",
			"grid_ref":"NM669403",
			"historical_forms":"garemown (1494); Garmoney (1509)",
            "lang_of_origin":"Gaelic",
            "original_elements":"garbh + mòine",
            "interpretation":"garbh-mhòine' | 'rough/broad peat-moss/moor'",
            "extent":"Pennyland",
            "certainty":"4",
            "categories":["Gaelic", "Topography"]
			},
            {"headname":"Garbh-Mhòine Riabhach",
			"anglicised":"Garmonyreoch",
			"grid_ref":"NM674257",
			"historical_forms":"garmown (1494); Garmoney (1509); Garmonroch (1801)",
            "lang_of_origin":"Gaelic",
            "original_elements":"Garmony + riabhach",
            "interpretation":"Garbh-mhòine riabhach' | 'striped Garmony' (='garbh-mhòine' | 'rough/broad peat-moss/moor')",
            "extent":"Half-Pennyland",
            "certainty":"4",
            "categories":["Gaelic", "Topography"]
			},
            {"headname":"Ceann Loch Speilbh",
			"anglicised":"Kinlochspelve",
			"grid_ref":"NM654261",
			"historical_forms":"chanloch spelow (1494)",
            "lang_of_origin":"Gaelic",
            "original_elements":"ceann + Loch Speilbh",
            "interpretation":"ceann Loch Speilbh' (='loch speile(adh)'?) | 'head of Loch Spelve' ('cattle-/herd-/flock-loch'?)",
            "extent":"Pennyland",
            "certainty":"4",
            "categories":["Gaelic", "Water"]
			},
            {"headname":"Leitir",
			"anglicised":"Leiter",
			"grid_ref":"NM637418",
			"historical_forms":"lett arna creill (1494); Lettir (1509); letter ardnacreile (1534–1538)",
            "lang_of_origin":"Gaelic",
            "original_elements":"leitir",
            "interpretation":"leitir' | 'steep, even slope'",
            "extent":"Pennyland",
            "certainty":"5",
            "categories":["Gaelic", "Topography"]
			},
            {"headname":"Moigh",
			"anglicised":"Moy",
			"grid_ref":"NM616247",
			"historical_forms":"moy (1494)",
            "lang_of_origin":"Gaelic",
            "original_elements":"magh",
            "interpretation":"moigh' (an tuiseal roimhearach) | 'plain' (dative case)",
            "extent":"Pennyland",
            "certainty":"5",
            "categories":["Gaelic", "Topography"]
			},
            {"headname":"Peighinn a' Ghobhainn",
			"anglicised":"Pennygown",
			"grid_ref":"NM599427",
			"historical_forms":"pengowyn (1494); penӡegovne (1509); pengowin & pengowyne (1534–1538)",
            "lang_of_origin":"Gaelic",
            "original_elements":"peighinn + gobha",
            "interpretation":"peighinn a' ghobhainn' | 'smith's pennyland'",
            "extent":"Pennyland",
            "certainty":"4",
            "categories":["Gaelic", "Individuals"]
			},
            {"headname":"Ròthaill",
			"anglicised":"Rhoail",
			"grid_ref":"NM632373",
			"historical_forms":"russillis (1494); Rouseilӡemoir & Rouseilӡebeg (1509); Rousillis (1534–1538); Rohill (1801)",
            "lang_of_origin":"Old Norse",
            "original_elements":"hross + vǫll(r)",
            "interpretation":"each-raon/-raointean / làir-raon/-raointean' | 'horse-/mare-field(s)'",
            "extent":"Pennyland",
            "certainty":"4",
            "categories":["Old Norse", "Pastoral Farming/Livestock"]
			},
            {"headname":"Rosal",
			"anglicised":"Rossal",
			"grid_ref":"NM541279",
			"historical_forms":"Roysale (1494); Rossale (1509)",
            "lang_of_origin":"Old Norse",
            "original_elements":"hross + vǫll(r)",
            "interpretation":"each-raon/-raointean / làir-raon/-raointean' | 'horse-/mare-field(s)'",
            "extent":"Pennyland",
            "certainty":"4",
            "categories":["Old Norse", "Pastoral Farming/Livestock"]
			},
            {"headname":"Tòrr an Lochain",
			"anglicised":"Torlochan",
			"grid_ref":"NM556408",
			"historical_forms":"Torulochan (1509); Torlochan (1654)",
            "lang_of_origin":"Gaelic",
            "original_elements":"tòrr + an + lochan",
            "interpretation":"tòrr an lochain' | '(conical) knoll of the wee loch'",
            "extent":"Pennyland",
            "certainty":"4",
            "categories":["Gaelic", "Topography", "Water"]
			},
            {"headname":"Aon Stapall",
			"anglicised":"Aon Stapall",
			"grid_ref":"NM602248",
			"historical_forms":"Instaple (1509); Druim an Aon Stapuill (1868–1878)",
            "lang_of_origin":"Old Norse",
            "original_elements":"inn-stǫpul(l) (?)",
            "interpretation":"staigh-cholbh' / 'àrd-ùrlar' (?) | 'inner pillar/raised platform' (?)",
            "extent":"Half-Pennyland",
            "certainty":"3",
            "categories":["Old Norse", "Topography"]
			},
            {"headname":"Àrd nan Sailghean/Àird(e) nan Sailghean",
			"anglicised":"Àrd nan Sailghean/Àird(e) nan Sailghean",
			"grid_ref":"NM716266",
			"historical_forms":"ardnesaleyn (1494)",
            "lang_of_origin":"Gaelic",
            "original_elements":"àrd/àird(e) + nan + sailghean",
            "interpretation":"àrd/àird(e) nan seileach' | ‘height/promontory of the willows’",
            "extent":"Pennyland",
            "certainty":"3",
            "categories":["Gaelic", "Topography", "Trees"]
			},
            {"headname":"Beirgh Aon-Dromain",
			"anglicised":"Barachandroman",
			"grid_ref":"NM657255",
			"historical_forms":"berch antroman (1494)",
            "lang_of_origin":"Gaelic",
            "original_elements":"beirgh + aondroman/Aondroman (?)",
            "interpretation":"creag aondromain/Aondromain' (?) | ‘rocky prominence of a single small ridge/of Aondroman’ (='single small ridge') (?)",
            "extent":"Half-Pennyland",
            "certainty":"2",
            "categories":["Gaelic", "Topography"]
			},
            {"headname":"Bradhadail",
			"anglicised":"Bradhadail",
			"grid_ref":"NM610347",
			"historical_forms":"brayadill (1494)",
            "lang_of_origin":"Old Norse",
            "original_elements":"Bragi + dal(r)",
            "interpretation":"gleann Bhragi' | 'Bragi's dale'",
            "extent":"Pennyland",
            "certainty":"3",
            "categories":["Old Norse", "Individuals", "Topography"]
			},
            {"headname":"Cam-Shròn/Cam-Roinn",
			"anglicised":"Cameron",
			"grid_ref":"NM602250",
			"historical_forms":"Camroyn (1494)",
            "lang_of_origin":"Gaelic",
            "original_elements":"cam + sròn/roinn",
            "interpretation":"cam-shròn/cam-roinn' | ‘crooked nose of land/crooked portion’",
            "extent":"Pennyland",
            "certainty":"3",
            "categories":["Gaelic", "Topography"]
			},
            {"headname":"Cuaille",
			"anglicised":"Cuaille",
			"grid_ref":"NM686261",
			"historical_forms":"kowillay (1494); Caulӡea (1509); kowillay (1534–1538)",
            "lang_of_origin":"Gaelic",
            "original_elements":"cuaille",
            "interpretation":"cuaille' | ‘baton-shaped feature’",
            "extent":"Pennyland",
            "certainty":"3",
            "categories":["Gaelic", "Topography"]
			},
            {"headname":"Crosta",
			"anglicised":"Crosta",
			"grid_ref":"NM593247",
			"historical_forms":"crosta (1494); Le croft (1509); crosta (1534–1538)",
            "lang_of_origin":"Old Norse",
            "original_elements":"kross + staðir  (?)",
            "interpretation":"crois-bhaile' (?) | 'cross-place' (?)",
            "extent":"Half-Pennyland",
            "certainty":"3",
            "categories":["Old Norse", "Christianity", "Habitation"]
			},
            {"headname":"Doire nan Cuaillean",
			"anglicised":"Derrynaculen",
			"grid_ref":"NM566291",
			"historical_forms":"darnakowlane (1494); Deryminguillam (1509); derrnakowlane (1534 × 1538)",
            "lang_of_origin":"Gaelic",
            "original_elements":"doire + nan + cuaillean (?)",
            "interpretation":"doire nan cuaillean' (?) | 'batons-grove' (?)",
            "extent":"Half-Pennyland",
            "certainty":"3",
            "categories":["Gaelic", "Trees"]
			},
            {"headname":"Dìosgag",
			"anglicised":"Dìosgag",
			"grid_ref":"NM630237",
			"historical_forms":"desgaig (1494); Deescage (1509); deisgaig (1534–1538)",
            "lang_of_origin":"Gaelic(?)",
            "original_elements":"dìosg + -ag (?)",
            "interpretation":"seasg-abhainn' (?) | 'barren river' (?)",
            "extent":"Half-Pennyland",
            "certainty":"3",
            "categories":["Gaelic", "Water"]
			},
            {"headname":"Foinnse-Innis",
			"anglicised":"Fishnish",
			"grid_ref":"NM648417",
			"historical_forms":"fynchenis (1494); Fenschenis (1509); finchennis (1534–1538)",
            "lang_of_origin":"Gaelic",
            "original_elements":"foinnse + innis (?)",
            "interpretation":"uinnseann-innis' (?) | ‘ash-tree-peninsula/-headland’ (?)",
            "extent":"Pennyland",
            "certainty":"3",
            "categories":["Gaelic", "Trees", "Topography"]
			},
            {"headname":"Gaoideil",
			"anglicised":"Gaodhail",
			"grid_ref":"NM610386",
			"historical_forms":"gyeddrill (1494); Gydgraule (1509); gyeddrol & gyeddyoll (1534–1538)",
            "lang_of_origin":"Old Norse",
            "original_elements":"geit + vǫll(r)",
            "interpretation":"gobhar-raon/-raointean' (?) | 'nanny-goat-field(s)'",
            "extent":"Pennyland",
            "certainty":"3",
            "categories":["Old Norse", "Pastoral Farming/Livestock"]
			},
            {"headname":"Gleann Bèire",
			"anglicised":"Glenbyre",
			"grid_ref":"NM585235",
			"historical_forms":"glenbayr 1494; Glenbaer (1509); glenbair (1534–1538)",
            "lang_of_origin":"Gaelic",
            "original_elements":"gleann + beur (?)",
            "interpretation":"gleann bèire' (?) | ‘point-/pinnacle-glen’ (?)",
            "extent":"Pennyland",
            "certainty":"3",
            "categories":["Gaelic", "Topography"]
			},
            {"headname":"Grùilinn",
			"anglicised":"Gruline",
			"grid_ref":"NM547398",
			"historical_forms":"growding (1494); Crowding (1509); growding (1534–1538)",
            "lang_of_origin":"Old Norse",
            "original_elements":"grjót + þing/-ing(r)",
            "interpretation":"eireachd/àite nan clach' (?) | 'stones-assembly-site/stones-place’ (?)",
            "extent":"Two Pennylands",
            "certainty":"3",
            "categories":["Old Norse", "Assembly", "Topography"]
			},
            {"headname":"Iaradail",
			"anglicised":"Iaradail",
			"grid_ref":"NM679234",
			"historical_forms":"Iuredill (1494); Juredill (1509); Iuredill (1534–1538)",
            "lang_of_origin":"Old Norse",
            "original_elements":"jǫrf(i) + dal(r)",
            "interpretation":"grinneal-ghleann' | 'gravel-dale'",
            "extent":"Half-Pennyland",
            "certainty":"3",
            "categories":["Old Norse", "Topography"]
			},
            {"headname":"Aoineadh-Ghart",
			"anglicised":"Inagart",
			"grid_ref":"NM574228",
			"historical_forms":"Inegard (1494)",
            "lang_of_origin":"Gaelic/Old Norse",
            "original_elements":"aoineadh + gart / enni + garð(r)",
            "interpretation":"aoineadh-ghart' | ‘precipice-farm/-enclosure’",
            "extent":"Half-Pennyland",
            "certainty":"3",
            "categories":["Gaelic", "Old Norse", "Topography", "Habitation"]
			},
            {"headname":"Cill Bheag/Coille Bheag",
			"anglicised":"Killbeg",
			"grid_ref":"NM602416",
			"historical_forms":"kelbeg (1494); Killebeg (1509); kelbeg (1538)",
            "lang_of_origin":"Gaelic",
            "original_elements":"cill/coille + Beag (?)",
            "interpretation":"cill/coille Bheag' | ‘(St) Béc’s/(St) Becc’s church/wood’ (?)",
            "extent":"Pennyland",
            "certainty":"3",
            "categories":["Gaelic", "Christianity", "Trees", "Individuals"]
			},
            {"headname":"Lagan",
			"anglicised":"Laggan",
			"grid_ref":"NM628238",
			"historical_forms":"lagane (1494)",
            "lang_of_origin":"Gaelic",
            "original_elements":"lagan (?)",
            "interpretation":"lagan' | 'monastery' (?)",
            "extent":"Two Pennylands",
            "certainty":"4",
            "categories":["Gaelic", "Christianity"]
			},
            {"headname":"Teamhair",
			"anglicised":"Ceann Chnocain",
			"grid_ref":"NM640344",
			"historical_forms":"chowour (1494); Tuochir (1509); chowoure (1534–1538)",
            "lang_of_origin":"Gaelic",
            "original_elements":"teamhair",
            "interpretation":"àite seunta/cnoc' | 'sacred place/eminence'",
            "extent":"Half-Pennyland",
            "certainty":"3",
            "categories":["Gaelic", "Assembly", "Topography"]
			},
            {"headname":"Tòn-Slèibhe Bheag",
			"anglicised":"Tomslèibhe",
			"grid_ref":"NM617372",
			"historical_forms":"toslebeg (1494); Tonsliebeg (1509); toslebeg (1534–1538)",
            "lang_of_origin":"Gaelic",
            "original_elements":"Tòn Slèibhe + beag",
            "interpretation":"Tòn Slèibhe beag' | ‘wee Tòn Slèibhe' (='rump/end of pasture/moorland’)",
            "extent":"Farthingland",
            "certainty":"3",
            "categories":["Gaelic", "Topography", "Pastoral Farming/Livestock"]
			},
            {"headname":"Corrach",
			"anglicised":"Còrrachadh",
			"grid_ref":"NM613395",
			"historical_forms":"coroch (1494); Corrachy (1509); coroch (1534–1538)",
            "lang_of_origin":"Gaelic",
            "original_elements":"corrach / corr/corr/corra + -ach",
            "interpretation":"càrr' / 'àite biorach' / 'cùrr-/corra-àite' | ‘marsh’ / ‘pointed place’ / ‘place of projecting part(s)/end(s)/corner(s)/pit(s)/pool(s)/heron(s)'",
            "extent":"Pennyland",
            "certainty":"3",
            "categories":["Gaelic", "Water", "Topography"]
			},
            {"headname":"Leth Thorcaill",
			"anglicised":"Leth Thorcaill",
			"grid_ref":"NM662420",
			"historical_forms":"laycht yrdill (1494); lach kirkill (1509); laychyrdill & laychtirdill (1534–1538)",
            "lang_of_origin":"Gaelic",
            "original_elements":"leac + ?",
            "interpretation":"leac' + ? | ‘flatstone/outdoor altar/monument (to saint)/worship-station’ + ?",
            "extent":"Pennyland",
            "certainty":"2",
            "categories":["Gaelic", "Assembly", "Individuals"]
			},
            {"headname":"Sgalasdail",
			"anglicised":"Scallastle",
			"grid_ref":"NM699381",
			"historical_forms":"skowlestill mor & skollestellbeg (1494); scallastill mor & scallastill beg (1509)",
            "lang_of_origin":"Old Norse",
            "original_elements":"skjóla/skjól/skál/skáli/Skolli/Skalli + stǫðul(l)",
            "interpretation":"àite bleoghainn na cuinneige/na sgàile/a' bhotha/an taighe-thalla/Skolli/Skalli' | (cattle-)milking-place of the pail/shelter/natural basin/hut/shed/hall’ / ‘Skolli’s/Skalli's (cattle-)milking-place’",
            "extent":"Two Pennylands",
            "certainty":"2",
            "categories":["Old Norse", "Pastoral Farming/Livestock", "Habitation", "Topography", "Individuals"]
			},
    ]

    # add each settlement to the database and create questions for each
    for settlement in settlements:

        # add settlement
        add_settlement(settlement["headname"], settlement["anglicised"], settlement["grid_ref"],
                settlement["historical_forms"], settlement["lang_of_origin"], settlement["original_elements"],
                settlement["interpretation"], settlement["extent"], settlement["certainty"],
                settlement["categories"])

        # create questions for this settlement
        create_questions(settlement["headname"], settlement["interpretation"])

# creates questions for a category
def create_questions(headname, translation):
    add_question("Find the settlement with headname " + headname,
                 "Lorg an tuineachadh le ceann-ainm " + headname,
                 headname)
    add_question("Find the settlement which translates to " + translation,
                 "Lorg an tuineachadh a tha ag eadar-theangachadh " + translation,
                 headname)

# add a category to the database
def add_category(gaelic_name, english_name):
    category = Category.objects.get_or_create(gaelic_name=gaelic_name, english_name=english_name)[0]
    category.save()
    print " - Added category " + english_name
    return category

# add a settlement to the database
def add_settlement(headname, anglicised, grid_ref, historical_forms, lang_of_origin,
                   original_elements, interpretation, extent, certainty, categories):
    settlement = Settlement.objects.get_or_create(headname=headname,
	                                              anglicised=anglicised,
	                                              grid_ref=grid_ref,
                                                  historical_forms=historical_forms,
	                                              lang_of_origin=lang_of_origin,
                                                  original_elements=original_elements,
                                                  interpretation=interpretation,
                                                  extent=extent,
	                                              certainty=certainty)[0]

    # add a settlements categories
    for cat in categories:
        settlement.categories.add(Category.objects.get(english_name=cat))
    settlement.save()
    print " - Added settlement " + headname
    return settlement

# add a question to the database
def add_question(text_english, text_gaelic, answer):
    question = Question.objects.get_or_create(text_english=text_english,
                                              text_gaelic=text_gaelic,
                                              answer=Settlement.objects.get(headname=answer)
                                              )[0]
    question.save()
    print " - Added question with answer " + answer
    return question

if __name__ == '__main__':
	print("Adding objects to database...")
	populate()
