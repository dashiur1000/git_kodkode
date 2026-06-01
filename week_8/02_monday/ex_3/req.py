import requests

response = requests.get("http://127.0.0.1:8000/greet")
print(response.json())

response = requests.get("http://127.0.0.1:8000/greet?name=moshe")
print(response.json())