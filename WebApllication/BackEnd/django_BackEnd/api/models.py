from django.db import models

class User(models.Model):
    username = models.CharField(max_length=50)
    password = models.CharField(max_length=128) 
    email = models.EmailField(max_length=100)
    full_name = models.CharField(max_length=100)
    marks = models.DecimalField(max_digits=6, decimal_places=1, default=0.0)

    def __str__(self):
        return self.username

class Quiz(models.Model):
    name = models.CharField(max_length=100) 
    total_marks = models.DecimalField(max_digits=6, decimal_places=1)  

    def __str__(self):
        return self.name
    
class Question(models.Model):
    quiz = models.ForeignKey(Quiz, on_delete=models.CASCADE, related_name='questions')
    question_text = models.TextField()  
    option_a = models.CharField(max_length=255)
    option_b = models.CharField(max_length=255) 
    option_c = models.CharField(max_length=255)
    option_d = models.CharField(max_length=255) 
    correct_answer = models.CharField(max_length=1, choices=[('A', 'A'), ('B', 'B'), ('C', 'C'), ('D', 'D')]) 
    def __str__(self):
        return f"Question: {self.question_text[:50]}..." #this we use to represent the quiz, i f call the print (q1), then it will print this part