from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework import status
from .models import User
from .serializer import UserSerializer

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

