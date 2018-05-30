from django.contrib import admin
from mullproject.models import Category, Settlement, Question

class CategoryAdmin(admin.ModelAdmin):
    exclude=("slug ",
             "settlements",)
    readonly_fields=('slug',)

class SettlementAdmin(admin.ModelAdmin):
    filter_horizontal = ('categories',)

admin.site.register(Category, CategoryAdmin)
admin.site.register(Settlement, SettlementAdmin)
admin.site.register(Question)
