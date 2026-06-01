import requests

response = requests.get("https://jsonplaceholder.typicode.com/users/1")
data = response.json()
for k, v in data.items():
    if k == "name":
        print(f"Name: {v}")
    elif k == "email":
        print(f"Email: {v}")
    elif k == "address":
        print(f"City: {v['city']}")


response2 = requests.get("https://jsonplaceholder.typicode.com/posts")
data = response2.json()
print(len(data))

response3 = requests.get("https://jsonplaceholder.typicode.com/posts/2")
data = response3.json()
for k, v in data.items():
    print(k)