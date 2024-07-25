# Test the default Hello endpoint
GET http://localhost:5000/hello
HTTP 200
[Asserts]
header "Content-Type" contains "application/json"
jsonpath "$.message" == "Hello, World!"

# Test the Hello endpoint with a name parameter
GET http://localhost:5000/hello/John
HTTP 200
[Asserts]
header "Content-Type" contains "application/json"
jsonpath "$.message" == "Hello, John!"
