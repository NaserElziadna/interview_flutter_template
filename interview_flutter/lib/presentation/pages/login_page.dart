import 'package:flutter/material.dart';
import 'package:interview_flutter/presentation/pages/register_page.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../application/auth/auth_bloc.dart';
import '../../application/auth/auth_event.dart';

class LoginPage extends StatefulWidget {
  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  // Declare variables for login form fields
  TextEditingController _email = TextEditingController(text: "admin@admin.com");
  TextEditingController _password = TextEditingController(text: "1!Qaz2@Wsx");

  @override
  Widget build(BuildContext context) {
    final AuthBloc authBloc = BlocProvider.of<AuthBloc>(context);

    return Scaffold(
      appBar: AppBar(
        title: Text('Login'),
      ),
      body: Padding(
        padding: EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            TextFormField(
              controller: _email,
              onChanged: (value) {
                setState(() {
                  _email.text = value;
                });
              },
              decoration: InputDecoration(labelText: 'Email'),
            ),
            TextFormField(
              controller: _password,
              onChanged: (value) {
                setState(() {
                  _password.text = value;
                });
              },
              obscureText: true,
              decoration: InputDecoration(labelText: 'Password'),
            ),
            SizedBox(height: 16.0),
            ElevatedButton(
              onPressed: () {
                // Dispatch the login event to the AuthBloc
                authBloc.add(LoginEvent(_email.text,_password.text));
              },
              child: Text('Login'),
            ),
            TextButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => RegisterPage()),
                );
              },
              child: Text('Create an account'),
            ),
          ],
        ),
      ),
    );
  }
}