import requests

update = {"id": 1, "tit": "new title", "body": "new content", "userId": 1}


r = requests.put("https://jsonplaceholder.typicode.com/posts/8", json=update)
print(r.json())

r = requests.patch("https://jsonplaceholder.typicode.com/posts/8", {"id": 88})
print(r.status_code)
print(r.json())

