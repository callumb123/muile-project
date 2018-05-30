from django.conf.urls import url
from mullproject.views import index, map

urlpatterns = [
	url(r'^$', index, name='index'),
    url(r'^$', map, name='map')
    ]
