import requests

new_data = {"name": "david"}

response = requests.get("https://httpbin.org/get")

data = response.text
print(data)
