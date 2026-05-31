import requests

response = requests.get("http://localhost:8000/items/5")

print(response.status_code)
print(response.json())
