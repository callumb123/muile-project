from django.db import models
from django.template.defaultfilters import slugify
from PIL import Image, ImageDraw

# model for a settlement
class Settlement(models.Model):

    # options for language of origin
    GAELIC = 'Gaelic'
    OLD_NORSE = 'Old Norse'
    GAELIC_AND_OLD_NORSE = 'Gaelic/Old Norse'
    LANG_OF_ORIGIN_CHOICES = (
        (GAELIC, 'Gaelic'),
        (OLD_NORSE, 'Old Norse'),
        (GAELIC_AND_OLD_NORSE, 'Gaelic/Old Norse'),
    )

    # options for certainty
    CERTAINTY_CHOICES = (
        (1, '1'),
        (2, '2'),
        (3, '3'),
        (4, '4'),
        (5, '5'),
    )

    # fields from excel spreadsheet
    headname = models.CharField(primary_key = True,
								max_length = 128,
                                verbose_name = "Headname")
    anglicised = models.CharField(max_length = 128,
                                  verbose_name = "Anglicised Headname")
    grid_ref = models.CharField(max_length = 128,
                                verbose_name = "Grid Reference")
    historical_forms = models.CharField(max_length = 256,
                                        verbose_name = "Historical Forms (Year Recorded)")

    original_elements = models.CharField(max_length = 128,
                                         verbose_name = "Original Elements")
    interpretation = models.CharField(max_length = 256,
                                      verbose_name = "Interpretation")
    extent = models.CharField(max_length = 128,
                              verbose_name = "Value/Extent")
    certainty = models.SmallIntegerField(verbose_name = "Certainty",
                                         choices = CERTAINTY_CHOICES)
    lang_of_origin = models.CharField(max_length = 128,
                                      verbose_name = "Language of Origin",
                                      choices = LANG_OF_ORIGIN_CHOICES)
    categories = models.ManyToManyField('Category',
                                        verbose_name = "Category")

    # generated fields
    slug = models.SlugField(unique = True,
                            blank = True)
    image = models.ImageField(upload_to = 'csj_project/static/media/settlement_images',
                              verbose_name = "Image")
    eastings = models.CharField(max_length = 128,
                                verbose_name = "Eastings",
                                blank = False)
    northings = models.CharField(max_length = 128,
                                 verbose_name = "Northings",
                                 blank = False)

    def save(self, *args, **kwargs):

        # eastings and northings
        grid_ref_e = self.grid_ref[2:5]
        grid_ref_n = self.grid_ref[5:]
        eastings = '1' + grid_ref_e + '00'
        northings = '7' + grid_ref_n + '00'
        self.eastings = eastings
        self.northings = northings

        # slug
        toSlug = self.headname + grid_ref_e + grid_ref_n
        self.slug = slugify(toSlug)
        slug = self.slug

        # image
        image = Image.open("csj_project/static/images/baseSettlementMapPlot.png")
        draw = ImageDraw.Draw(image)
        x = int(grid_ref_e) - 225
        y = 640 - int(grid_ref_n)
        circleRadius = 10
        circleColour = (255,0,0)
        draw.ellipse((x-circleRadius, y-circleRadius, x+circleRadius, y+circleRadius), fill = circleColour, outline ='black')
        savedImage = image.save("csj_project/static/media/settlement_images/" + slug + ".png")
        self.image = savedImage

        super(Settlement, self).save(*args, **kwargs)

    def __unicode__(self):
        return self.headname + " | " + self.grid_ref

    def __str__(self):
        return self.headname + " | " + self.grid_ref

# model for a category
class Category(models.Model):

    class Meta:
        verbose_name_plural = "Categories"

    gaelic_name = models.CharField(max_length = 128,
                                   verbose_name = "Name (Gaelic)")
    english_name = models.CharField(max_length = 128,
                                    verbose_name = "Name (English)",
                                    unique = True)
    slug = models.SlugField(primary_key = True,
                            unique = True,
                            blank = True)

    def save(self, *args, **kwargs):
        self.slug = slugify(self.english_name)
        super(Category, self).save(*args, **kwargs)

    def __unicode__(self):
        return self.english_name

    def __str__(self):
        return self.english_name

# model for a question
class Question(models.Model):

    text_english = models.CharField(max_length = 512,
                                    verbose_name = "Question (English)")
    text_gaelic = models.CharField(max_length = 512,
                                    verbose_name = "Question (Gaelic)")
    answer = models.ForeignKey('Settlement',
                               verbose_name = "Answer")
    id = models.AutoField(primary_key = True)

    def save(self, *args, **kwargs):
        super(Question, self).save(*args, **kwargs)

    def __unicode__(self):
        return self.text_english

    def __str__(self):
        return self.text_english
