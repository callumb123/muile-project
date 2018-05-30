from django import forms
from mullproject.models import Settlement, Category, Question

# form for adding a settlement
class SettlementForm(forms.ModelForm):

    # options for language of origin
    LANG_OF_ORIGIN_CHOICES = ([('Gaelic','Gaelic'),
                               ('Old Norse','Old Norse'),
                               ('Gaelic/Old Norse', 'Gaelic/Old Norse'),
                              ])

    # options for certainty
    CERTAINTY_CHOICES = ([('1','1'),
                          ('2','2'),
                          ('3','3'),
                          ('4','4'),
                          ('5','5'),
                         ])

    # fields from excel spreadsheet
    headname = forms.CharField(max_length = 128,
                               help_text = "Headname:")
    grid_ref = forms.CharField(max_length = 128,
                               help_text = "Grid reference:")
    anglicised = forms.CharField(max_length = 128,
                                 help_text = "Anglicised headname:")
    historical_forms = forms.CharField(max_length = 256,
                                       help_text = "Historical Forms (Year Recorded):")
    lang_of_origin = forms.TypedChoiceField(help_text = "Language of Origin:",
                                            choices = LANG_OF_ORIGIN_CHOICES)
    original_elements = forms.CharField(max_length = 128,
                                        help_text = "Original Elements:")
    interpretation = forms.CharField(max_length = 256,
                                     help_text = "Interpretation:")
    extent = forms.CharField(max_length = 128,
                             help_text = "Value/Extent:")
    certainty = forms.TypedChoiceField(help_text = "Certainty:",
                                       choices = CERTAINTY_CHOICES)
    categories = forms.ModelMultipleChoiceField(queryset = Category.objects.all(),
                                                help_text="Categories:",
                                                widget = forms.CheckboxSelectMultiple)

    class Meta:
        model = Settlement
        exclude = ['slug',
                   'image',
                   'eastings',
                   'northings',
                   ]

# form for adding a category
class CategoryForm(forms.ModelForm):

    gaelic_name = forms.CharField(max_length = 128,
                                  help_text="Name (Gaelic):")
    english_name = forms.CharField(max_length = 128,
                                   help_text="Name (English):")

    class Meta:
        model = Category
        exclude = ['slug',]

# form for adding a question
class QuestionForm(forms.ModelForm):

    text_gaelic = forms.CharField(max_length = 2048,
                                  help_text="Question (Gaelic):")
    text_english = forms.CharField(max_length = 2048,
                                  help_text="Question (English):")
    answer = forms.ModelChoiceField(queryset = Settlement.objects.order_by('headname'),
                                    help_text="Answer:",
                                    widget = forms.Select)

    class Meta:
        model = Question
        exclude = ['id',]
