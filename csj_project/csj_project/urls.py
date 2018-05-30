from mullproject.views import *
from django.contrib import admin
from django.conf.urls import url, include


urlpatterns = [
    url(r'^settlement_api/$', SettlementList.as_view(), name='settlement_api'),
	url(r'^question_api/$', QuestionList.as_view(), name='question_api'),
    url(r'^$', index, name='index'),
    url(r'^index/', index, name='index'),
    url(r'^game/', game, name='game'),
    url(r'^map/', map, name='map'),
    url(r'^categories/(?P<category>[\w\-]+)', settlements, name='settlements'),
    url(r'^categories/', categories, name='categories'),
    url(r'^settlement/(?P<settlement>[\w\-]+)/', settlement, name='settlement'),
    url(r'^manage/', manage, name='manage'),
    url(r'^add_category/', add_category, name='add_category'),
    url(r'^add_settlement/', add_settlement, name='add_settlement'),
    url(r'^add_question/', add_question, name='add_question'),
    url(r'^delete_category/(?P<category>[\w\-]+)/', delete_category, name='delete_category'),
    url(r'^delete_settlement/(?P<settlement>[\w\-]+)/', delete_settlement, name='delete_settlement'),
    url(r'^delete_question/(?P<question>[\w\-]+)/', delete_question, name='delete_question'),
    url(r'^login/', user_login, name='login'),
    url(r'^logout/', user_logout, name='logout'),
    url(r'^about/', about, name='about'),
    url(r'^admin/', include(admin.site.urls)),
]
