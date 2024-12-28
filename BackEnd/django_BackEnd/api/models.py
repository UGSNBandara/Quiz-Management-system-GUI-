from django.db import models

class User(models.Model):
    username = models.CharField(max_length=50)
    password = models.CharField(max_length=128) 
    email = models.EmailField(max_length=100)
    full_name = models.CharField(max_length=100)
    marks = models.DecimalField(max_digits=6, decimal_places=1, default=0.0)

    def __str__(self):
        return self.username
