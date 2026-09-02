# SauceDemo E2E Test Cases

## 1. Login
 
| Test ID | Title | Preconditions | Steps | Expected Result |
|---|---|---|---|---|
| LOGIN-01 | Valid login | User is on login page | 1. Enter `standard_user`<br>2. Enter `secret_sauce`<br>3. Click **Login** | Redirected to `/inventory.html`, product list is visible |
| LOGIN-02 | Invalid password | User is on login page | 1. Enter `standard_user`<br>2. Enter `wrong_password`<br>3. Click **Login** | Error banner: "Username and password do not match any user in this service" |
| LOGIN-03 | Locked out user | User is on login page | 1. Enter `locked_out_user`<br>2. Enter `secret_sauce`<br>3. Click **Login** | Error banner: "Sorry, this user has been locked out." |
| LOGIN-04 | Empty username | User is on login page | 1. Leave username blank<br>2. Enter `secret_sauce`<br>3. Click **Login** | Error banner: "Username is required" |
| LOGIN-05 | Empty password | User is on login page | 1. Enter `standard_user`<br>2. Leave password blank<br>3. Click **Login** | Error banner: "Password is required" |
| LOGIN-06 | Both fields empty | User is on login page | 1. Leave both fields blank<br>2. Click **Login** | Error banner: "Username is required" |
 
---