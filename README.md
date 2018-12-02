# JWT Simple JWT Tokens
 
This is a simple JWT token setup with .net core with empty project

1.Open the project and run it.
2.Stop project
3.go to appsettings.json and change your Issuer to your localhost(i.e "http://localhost:62158")

How to Run?
#region 1
Now run the project again and navigate to api/token 
an Get the value after token:
open POSTMAN
Now get to api/books
- observe you wont be able to access it
-try again with postman with the token you got make sure to put it in header and select auth from dropdown
   you will get all the data 
#end region

Try Debugging/Testing
-now repeat the process #1 again but change the birth year to 2009 before that
and you will notice the data is different for difference user with different age

Information/Help

JWT tokens is a good way to secure your server depending on your skills you can twick things to use it for your purpose.
this example is based on 
https://jwt.io/introduction/
make sure you are keep updating the tokens as the latest resources will allow you to fix any vulnerabilities that is found
stay updated with 
https://connect2id.com/products/nimbus-jose-jwt/vulnerabilities

Hope this helps someone feel free to ask questions
