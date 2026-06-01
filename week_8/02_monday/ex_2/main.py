import requests

def safe_get(url):
    response = requests.get(url)
    if response.status_code == 200:
        return response.json()
    elif response.status_code == 404:
        return None
    else:
        return f"Exception {response.status_code}"