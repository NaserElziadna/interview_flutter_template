import 'dart:convert';

import 'package:http/http.dart' as http;

class AuthRepository {
  static const apiUrl =
      'https://localhost:44317/api'; // Replace with your API endpoint

  Future<String> login(String email, String password) async {
    final response = await http.post(
      Uri.parse('$apiUrl/Authenticate/login'),
      headers: {'Content-Type': 'application/json'},
      body: json.encode({'email': email, 'password': password}),
    );

    if (response.statusCode == 200) {
      //valid response example ==
      //"{"code":200,"message":"Success","payload":{"token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJnaXZlbl9uYW1lIjoiYWRtaW5AYWRtaW4uY29tIiwianRpIjoiZDQzMDdkY2EtNjRiMC00ZGJkLWIzMDUtMTJjOTMwZWMxY2U0IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiIyIiwiZXhwIjoxNzE1Nzc4OTU3LCJpc3MiOiJUb2tlbnM6SXNzdWVyIiwiYXVkIjoiVG9rZW5zOklzc3VlciJ9.wmgoCX1vqPTr-aGu1RMwjvKa3gPWKuPwjCMbmqKveyo","id":2,"email":"admin@admin.com","username":"admin","isBlocked":false},"sentDate":"2023-05-15T13:15:57.5120134Z"}"
      final responseData = json.decode(response.body);
      final token = responseData['payload']['token'];
      // Save the token for future use, e.g., in shared preferences
      return token;
    } else {
      throw Exception('Failed to login');
    }
  }

  Future<String> register(
      String email, String password, String fullName) async {
//     {
//   "username": "naser",
//   "email": "user@user.com",
//   "password": "1!Qaz2@Wsx"
// }
    final response = await http.post(
      Uri.parse('$apiUrl/Authenticate/register'),
      headers: {'Content-Type': 'application/json'},
      body: json
          .encode({'username': fullName, 'email': email, 'password': password}),
    );

    if (response.statusCode == 200) {
      //valid response example ==
      //"{"code":200,"message":"Success","payload":{"token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJnaXZlbl9uYW1lIjoiYWRtaW5AYWRtaW4uY29tIiwianRpIjoiZDQzMDdkY2EtNjRiMC00ZGJkLWIzMDUtMTJjOTMwZWMxY2U0IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiIyIiwiZXhwIjoxNzE1Nzc4OTU3LCJpc3MiOiJUb2tlbnM6SXNzdWVyIiwiYXVkIjoiVG9rZW5zOklzc3VlciJ9.wmgoCX1vqPTr-aGu1RMwjvKa3gPWKuPwjCMbmqKveyo","id":2,"email":"admin@admin.com","username":"admin","isBlocked":false},"sentDate":"2023-05-15T13:15:57.5120134Z"}"
      final responseData = json.decode(response.body);
      // final token = responseData['payload']['token'];
      // Save the token for future use, e.g., in shared preferences
      return "done";
    } else {
      throw Exception('Failed to login');
    }
  }
}
