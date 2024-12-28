from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework import status
from .models import User, Quiz, Question
from .serializer import UserSerializer, QuizSerializer, QuestionSerializer

@api_view(['GET'])
def get_users(request):
    users = User.objects.all()
    serializedData = UserSerializer(users, many=True)
    return Response(serializedData.data)

@api_view(['POST'])
def add_user(request):
    serializedData = UserSerializer(data=request.data)
    if serializedData.is_valid(): #this function to check the validity of the data if not valid then gives an error
        serializedData.save()
        return Response(
            serializedData.data,
            status=status.HTTP_201_CREATED,
        )
    return Response(
        serializedData.errors,
        status=status.HTTP_400_BAD_REQUEST,
    )

@api_view(['DELETE', 'PUT'])
def user_detail(request, pk):
    try:
        user = User.objects.get(pk=pk)
    except User.DoesNotExist:
        return Response(status=status.HTTP_404_NOT_FOUND)    
    if request.method == 'DELETE':
        user.delete()
        return Response(status=status.HTTP_204_NO_CONTENT)
    elif request.method == 'PUT':
        data = request.data
        serializer = UserSerializer(user, data=data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data)
        return Response(serializer.error, status=status.HTTP_400_BAD_REQUEST)
    
#for Quiz

@api_view(['GET'])
def get_quizzes(request):
    quizzes = Quiz.objects.all()
    serializedData = QuizSerializer(quizzes, many=True)
    return Response(serializedData.data)

@api_view(['POST'])
def add_quiz(request):
    serializedData = QuizSerializer(data=request.data)
    if serializedData.is_valid():
        serializedData.save()
        return Response(
            serializedData.data,
            status=status.HTTP_201_CREATED,
        )
    return Response(
        serializedData.errors,
        status=status.HTTP_400_BAD_REQUEST,
    )

@api_view(['DELETE', 'PUT'])
def quiz_detail(request, pk):
    try:
        quiz = Quiz.objects.get(pk=pk)
    except Quiz.DoesNotExist:
        return Response(status=status.HTTP_404_NOT_FOUND)    
    if request.method == 'DELETE':
        quiz.delete()
        return Response(status=status.HTTP_204_NO_CONTENT)
    elif request.method == 'PUT':
        data = request.data
        serializer = QuizSerializer(quiz, data=data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)


#for Questions:

@api_view(['GET'])
def get_questions(request):
    quiz_id = request.query_params.get('quiz_id')  #need this part to load questions based on quiz id
    if quiz_id:
        questions = Question.objects.filter(quiz_id=quiz_id)
    else:
        questions = Question.objects.all()
    serializedData = QuestionSerializer(questions, many=True)
    return Response(serializedData.data)


@api_view(['POST'])
def add_question(request):
    serializedData = QuestionSerializer(data=request.data)
    if serializedData.is_valid():
        serializedData.save()
        return Response(
            serializedData.data,
            status=status.HTTP_201_CREATED,
        )
    return Response(
        serializedData.errors,
        status=status.HTTP_400_BAD_REQUEST,
    )

@api_view(['DELETE', 'PUT'])
def question_detail(request, pk):
    try:
        question = Question.objects.get(pk=pk)
    except Question.DoesNotExist:
        return Response(status=status.HTTP_404_NOT_FOUND)
    
    if request.method == 'DELETE':
        question.delete()
        return Response(status=status.HTTP_204_NO_CONTENT)
    
    elif request.method == 'PUT':
        data = request.data
        serializer = QuestionSerializer(question, data=data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)
