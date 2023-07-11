import requests
login = input("Enter username: ")
password = input("Enter password: ")
url = "your url"
data = {
    "username": login,
    "password": password
}
response = requests.post(url, data=data)
if response.text == "good":
    print("Login successful!")
else:
    print("Login failed. Status code:", response.text)