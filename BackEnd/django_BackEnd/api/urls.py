from django.urls import path
from .views import get_users
from .views import add_user

urlpatterns = [
     path('users/', get_users, name='get_users'),
     path('addusers/', add_user, name='add_user')
]
