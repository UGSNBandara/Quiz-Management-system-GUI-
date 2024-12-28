from django.urls import path
from .views import get_users, add_user, user_detail
from .views import add_quiz, get_quizzes, quiz_detail
from .views import add_question, get_questions, question_detail

urlpatterns = [
     path('users/', get_users, name='get_users'),
     path('addusers/', add_user, name='add_user'),
     path('users/<int:pk>', user_detail, name='user_detail'),
     path('quiz/', get_quizzes, name='get_quizzes'),
     path('addquiz/', add_quiz, name='add_quiz'),
     path('quiz/<int:pk>', quiz_detail, name='quiz_detail'),
     path('q/', get_questions, name='get_questions'),
     path('addq/', add_question, name='add_question'),
     path('q/<int:pk>', question_detail, name='question_detail'),
]
